using System;
using System.Collections.Generic;
using System.Text;

namespace NewsMan.Data.Models
{
    public class Result
    {
        public int Id { get; set; }
        public Session Session { get; set; }
        public SurveyMaster SurveyMaster { get; set; }
        public Question Question { get; set; }
        public AnswerOption AnswerOption { get; set; }

    }
}
