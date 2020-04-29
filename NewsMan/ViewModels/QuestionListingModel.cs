using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsMan.ViewModels
{
    public class QuestionListingModel
    {
        public int Id { get; set; }
        public int Level { get; set; } //1 = pre, 2 = post
        public int Order { get; set; }
        public string Question { get; set; }
    }
}
