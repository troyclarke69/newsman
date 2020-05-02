using NewsMan.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsMan.ViewModels
{
    public class ResultSummaryListingModel
    {
        public int TotalSessions { get; set; }
        public List<ResultPart2ListingModel> Results { get; set; }
    }
}
