﻿using NewsMan.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsMan.Data.Interfaces
{
    public interface IAMaster
    {
        IEnumerable<AMaster> GetAll();
        IEnumerable<AMaster> GetAllByKey(int key);
        string GetAnswerText(int key, int val);
        AMaster Get(int id);
        void Add(AMaster newAnswer);
        void Update(AMaster newAnswer);
        void Delete(int id);
    }
}
