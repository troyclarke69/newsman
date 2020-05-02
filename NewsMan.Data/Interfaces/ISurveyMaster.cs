using NewsMan.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsMan.Data.Interfaces
{
    public interface ISurveyMaster
    {
        IEnumerable<SurveyMaster> GetAll();
        SurveyMaster Get(int id);
        void Add(SurveyMaster newSurveyMaster);
        void Update(SurveyMaster newSurveyMaster);
        void Delete(int id);
    }
}
