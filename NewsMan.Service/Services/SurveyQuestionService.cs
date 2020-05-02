using Microsoft.EntityFrameworkCore;
using NewsMan.Data.Data;
using NewsMan.Data.Interfaces;
using NewsMan.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewsMan.Service.Services
{
    public class SurveyQuestionService : ISurveyQuestion
    {
        private readonly NewsManDbContext _context;
        public SurveyQuestionService(NewsManDbContext context) { _context = context; }

        public void Add(SurveyQuestion newSurveyQuestion)
        {
            _context.Add(newSurveyQuestion);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.SurveyQuestion.Where(g => g.Id == id)
               .ToList().ForEach(g => _context.SurveyQuestion.Remove(g));
            _context.SaveChanges();
        }

        public SurveyQuestion Get(int id)
        {
            return GetAll().FirstOrDefault(f => f.Id == id);
        }

        public IEnumerable<SurveyQuestion> GetAll()
        {
            return _context.SurveyQuestion;
        }

        public IEnumerable<SurveyQuestion> GetAllByQuestionId(int questionId)
        {
            return _context.SurveyQuestion.Where(s => s.Question.Id == questionId);
        }

        public IEnumerable<SurveyQuestion> GetAllBySurveyId(int surveyId)
        {
            return _context.SurveyQuestion
                .Include(s => s.SurveyMaster)
                .Include(q => q.Question)
                .Where(s => s.SurveyMaster.Id == surveyId);
        }

        public void Update(SurveyQuestion newSurveyQuestion)
        {
            throw new NotImplementedException();
        }
    }
}
