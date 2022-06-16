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
        [HttpGet("{productId}/{userId}")]
        public IActionResult GetOffer(string productId,string userId)
        {
            var offer = offerReadRepository.ReadOffer(productId, userId);
            return Ok(offer);
        }
        [HttpGet("useroffers/{userId}")]
        public IActionResult GetOfferList(string userId)
        {
            var offerList = offerReadRepository.OfferList(userId);
            return Ok(offerList);
        }
        [HttpGet("othersoffers/{userId}")]
        public IActionResult GetOthersOfferList(string userId)
        {
            return Ok(offerReadRepository.OthersOfferList(userId));
        }


        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Offer model)
        {
            offerWriteRepository.AddAsync(new()
            {
                UserId = Guid.Parse(model.UserId),
                ProductId = Guid.Parse(model.ProductId),
                Price=model.Price,
                IsActive=true,
                Status=0
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
            var deletedOffer=await offerWriteRepository.SaveAsync();
            if (deletedOffer > 0) return Ok();
            return BadRequest();
        }
        [HttpGet("approve/{id}")]
        public async Task<IActionResult> ApproveOffer(string id)
        {
            var offer = await offerReadRepository.GetByIdAsync(id, false);
            offer.Status = 1;
            var approvedOffer = await offerWriteRepository.SaveAsync();
            if (approvedOffer > 0) return Ok();
            return BadRequest();
        }
    }
}
