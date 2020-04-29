using NewsMan.Data.Data;
using NewsMan.Data.Interfaces;
using NewsMan.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NewsMan.Service.Services
{
    public class FeedService : IFeed
    {
        private readonly NewsManDbContext _context;
        public FeedService(NewsManDbContext context) { _context = context; }

        public void Add(Feed newFeed)
        {
            _context.Add(newFeed);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Feed.Where(g => g.Id == id)
               .ToList().ForEach(g => _context.Feed.Remove(g));
            _context.SaveChanges();
        }

        public Feed Get(int id)
        {
            return GetAll().FirstOrDefault(f => f.Id == id);
        }

        public IEnumerable<Feed> GetAll()
        {
            return _context.Feed;
        }

        public IEnumerable<Feed> GetAllByAuthor(string author)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Feed> GetAllByDate(DateTime pubDate)
        {
            return GetAll().Where(g => g.PublishedAt == pubDate);
        }

        public IEnumerable<Feed> GetAllBySessionId(string sessionId)
        {
            return GetAll().Where(g => g.SessionId == sessionId);
        }

        public IEnumerable<Feed> GetAllBySourceName(string sourceName)
        {
            return GetAll().Where(g => g.SourceName == sourceName);
        }

        public void Update(Feed newFeed)
        {
            throw new NotImplementedException();
        }
    }
}
