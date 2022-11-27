using KnesetScrapper.Entities;
using Microsoft.Extensions.Logging;
using OctaneEngine;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnesetScrapper
{
    public class SessionDownloader
    {
        public async Task<string> downloadSession(Session session)
        {
            var config = new OctaneConfiguration
            {
                Parts = 5,
                BufferSize = 8192,
                ShowProgress = false,
                BytesPerSecond = 1,
                UseProxy = false,
                Proxy = null,
                DoneCallback = x => {
                    Console.WriteLine("Done!");
                },
                ProgressCallback = x => {
                    Console.WriteLine(x.ToString(CultureInfo.InvariantCulture));
                },
                NumRetries = 10
            };

            //Pick any logging implementation you want, here we are using Serilog
            var fileName = $"{session.SessionId}ID-Session-{session.ItemID}.mp4";
            if(!File.Exists(fileName))
            {
                Console.WriteLine($"Start Downloading {fileName}");
                await Engine.DownloadFile(session.SessionMovieURL, null, fileName, config);
            }
            return fileName;

        }
    }
}
