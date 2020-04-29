using NewsMan.Data.Data;
using NewsMan.Data.Interfaces;
using NewsMan.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewsMan.Service.Services
{
    public class AMasterService : IAMaster
    {
        private readonly NewsManDbContext _context;
        public AMasterService(NewsManDbContext context) { _context = context; }

        public void Add(AMaster newAnswer)
        {
            _context.Add(newAnswer);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.AMaster.Where(g => g.Id == id)
                .ToList().ForEach(g => _context.AMaster.Remove(g));
            _context.SaveChanges();
        }

        public AMaster Get(int id)
        {
            return GetAll().FirstOrDefault(f => f.Id == id);
        }

        public IEnumerable<AMaster> GetAll()
        {
            return _context.AMaster;
        }

        public IEnumerable<AMaster> GetAllByKey(int key)
        {
            return GetAll().Where(q => q.Key == key);
        }

        public string GetAnswerText(int key, int val)
        {
            return _context.AMaster
                    .FirstOrDefault(a => a.Key == key && a.Val == val).Answer;
        }

        public void Update(AMaster newAnswer)
        {
            throw new NotImplementedException();
        }
    }
}
