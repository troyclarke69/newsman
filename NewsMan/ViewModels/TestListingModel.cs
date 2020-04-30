using System.Collections.Generic;

namespace NewsMan.ViewModels
{
    public class TestListingModel
    {
        public List<QuestionListingModel> Questions { get; set; }
        public List<SurveyListingModel> Answers { get; set; }
        public List<AnswerListingModel> AnswerOptions { get; set; }

    }
}
