using NewsMan.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsMan.Data.Interfaces
{
    public interface ISessionUser
    {
        IEnumerable<Session> GetAll();
        Session Get(int id);
        void Add(Session newSession);
        void Update(Session newSession);
        void Delete(int id);
    }
}
