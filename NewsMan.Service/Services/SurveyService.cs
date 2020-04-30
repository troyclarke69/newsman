using Microsoft.EntityFrameworkCore;
using NewsMan.Data.Data;
using NewsMan.Data.Interfaces;
using NewsMan.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NewsMan.Service.Services
{
    public class SurveyService : ISurvey
    {
        private readonly NewsManDbContext _context;
        public SurveyService(NewsManDbContext context) { _context = context; }
        public void Add(Survey newSurvey)
        {
            _context.Add(newSurvey);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            // This is written to delete multiples, and works with one
            _context.Survey.Where(g => g.Id == id)
               .ToList().ForEach(g => _context.Survey.Remove(g));
            _context.SaveChanges();
        }

        public void DeleteAllBySessionId(string sessionId)
        {
            _context.Survey.Where(g => g.SessionId == sessionId && g.Answer == 0)
              .ToList().ForEach(g => _context.Survey.Remove(g));
            _context.SaveChanges();
        }

        public Survey Get(int id)
        {
            return GetAll().FirstOrDefault(f => f.Id == id);
        }

        public IEnumerable<Survey> GetAll()
        {
            return _context.Survey;
        }

        public IEnumerable<Survey> GetAllBySessionId(string sessionId)
        {
            // return all UNANSWERED questions
            // This is used for the HACK - initial creation of survey records before they are answered
            // These '0' answers are deleted and replaced by the actual answers
            return GetAll().Where(s => s.SessionId == sessionId && s.Answer == 0);
        }

        public IEnumerable<Survey> GetAllBySurvey(string sessionId)
        {
            // return all ANSWERED questions - including '0' (intentionally unanswered) ... 'RESULTS' (Index4) page
            return _context.Survey
                .Include(a => a.QMaster)
                .Where(s => s.SessionId == sessionId);
        }

        public IEnumerable<Survey> GetAllSurveyResults(string sessionId)
        {
            return _context.Survey
                .Include(a => a.QMaster)
                .Include(b => b.AMaster)
                .Where(c => c.SessionId.Contains(sessionId));

        }

        //public IEnumerable<Survey> GetAllSessionResults(string sessionId)
        //{
        //    throw new NotImplementedException();
        //}

        public decimal GetAnswerPercentage(int totalVotes, int totalSessions)
        {
            decimal result = (Convert.ToDecimal(totalVotes) / Convert.ToDecimal(totalSessions)) * 100;
            result = Math.Round(result, 1);
            return result;
        }

        public int GetTotalSessions()
        {
            var dist = _context.Survey.Select(s => s.SessionId).Distinct();
            return dist.Count();

        }

        public int GetTotalVotes(int questionId, int answerId)
        {
            var v = _context.Survey.Where(a => a.QMaster.Id == questionId && a.Answer == answerId);
            return v.Count();
        }

        public void SeedData()
        {
            const int NUM_OF_SESSIONS = 10000;
            const int NUM_OF_QUESTIONS = 8; //set to QMaster.count

            string sessionId = string.Empty;

            // Look for any data first.
            if (_context.Survey.Any())
            {
                return;   // DB has been seeded
            }

            for (var x = 1; x <= NUM_OF_SESSIONS; x++)
            {
                // simulate user session: each user/session answers all questions
                sessionId = Guid.NewGuid().ToString();

                for (var y = 1; y <= NUM_OF_QUESTIONS; y++)
                {
                    int rnd = new Random().Next(1, 5);
                    var q = _context.QMaster.FirstOrDefault(q => q.Id == y);

                    _context.Add(
                        new Survey
                        {
                            QMaster = q,
                            SessionId = sessionId,
                            Answer = rnd
                        }

                    );
                    _context.SaveChanges();
                }
            }
        }

        public void Update(Survey newFeed)
        {
            throw new NotImplementedException();
        }
    }
}
