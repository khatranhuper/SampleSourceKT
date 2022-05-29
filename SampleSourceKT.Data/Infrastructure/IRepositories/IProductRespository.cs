using SampleSourceKT.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleSourceKT.Data.Infrastructure.IRepositories
{
    public interface IProductRespository
    {
        Task Insert(Product product);
    }
}
