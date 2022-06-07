using Lcw_GraduationProject.Application.Repositories.Products;
using Lcw_GraduationProject.Application.ViewModels.Products;
using Lcw_GraduationProject.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        [Authorize]
        public async Task<IActionResult> Get()
        {
            var datas = productReadRepository.GetAll(false).ToList();
            var a = 111;
            return Ok(datas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await productReadRepository.GetByIdAsync(id, false));
        }

        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Product model)
        {
            productWriteRepository.AddAsync(new()
            {
                Name = model.Name,
                Price=model.Price,
                CategoryId=Guid.Parse(model.CategoryId),
                UserId=Guid.Parse(model.UserId)
            });
            await productWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> Put(VM_Update_Product model)
        {
            Product product = await productReadRepository.GetByIdAsync(model.Id);
            product.Name = model.Name;
            product.Price = model.Price;
            await productWriteRepository.SaveAsync(); //tracking mekanizması çalışacağından bunu update olarak işleyecek. Mevcut update metotu tracking olmadığı yani verinin context aracılığı ile db den gelmediği durumlarda kullanılır.
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await productWriteRepository.RemoveAsync(id);
            await productWriteRepository.SaveAsync();
            return Ok();
        }
    }
}
