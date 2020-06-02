﻿using FJ.Data.EntityFrameworks;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FJ.Data.Repositories.Tables
{
    public class WineryRepository : Repository<Winery>
    {
        public WineryRepository(DbContext db) : base(db) { }
    }
}