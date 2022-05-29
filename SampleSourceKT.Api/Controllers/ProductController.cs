using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleSourceKT.Application.ServiceContracts.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleSourceKT.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productServices;

        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        [HttpPost("testAuthorize")]
        [Authorize(Roles = "Admin")]
        public  IActionResult TestAuthorize()
        {
            return Ok(1);
        }

        [HttpPost("testAuthorize2")]
        [Authorize(Roles = "User")]
        public IActionResult TestAuthorize2()
        {
            return Ok(1);
        }
    }
}
