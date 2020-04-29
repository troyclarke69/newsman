using NewsMan.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsMan.ViewModels
{
    public class SurveyCompleteListingModel
    {
        public int Id { get; set; }
        public QMaster QMaster { get; set; }
        public string SessionId { get; set; }
        public int Answer { get; set; }
        public AMaster AMaster { get; set; }
        //AnswerPercentages
        public IEnumerable<SurveySummaryModel> Summary { get; set; }
    }
}
