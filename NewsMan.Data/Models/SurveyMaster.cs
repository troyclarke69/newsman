using System;
using System.Collections.Generic;
using System.Text;

namespace NewsMan.Data.Models
{
    public class SurveyMaster
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Purpose { get; set; }
        public DateTime DateOpen { get; set; }
        public DateTime DateClose { get; set; }
        public int Active { get; set; }

    }
}
