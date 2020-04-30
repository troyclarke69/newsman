using NewsMan.Data.Models;
using System.Collections.Generic;

namespace NewsMan.Data.Interfaces
{
    public interface ISurvey
    {
        IEnumerable<Survey> GetAll();

        // return survey model, bySessionId returns answers == 0 (Hack?), bySurvey returns ALL answers (for RESULTS page)
        IEnumerable<Survey> GetAllBySessionId(string sessionId);
        IEnumerable<Survey> GetAllBySurvey(string sessionId);


        // return all totals/perc for the questions/answers for the current session
        IEnumerable<Survey> GetAllSurveyResults(string sessionId);

        int GetTotalSessions();

        // return totals/perc for the individual answers per the current session
        int GetTotalVotes(int questionId, int answerId);
        decimal GetAnswerPercentage(int totalVotes, int totalSessions);



        //string GetAnswerText(int key, int val);
        Survey Get(int id);
        void Add(Survey newFeed);
        void Update(Survey newFeed);
        void Delete(int id);
        void DeleteAllBySessionId(string sessionId);
        void SeedData();
    }
}
