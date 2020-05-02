using NewsMan.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsMan.Data.Interfaces
{
    public interface IResult
    {
        IEnumerable<Result> GetAllBySession(int session);
        IEnumerable<Result> GetAllBySurvey(int survey);
        IEnumerable<Result> GetAllByQuestion(int question);
        IEnumerable<Result> GetAllByAnswer(int answer);

        IEnumerable<Result> GetSummaryBySurvey(int survey);

        int GetTotalSessions(int survey);
        // return totals/perc for the individual answers per the current session
        int GetTotalVotes(int questionId, int answerId);
        decimal GetAnswerPercentage(int totalVotes, int totalSessions);
        void SeedData();

        IEnumerable<Result> GetAll();
        Result Get(int id);
        void Add(Result newAnswer);
        void Update(Result newAnswer);
        void Delete(int id);

    }
}
