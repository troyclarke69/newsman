using System;
using System.Collections.Generic;
using System.Text;

namespace NewsMan.Data.Models
{
    public class AnswerOption
    { 
        public int Id { get; set; }
        public int AnswerVal { get; set; }
        public string AnswerText { get; set; }
        public AnswerGroup AnswerGroup { get; set; }

    }
}
