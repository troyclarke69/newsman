using NewsMan.Data.Data;
using NewsMan.Data.Interfaces;
using NewsMan.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewsMan.Service.Services
{
    public class AnswerGroupService : IAnswerGroup
    {
        private readonly NewsManDbContext _context;
        public AnswerGroupService(NewsManDbContext context) { _context = context; }

        public void Add(AnswerGroup newAnswerGroup)
        {
            _context.Add(newAnswerGroup);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.AnswerGroup.Where(g => g.Id == id)
               .ToList().ForEach(g => _context.AnswerGroup.Remove(g));
            _context.SaveChanges();
        }

        public AnswerGroup Get(int id)
        {
            return GetAll().FirstOrDefault(f => f.Id == id);
        }

        public IEnumerable<AnswerGroup> GetAll()
        {
            return _context.AnswerGroup;
        }

        public void Update(AnswerGroup newAnswerGroup)
        {
            throw new NotImplementedException();
        }
    }
}
