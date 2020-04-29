using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsMan.ViewModels
{
    public class TestListingModel
    {
        public List<QuestionListingModel> Questions { get; set; }
        public List<SurveyListingModel> Answers { get; set; }
        public List<AnswerListingModel> AnswerOptions { get; set; }

    }
}
