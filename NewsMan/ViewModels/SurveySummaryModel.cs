using System.Collections.Generic;

namespace NewsMan.ViewModels
{
    public class SurveySummaryModel
    {

        public int QuestionId { get; set; }
        public string SessionId { get; set; }
        public int SessionAnswer { get; set; }
        public string AnswerText { get; set; }

        // Ties a Question to the assoicated answer options ...
        public int AnswerKey { get; set; }

        public List<SurveyAnswerListingModel> AnswerStats { get; set; }

        //public int Val { get; set; }
        //public string AnswerText { get; set; }
        //public int Votes { get; set; }
        //public decimal Percentage { get; set; }

    }
}
