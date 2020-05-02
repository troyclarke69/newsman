using NewsMan.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsMan.Data.Interfaces
{
    public interface IQuestion
    {
        IEnumerable<Question> GetAll();
        Question Get(int id);
        void Add(Question newQuestion);
        void Update(Question newQuestion);
        void Delete(int id);
    }
}
