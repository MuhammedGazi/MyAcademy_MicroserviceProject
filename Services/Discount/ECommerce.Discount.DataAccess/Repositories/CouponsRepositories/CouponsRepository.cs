using ECommerce.Discount.DataAccess.Context;
using ECommerce.Discount.DataAccess.Repositories.GenericRepositories;
using ECommerce.Discount.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Discount.DataAccess.Repositories.CouponsRepositories
{
    public class CouponsRepository : GenericRepository<Coupon>, ICouponsRepository
    {
        public CouponsRepository(AppDbContext _context) : base(_context)
        {
        }
    }
}
