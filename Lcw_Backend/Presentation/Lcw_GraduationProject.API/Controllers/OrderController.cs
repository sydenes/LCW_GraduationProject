using Lcw_GraduationProject.Application.Repositories.Orders;
using Lcw_GraduationProject.Application.Repositories.Products;
using Lcw_GraduationProject.Application.ViewModels.Orders;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Lcw_GraduationProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderReadRepository orderReadRepository;
        private readonly IOrderWriteRepository orderWriteRepository;
        readonly private IProductReadRepository productReadRepository;

        public OrderController(IOrderReadRepository orderReadRepository, IOrderWriteRepository orderWriteRepository, IProductReadRepository productReadRepository)
        {
            this.orderReadRepository = orderReadRepository;
            this.orderWriteRepository = orderWriteRepository;
            this.productReadRepository = productReadRepository;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var datas = orderReadRepository.GetAll(false).ToList();
            return Ok(datas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await orderReadRepository.GetByIdAsync(id, false));
        }

        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Order model)
        {
            orderWriteRepository.AddAsync(new()
            {
                Address = model.Address,
                Description = model.Description,
                ProductId = Guid.Parse(model.ProductId),
                UserId = Guid.Parse(model.UserId),
                OrderPrice=model.OrderPrice
            });

            var product = await productReadRepository.GetByIdAsync(model.ProductId);
            product.IsSold = true;
            await orderWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPost]
        [Route("postlist")]
        public async Task<IActionResult> PostList(List<VM_Create_Order> modelList)
        {
            foreach (var model in modelList)
            {
                orderWriteRepository.AddAsync(new()
                {
                    Address = model.Address,
                    Description = model.Description,
                    ProductId = Guid.Parse(model.ProductId),
                    UserId = Guid.Parse(model.UserId)
                });
            }
            await orderWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }

        //[HttpPut]
        //public async Task<IActionResult> Put(VM_Update_Offer model)
        //{
        //    //Şimdilik sadece teklifi geri çekiyor. Sonrasında teklif güncelle ile 'Price' değeri güncellenecek.
        //    return Ok();
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var deletedOffer =await orderWriteRepository.RemoveAsync(id);
            if (deletedOffer) return Ok();
            return BadRequest();
        }
    }
}
