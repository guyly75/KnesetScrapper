using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnesetScrapper.Entities
{
    public class Speaker
    {
        public int SpeakerId { get; set; }
        public string? SpeakerName { get; set; }
        public int MkId { set; get; }
        public List<Session> Sessions { get; set; }
        public bool SessionsRetrieved { get; set; } 
    }
}
