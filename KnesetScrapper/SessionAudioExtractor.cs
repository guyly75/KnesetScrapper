using FFMpegCore;
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
    public class SessionAudioExtractor
    {
        public SessionAudioExtractor()
        {
            GlobalFFOptions.Configure(new FFOptions { BinaryFolder = "C:\\ProgramData\\chocolatey\\lib\\ffmpeg\\tools\\ffmpeg\\bin", TemporaryFilesFolder = "c:\\temp" });
        }
        public async Task<bool> ExtractAudioFromSession(Session session)
        {

            //Pick any logging implementation you want, here we are using Serilog
            var inputFileName = $"{session.SessionId}ID-Session-{session.ItemID}.mp4";
            var outputFileName = $"\\\\levynas\\other\\{session.SessionId}ID-Session-{session.ItemID}.wav";
            var outputFileName1 = $"\\\\levynas\\other\\{session.SessionId}ID-Session-{session.ItemID}.wav";
            if (!File.Exists(outputFileName))
            {
                Console.WriteLine($"Start Extracting audio from {inputFileName}");
                try
                {
                    await FFMpegArguments
                        .FromFileInput(inputFileName)
                        .OutputToFile(outputFileName)
                        .ProcessAsynchronously();

                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error {e}");
                    return false;
                }
            }
            return true;

        }
    }
}
