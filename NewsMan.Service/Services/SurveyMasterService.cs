using NewsMan.Data.Data;
using NewsMan.Data.Interfaces;
using NewsMan.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NewsMan.Service.Services
{
    public class SurveyMasterService : ISurveyMaster
    {
        private readonly NewsManDbContext _context;
        public SurveyMasterService(NewsManDbContext context) { _context = context; }

        public void Add(SurveyMaster newSurveyMaster)
        {
            _context.Add(newSurveyMaster);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.SurveyMaster.Where(g => g.Id == id)
               .ToList().ForEach(g => _context.SurveyMaster.Remove(g));
            _context.SaveChanges();
        }

        public SurveyMaster Get(int id)
        {
            return GetAll().FirstOrDefault(f => f.Id == id);
        }

        public IEnumerable<SurveyMaster> GetAll()
        {
            return _context.SurveyMaster;
        }

        public void Update(SurveyMaster newSurveyMaster)
        {
            throw new NotImplementedException();
        }
    }
}
