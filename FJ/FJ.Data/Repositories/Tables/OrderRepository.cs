using FJ.Data.EntityFrameworks;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FJ.Data.Repositories.Tables
{
    public class OrderRepository :Repository<Order>
    {
        public OrderRepository(DbContext db) : base(db) { }
    }
}
