using NewsMan.Data.Models;
using System.Collections.Generic;

namespace NewsMan.Data.Interfaces
{
    public interface IQMaster
    {
        IEnumerable<QMaster> GetAll();
        IEnumerable<QMaster> GetAllByLevel(int level);
        IEnumerable<QMaster> GetAllWithAns(int level);
        QMaster Get(int id);
        void Add(QMaster newFeed);
        void Update(QMaster newFeed);
        void Delete(int id);
    }
}
