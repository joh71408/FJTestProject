using FJ.Data.EntityFrameworks;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FJ.Data.Repositories.Tables
{
    public class Order_DetailRepository : Repository<Order_Detail>
    {
        public Order_DetailRepository(DbContext db) : base(db) 
        { 
            
        }

        public IQueryable<Order_Detail> GetOrder_Detail(int OrderId)
        {
            return Entity.Where(p => p.OrderId == OrderId);
        }
    }
}
