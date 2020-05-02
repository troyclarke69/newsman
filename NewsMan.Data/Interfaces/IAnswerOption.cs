using NewsMan.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsMan.Data.Interfaces
{
    public interface IAnswerOption
    {
        IEnumerable<AnswerOption> GetAll();
        AnswerOption Get(int id);
        void Add(AnswerOption newAnswerOption);
        void Update(AnswerOption newAnswerOption);
        void Delete(int id);
    }
}
