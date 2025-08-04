using System;
using System.Collections.Generic;
using System.Text;

namespace B64.Models
{
    public class HistoryDetail
    {
        public HeaderDetailEntryList HeaderDetailEntryList { get; set; }
    }

    public class HeaderDetailEntryList
    {
        public string Header { get; set; }
        public DetailsEntryList DetailsEntryList { get; set; }
    }

    public class DetailsEntryList
    {
        public string Name{ get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public int? HistoryDetailHandling { get; set; }            
    }
}
