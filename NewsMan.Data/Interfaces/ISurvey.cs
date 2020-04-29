using NewsMan.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsMan.Data.Interfaces
{
    public interface ISurvey
    {
        IEnumerable<Survey> GetAll();
        IEnumerable<Survey> GetAllBySessionId(string sessionId);
        IEnumerable<Survey> GetAllBySurvey(string sessionId);
        //string GetAnswerText(int key, int val);
        Survey Get(int id);
        void Add(Survey newFeed);
        void Update(Survey newFeed);
        void Delete(int id);
        void DeleteAllBySessionId(string sessionId);
        void SeedData();
    }
}
