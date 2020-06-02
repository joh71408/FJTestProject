using FJ.Data.EntityFrameworks;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FJ.Data.Repositories.Tables
{
    public class AccountRepository : Repository<Account>
    {
        public AccountRepository(DbContext db) : base(db) { }
    }
}
