using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace B64.Models
{
    public class QuoteHistory
    {
        public string QuoteId { get; set; }
        public List<HistoryEntriesList> HistoryEntriesList { get; set; }  
    }

    public class HistoryEntriesList 
    {
        public string Id { get; set; }
        public string HistoryDetailId { get; set; }
        public string UserName { get; set; }
        public DateTime EntryDate { get; set; }
        public string HistoryAction { get; set; }
        public string QuoteStatus { get; set; }
        public string Notes { get; set; }
        public DateTime QuoteLastModified { get; set; }
    }
}
