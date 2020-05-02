using NewsMan.Data.Data;
using NewsMan.Data.Interfaces;
using NewsMan.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace NewsMan.Service.Services
{
    public class ResultService : IResult
    {
        private readonly NewsManDbContext _context;
        public ResultService(NewsManDbContext context) { _context = context; }
        public void Add(Result newResult)
        {
            _context.Add(newResult);
            _context.SaveChanges();
        }

        public decimal GetAnswerPercentage(int totalVotes, int totalSessions)
        {
            decimal result = (Convert.ToDecimal(totalVotes) / Convert.ToDecimal(totalSessions)) * 100;
            result = Math.Round(result, 1);
            return result;
        }

        public int GetTotalSessions(int survey)
        {
            var dist = _context.Result.Select(s => s.Session).Where(a => a.SurveyMaster.Id == survey);
            return dist.Distinct().Count();

        }

        public int GetTotalVotes(int questionId, int answerId)
        {
            var v = _context.Result.Where(a => a.Question.Id == questionId && a.AnswerOption.Id == answerId);
            return v.Count();
        }

        // SeedData re-written for Result table ... This is not used here...
        public void SeedData()
        {
            int NUM_OF_SESSIONS = _context.Session.Count();
            int NUM_OF_QUESTIONS = _context.Question.Count();

            string sessionId = string.Empty;

            // Look for any data first.
            if (_context.Result.Any())
            {
                return;   // DB has been seeded
            }

            for (var x = 1; x <= NUM_OF_SESSIONS; x++)
            {
                // simulate user session: each user/session answers all questions
                sessionId = Guid.NewGuid().ToString();

                for (var y = 1; y <= NUM_OF_QUESTIONS; y++)
                {
                    // *Hack: in future may need to adjust random gen as IDs may not be 1-5
                    // Also - some questions may have more/less answer options ...
                    int rnd = new Random().Next(1, 5); //returns 1 - 4?
                    var answer = _context.AnswerOption.FirstOrDefault(a => a.Id == rnd);

                    // No Hack here...
                    var question = _context.Question.FirstOrDefault(q => q.Id == y);

                    // *Hack: gen results for survey 1 only
                    var survey = _context.SurveyMaster.FirstOrDefault(s => s.Id == 1);
                    // No Hack here...
                    var session = _context.Session.FirstOrDefault(s => s.Id == x);

                    _context.Add(
                        new Result
                        {
                            Question = question,
                            SurveyMaster = survey,
                            Session = session,
                            AnswerOption = answer
                        }

                    );
                    _context.SaveChanges();
                }
            }
        }

        public void Delete(int id)
        {
            // This is written to delete multiples, and works with one
            _context.Result.Where(g => g.Id == id)
               .ToList().ForEach(g => _context.Result.Remove(g));
            _context.SaveChanges();
        }

        public Result Get(int id)
        {
            return GetAll().FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Result> GetAll()
        {
            return _context.Result;
        }

        public IEnumerable<Result> GetAllByAnswer(int answer)
        {
            return GetAll().Where(a => a.AnswerOption.Id == answer);
        }

        public IEnumerable<Result> GetAllByQuestion(int question)
        {
            return GetAll().Where(a => a.Question.Id == question);
        }

        public IEnumerable<Result> GetAllBySession(int session)
        {
            return GetAll().Where(a => a.Session.Id == session);
        }

        public IEnumerable<Result> GetAllBySurvey(int survey)
        {
            return _context.Result
                .Include(a => a.Session)
                .Include(a => a.SurveyMaster)
                .Include(a => a.Question)
                .Include(a => a.AnswerOption)
                .Where(a => a.SurveyMaster.Id == survey);
        }

        public IEnumerable<Result> GetSummaryBySurvey(int survey)
        {
            //var a = _context.Result
            //     .Include(a => a.Session)
            //     .Include(a => a.SurveyMaster)
            //     .Include(a => a.Question)
            //     .Include(a => a.AnswerOption)
            //     .Where(a => a.SurveyMaster.Id == survey);

            // var g = a.GroupBy(x => x.Question.Id)
            //     .Select(z => new
            //     {
            //         z.Key.
            //     }
            return _context.Result;
        }

        public void Update(Result newAnswer)
        {
            throw new NotImplementedException();
        }
    }
}
