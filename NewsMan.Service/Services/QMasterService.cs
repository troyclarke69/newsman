using NewsMan.Data.Data;
using NewsMan.Data.Interfaces;
using NewsMan.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NewsMan.Service.Services
{
    public class QMasterService : IQMaster
    {
        private readonly NewsManDbContext _context;
        public QMasterService(NewsManDbContext context) { _context = context; }

        public void Add(QMaster newQuestion)
        {
            _context.Add(newQuestion);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.QMaster.Where(g => g.Id == id)
                .ToList().ForEach(g => _context.QMaster.Remove(g));
            _context.SaveChanges();
        }

        public QMaster Get(int id)
        {
            return GetAll().FirstOrDefault(f => f.Id == id);
        }

        public IEnumerable<QMaster> GetAll()
        {
            return _context.QMaster;
        }

        public IEnumerable<QMaster> GetAllByLevel(int level)
        {
            return GetAll().Where(q => q.Level == level);
        }

        public IEnumerable<QMaster> GetAllWithAns(int level)
        {
            return _context.QMaster
                .Where(q => q.Level == level)
                ;
        }

        public void Update(QMaster newQuestion)
        {
            throw new NotImplementedException();
        }

    }
}