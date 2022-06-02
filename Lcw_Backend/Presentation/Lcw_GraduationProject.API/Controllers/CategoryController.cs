using Lcw_GraduationProject.Application.Repositories.Categories;
using Lcw_GraduationProject.Application.ViewModels.Categories;
using Lcw_GraduationProject.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Lcw_GraduationProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        readonly private ICategoryReadRepository categoryReadRepository;
        readonly private ICategoryWriteRepository categoryWriteRepository;

        public CategoryController(ICategoryReadRepository categoryReadRepository, ICategoryWriteRepository categoryWriteRepository)
        {
            this.categoryReadRepository = categoryReadRepository;
            this.categoryWriteRepository = categoryWriteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var datas = categoryReadRepository.GetAll(false).ToList();
            return Ok(datas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await categoryReadRepository.GetByIdAsync(id, false));
        }

        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Category model)
        {
            categoryWriteRepository.AddAsync(new()
            {
                Name = model.Name,
                Description = model.Description
            });

            await categoryWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPost]
        [Route("postlist")]
        public async Task<IActionResult> PostList(List<VM_Create_Category> modelList)
        {
            foreach (var model in modelList)
            {
                categoryWriteRepository.AddAsync(new()
                {
                    Name = model.Name,
                    Description = model.Description
                });
            }

            await categoryWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> Put(VM_Update_Category model)
        {
            Category category = await categoryReadRepository.GetByIdAsync(model.Id);
            category.Name = model.Name;
            category.Description = model.Description;
            await categoryWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await categoryWriteRepository.RemoveAsync(id);
            await categoryWriteRepository.SaveAsync();
            return Ok();
        }
    }
}
