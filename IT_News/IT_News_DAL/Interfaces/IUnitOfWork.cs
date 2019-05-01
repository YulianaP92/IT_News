﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IT_News_DAL.Entities;

namespace IT_News_DAL.Interfaces
{
    interface IUnitOfWork:IDisposable
    {
        IRepository<News> News { get; }
        void Save();
    }
}
