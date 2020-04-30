using System.Collections.Generic;

namespace NewsMan.ViewModels
{
    public class ResultListingModel
    {
        public List<SurveyListingModel> Answers { get; set; }
        public List<SurveySummaryModel> Summary { get; set; }
        public int TotalSessions { get; set; }

    }
}
