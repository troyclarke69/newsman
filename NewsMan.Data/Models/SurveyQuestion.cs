using System;
using System.Collections.Generic;
using System.Text;

namespace NewsMan.Data.Models
{
    public class SurveyQuestion
    {
        public int Id { get; set; }
        public SurveyMaster SurveyMaster { get; set; }
        public Question Question { get; set; }

    }
}
