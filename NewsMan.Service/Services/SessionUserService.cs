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
    public class SessionUserService : ISessionUser
    {
        private readonly NewsManDbContext _context;
        public SessionUserService(NewsManDbContext context) { _context = context; }

        public void Add(Session newSession)
        {
            _context.Add(newSession);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Session.Where(g => g.Id == id)
               .ToList().ForEach(g => _context.Session.Remove(g));
            _context.SaveChanges();
        }

        public Session Get(int id)
        {
            return GetAll().FirstOrDefault(f => f.Id == id);
        }

        public IEnumerable<Session> GetAll()
        {
            return _context.Session
                .Include(s => s.SurveyMaster);
        }

        public void Update(Session newSession)
        {
            throw new NotImplementedException();
        }
    }
}
