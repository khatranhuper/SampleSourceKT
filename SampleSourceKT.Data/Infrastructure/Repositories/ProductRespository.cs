using SampleSourceKT.Data.EF;
using SampleSourceKT.Data.Entities;
using SampleSourceKT.Data.Infrastructure.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleSourceKT.Data.Infrastructure.Repositories
{
    public class ProductRespository : IProductRespository
    {
        private readonly SampleSourceKTDbContext _context;

        public ProductRespository(SampleSourceKTDbContext context)
        {
            _context = context;
        }

        public async Task Insert(Product product)
        {

            _context.Products.Add(product);
            var data = _context.Products.Where(t => t.Id == 1);
            await _context.SaveChangesAsync();
        }
    }
}
