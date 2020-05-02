using NewsMan.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsMan.ViewModels
{
    public class ResultPart2ListingModel
    {
        public int Id { get; set; }
        public Question Question { get; set; }
        public SurveyMaster Survey { get; set; }

        //public string SessionId { get; set; }
        public int Answer { get; set; }
        public string AnswerText { get; set; }
        public int Votes { get; set; }
        public decimal Percentage { get; set; }
       
    }
}
