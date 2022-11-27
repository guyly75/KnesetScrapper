using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnesetScrapper.Entities
{
    public class Session
    {
        public int SessionId { get; set; }
        public DateTime SessionDate { get; set; }
        public string SessionName { get; set; } = "";
        public int ItemID { get; set; }
        public string SessionMovieURL { get; set; } = "";
        public List<Speaker> Speakers { get; set; }
        public bool Downloaded { get; set; }
    }
}
