using SampleSourceKT.Application.DTO;
using SampleSourceKT.Application.ServiceContracts.Products;
using SampleSourceKT.Data.EF;
using SampleSourceKT.Data.Entities;
using SampleSourceKT.Data.Infrastructure.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleSourceKT.Application.ApplicationServices
{
    public class ProductSerivces : IProductServices
    {
        private readonly IProductRespository _productRespository;
        public ProductSerivces(IProductRespository productRespository)
        {
            this._productRespository = productRespository;
        }

        public async Task<int> Create(CreateProductRequest request)
        {
            await _productRespository.Insert(new Product());
            return 1;
        }

    }

    //public class ProductSerivces : IProductServices
    //{
    //    public Task<int> Create(CreateProductRequest request)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
