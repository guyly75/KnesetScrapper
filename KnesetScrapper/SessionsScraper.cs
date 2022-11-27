using KnesetScrapper.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace KnesetScrapper
{

    internal class SessionsScraper:IDisposable
    {
        private HttpClient _httpClient = new System.Net.Http.HttpClient();
        private DBContext _dbContext;
        private const string SessionsURL = "https://knesset.gov.il/WebSiteApi/knessetapi/KnessetMainLobby/GetPlenumBroadcastSearchData";



        public async Task<List<Session>> ScrapingBySpeaker(Speaker speaker, int fromKnesetNumber=1,int toKnesetNumber=25)
        {
            var mkId = speaker.MkId;
            var ret = new List<Session>();
            for(int curKneset=fromKnesetNumber;curKneset<=toKnesetNumber;curKneset++)
            {
                var knesetSessions = await DoScraping(mkId, curKneset);
                ret.AddRange(knesetSessions);
            }
            return ret;
        }

        private async Task<List<Session>> DoScraping(int mkId,int knesetId)
        {
            var ret = new List<Session>();
            var curPage = 1;
            do
            {
                var parmJson = $"{{FromDate:\"1990-3-31\",ToDate:\"2025-4-30\",MkId:\"{mkId}\",KnessetId:{knesetId},PageNumber:{curPage}}}";
                Console.WriteLine(parmJson);
            var requestContent = new StringContent(parmJson, Encoding.UTF8, "application/json");
                var response=await _httpClient.PostAsync(SessionsURL, requestContent);
            if(response.IsSuccessStatusCode)
                { 
                    var jsonData = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(jsonData);
                    var tvShowInfo = JsonSerializer.Deserialize<KnesetResult>(jsonData);
                    if (tvShowInfo.PlenumBroadcastVOD.Count == 0)
                        return ret;

                    foreach (var session in tvShowInfo.PlenumBroadcastVOD)
                        ret.Add(new Session { ItemID = session.FK_ItemID, SessionDate = DateTime.Parse(session.StartDate), SessionMovieURL = session.Stream_PublishedUrl });
                    curPage++;
                }
            } while (true);
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
