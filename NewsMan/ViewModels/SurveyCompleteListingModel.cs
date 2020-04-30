using NewsMan.Data.Models;
using System.Collections.Generic;

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
