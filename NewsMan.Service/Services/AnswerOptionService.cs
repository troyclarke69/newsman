using NewsMan.Data.Data;
using NewsMan.Data.Interfaces;
using NewsMan.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewsMan.Service.Services
{
    public class AnswerOptionService : IAnswerOption
    {
        private readonly NewsManDbContext _context;
        public AnswerOptionService(NewsManDbContext context) { _context = context; }

        public void Add(AnswerOption newAnswerOption)
        {
            _context.Add(newAnswerOption);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.AnswerOption.Where(g => g.Id == id)
               .ToList().ForEach(g => _context.AnswerOption.Remove(g));
            _context.SaveChanges();
        }

        public AnswerOption Get(int id)
        {
            return GetAll().FirstOrDefault(f => f.Id == id);
        }

        public IEnumerable<AnswerOption> GetAll()
        {
            return _context.AnswerOption;
        }

        public void Update(AnswerOption newAnswerOption)
        {
            throw new NotImplementedException();
        }
    }
}
