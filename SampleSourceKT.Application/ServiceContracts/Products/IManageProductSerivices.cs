using SampleSourceKT.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleSourceKT.Application.ServiceContracts.Products
{
    public interface IManageProductSerivices
    {
        int UpdateProduct(UpdateProductRequest request);
    }
}
