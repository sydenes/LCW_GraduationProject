using Lcw_GraduationProject.Application.Repositories.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lcw_GraduationProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly private IProductReadRepository productReadRepository;
        readonly private IProductWriteRepository productWriteRepository;

        public ProductController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            this.productReadRepository = productReadRepository;
            this.productWriteRepository = productWriteRepository;
        }

        [HttpGet]
        public async void Get()
        {
            await productWriteRepository.AddRangeAsync(new()
            {
                new() { Id=Guid.NewGuid(), Name="Product 1",Price=100,Stock=20},
                new() { Id=Guid.NewGuid(), Name="Product 2",Price=200,Stock=40 },
                new() { Id=Guid.NewGuid(), Name="Product 3",Price=300,Stock=60 }
            });
            await productWriteRepository.SaveAsync();
        }
    }
}
