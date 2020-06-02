using FJ.Data.EntityFrameworks;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FJ.Data.Repositories.Tables
{
    public class CategoryRepository : Repository<Category>
    {
        public CategoryRepository(DbContext db) : base(db) { }
    }
}
