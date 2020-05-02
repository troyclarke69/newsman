using System;
using System.Collections.Generic;
using System.Text;

namespace NewsMan.Data.Models
{
    public class Session
    {
        public int Id { get; set; }
        public DateTime DateEntered { get; set; }
        public string Origin { get; set; }
        public SurveyMaster SurveyMaster { get; set; }

    }
}
