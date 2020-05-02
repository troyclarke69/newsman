using NewsMan.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsMan.Data.Interfaces
{
    public interface IAnswerGroup
    {
        IEnumerable<AnswerGroup> GetAll();
        AnswerGroup Get(int id);
        void Add(AnswerGroup newAnswerGroup);
        void Update(AnswerGroup newAnswerGroup);
        void Delete(int id);
    }
}
