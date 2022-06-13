using Lcw_GraduationProject.Application.Repositories.Offers;
using Lcw_GraduationProject.Application.Repositories.Users;
using Lcw_GraduationProject.Application.ViewModels.Offers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lcw_GraduationProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly IOfferReadRepository offerReadRepository;
        private readonly IOfferWriteRepository offerWriteRepository;
        readonly private IUserReadRepository userReadRepository;

        public OfferController(IOfferReadRepository offerReadRepository, IOfferWriteRepository offerWriteRepository, IUserReadRepository userReadRepository)
        {
            this.offerReadRepository = offerReadRepository;
            this.offerWriteRepository = offerWriteRepository;
            this.userReadRepository = userReadRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var datas = offerReadRepository.GetAll(false).ToList();
            return Ok(datas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await offerReadRepository.GetByIdAsync(id, false));
        }


        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Offer model)
        {
            offerWriteRepository.AddAsync(new()
            {
                UserId = Guid.Parse(model.UserId),
                ProductId = Guid.Parse(model.ProductId),
                Price=model.Price,
                IsActive=true
            });

            await offerWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPost]
        [Route("postlist")]
        public async Task<IActionResult> PostList(List<VM_Create_Offer> modelList)
        {
            foreach (var model in modelList)
            {
                offerWriteRepository.AddAsync(new()
                {
                    UserId = Guid.Parse(model.UserId),
                    ProductId = Guid.Parse(model.ProductId),
                    Price = model.Price,
                    IsActive = true
                });
            }
            await offerWriteRepository.SaveAsync();
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
            //await _offerWriteRepository.RemoveAsync(id);
            //Silmek yerine IsActive=false
            var offer=await offerReadRepository.GetByIdAsync(id, false);
            offer.IsActive = false;
            await offerWriteRepository.SaveAsync();
            return Ok();
        }
    }
}
