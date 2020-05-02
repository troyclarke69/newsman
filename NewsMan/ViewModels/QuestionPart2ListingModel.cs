using NewsMan.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsMan.ViewModels
{
    public class QuestionPart2ListingModel
    {
        public int Id { get; set; }
        public int QGroup { get; set; }
        public int Order { get; set; }
        public string QuestionText { get; set; }
        //public AnswerGroup AnswerGroup { get; set; }
    }
}
