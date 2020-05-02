using NewsMan.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsMan.Data.Interfaces
{
    public interface ISurveyQuestion
    {
        IEnumerable<SurveyQuestion> GetAll();
        IEnumerable<SurveyQuestion> GetAllBySurveyId(int surveyId);
        IEnumerable<SurveyQuestion> GetAllByQuestionId(int questionId);

        SurveyQuestion Get(int id);
        void Add(SurveyQuestion newSurveyQuestion);
        void Update(SurveyQuestion newSurveyQuestion);
        void Delete(int id);
    }
}
