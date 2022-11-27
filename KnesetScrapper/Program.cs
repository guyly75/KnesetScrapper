using KnesetScrapper.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace KnesetScrapper
{
    class Program
    {
        static async Task Main(string[] args)
        {

            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddLogging(x => x.AddSimpleConsole(o => {
                    o.IncludeScopes = false;
                    o.SingleLine = true;
                    o.TimestampFormat = "dd/MM/yy HH:mm:ss:fff ";
                }))
                .AddDbContext<DBContext>()
                .BuildServiceProvider();

            //configure console logging
            var logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();

            var ss = new SessionsScraper();
            var context = serviceProvider.GetService<DBContext>();
            var nonRetrievedSpeakers = context.Speakers.Where(x => !x.SessionsRetrieved).ToList();

            foreach (var speaker in nonRetrievedSpeakers)
            {
                var data = await ss.ScrapingBySpeaker(speaker);
                foreach (var item in data)
                {
                    var existingItem = context.Sessions.Where(x => x.ItemID == item.ItemID); 
                    if (speaker.Sessions == null)
                        speaker.Sessions = new List<Session>();
                    if (existingItem.Any())
                    {
                        speaker.Sessions.Add(existingItem.Single());
                    }
                    else
                        speaker.Sessions.Add(item);
                    context.SaveChanges();
                }
                speaker.SessionsRetrieved= true;
                context.SaveChanges();
            }

            var sessionsToDownload = context.Sessions.ToList();
            foreach (var session in sessionsToDownload)
            //Parallel.ForEach(sessionsToDownload, new ParallelOptions { MaxDegreeOfParallelism = 1 }, session =>
            {
                var downloader = new SessionDownloader();
                var mp4File= await downloader.downloadSession(session);
                var extractor = new SessionAudioExtractor();
                if (await extractor.ExtractAudioFromSession(session))
                {
                    session.Downloaded = true;
                    context.SaveChanges();
                }
                else
                    File.Delete(mp4File);
            }
            //);



        }

    }
}