using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsMan.ViewModels
{
    public class SurveySummaryModel
    {
        // QuestionId
        public int Id { get; set; }

        // Answer ...
        public int Key { get; set; }
        public int Val { get; set; }
        public string Answer { get; set; }
        public int Votes { get; set; }
        public decimal Percentage { get; set; }

    }
}
