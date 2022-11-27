using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnesetScrapper
{
    public class KnesetSession
    {
        public int RowNum { get; set; }
        public string SessionDate { get; set; } = "";
        public string StartDate { get; set; } = "";
        public string SessionDateStr { get; set; } = "";
        public int FK_ItemID { get; set; }
        public string Stream_PublishedUrl { get; set; } = "";
        public int NumOfPages { get; set; }
        public int cntTotalRows { get; set; }
    }
}
