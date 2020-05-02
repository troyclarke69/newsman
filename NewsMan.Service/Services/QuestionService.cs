using NewsMan.Data.Data;
using NewsMan.Data.Interfaces;
using NewsMan.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewsMan.Service.Services
{
    public class QuestionService : IQuestion
    {
        private readonly NewsManDbContext _context;
        public QuestionService(NewsManDbContext context) { _context = context; }

        public void Add(Question newQuestion)
        {
            _context.Add(newQuestion);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Question.Where(g => g.Id == id)
               .ToList().ForEach(g => _context.Question.Remove(g));
            _context.SaveChanges();
        }

        public Question Get(int id)
        {
            return GetAll().FirstOrDefault(f => f.Id == id);
        }

        public IEnumerable<Question> GetAll()
        {
            return _context.Question;
        }

        public void Update(Question newQuestion)
        {
            throw new NotImplementedException();
        }
    }
}
