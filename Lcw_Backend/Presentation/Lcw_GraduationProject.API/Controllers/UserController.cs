using Lcw_GraduationProject.Application.Repositories.Users;
using Lcw_GraduationProject.Application.ViewModels.Users;
using Lcw_GraduationProject.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Lcw_GraduationProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly private IUserReadRepository userReadRepository;
        readonly private IUserWriteRepository userWriteRepository;

        public UserController(IUserReadRepository userReadRepository, IUserWriteRepository userWriteRepository)
        {
            this.userReadRepository = userReadRepository;
            this.userWriteRepository = userWriteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var datas = userReadRepository.GetAll(false).ToList();
            return Ok(datas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await userReadRepository.GetByIdAsync(id, false));
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(VM_Login_User user)
        {
            bool check = userReadRepository.GetByMailAsync(user,false);
            AccessToken token;
            if (check)
                return Ok(AccessToken.CreateAccessToken());
                
            return BadRequest("User Not Found!");
        }

        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_User model)
        {
            userWriteRepository.AddAsync(new()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Mail = model.Mail,
                Password = model.Password
            });

            await userWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPost]
        [Route("postlist")]
        public async Task<IActionResult> PostList(List<VM_Create_User> modelList)
        {
            foreach (var model in modelList)
            {
                userWriteRepository.AddAsync(new()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Mail = model.Mail,
                    Password = model.Password
                });
            }
            await userWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> Put(VM_Update_User model)
        {
            User user = await userReadRepository.GetByIdAsync(model.Id);
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Mail = model.Mail;
            user.Password = model.Password;
            await userWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await userWriteRepository.RemoveAsync(id);
            await userWriteRepository.SaveAsync();
            return Ok();
        }
    }
}
