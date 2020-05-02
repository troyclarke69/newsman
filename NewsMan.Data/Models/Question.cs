using System;
using System.Collections.Generic;
using System.Text;

namespace NewsMan.Data.Models
{
    public class Question
    {
        public int Id { get; set; }
        public int QGroup { get; set; }
        public int Order { get; set; }
        public string QuestionText { get; set; }
        public AnswerGroup AnswerGroup { get; set; }

    }
}
