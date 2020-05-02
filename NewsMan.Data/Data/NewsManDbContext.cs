using Microsoft.EntityFrameworkCore;
using NewsMan.Data.Models;

namespace NewsMan.Data.Data
{
    public class NewsManDbContext : DbContext
    {

        public NewsManDbContext(DbContextOptions<NewsManDbContext> options) : base(options)
        { }

        public DbSet<Feed> Feed { get; set; }
        public DbSet<QMaster> QMaster { get; set; }
        public DbSet<Survey> Survey { get; set; }
        public DbSet<AMaster> AMaster { get; set; }


        public DbSet<AnswerGroup> AnswerGroup { get; set; }
        public DbSet<AnswerOption> AnswerOption { get; set; }
        public DbSet<Result> Result { get; set; }
        public DbSet<Session> Session { get; set; }
        public DbSet<SurveyQuestion> SurveyQuestion { get; set; }
        public DbSet<SurveyMaster> SurveyMaster { get; set; }
        public DbSet<Question> Question { get; set; }

    }
}
