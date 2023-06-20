using BiletHackanton.Context;
using BiletHackanton.Models.Dtos.CategoryDto.Request;
using BiletHackanton.Models.Dtos.CategoryDto.Response;
using BiletHackanton.Models.Dtos.EventDto.Response;
using BiletHackanton.Models.Orm;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BiletHackanton.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        MyContext db;
        public CategoryController()
        {
            db = new MyContext();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<GetAllCategoryResponseDto> categories = db.Categories.Select(q => new GetAllCategoryResponseDto()
            {
                CategoryId = q.CategoryId,
                Name = q.Name
            }).ToList();

            if (categories.Count != 0)
            {
                return Ok(categories);
            }
            else
            {
                return NotFound("Data not found");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Category category = db.Categories.FirstOrDefault(c => c.CategoryId == id);

            if (category == null)
            {
                return NotFound(id + " User with id not found");
            }
            else
            {
                GetAllCategoryResponseDto response = new GetAllCategoryResponseDto();
                response.CategoryId = category.CategoryId;
                response.Name = category.Name;
                return Ok(response);
            }
        }


        [HttpPost]
        public IActionResult Post(CreateCategoryRequestDto createCategory)
        {
            Category category = new Category();
            category.Name = createCategory.Name;
            db.Categories.Add(category);
            db.SaveChanges();

            return Ok(createCategory);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateCategoryRequestDto category)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");

            var result = db.Categories.FirstOrDefault(p => p.CategoryId == id);

            if (result != null)
            {
                result.Name = category.Name;
                db.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            List<GetAllCategoryResponseDto> response = db.Categories.Select(c => new GetAllCategoryResponseDto
            {
                CategoryId = c.CategoryId,
                Name = c.Name,

            }).ToList();
            return Ok(response);
        }





        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Category category = db.Categories.FirstOrDefault(q => q.CategoryId == id);

            if (category != null)
            {
                db.Categories.Remove(category);
                db.SaveChanges();
                return Ok("Deleted");
            }
            else

                return NotFound("Category with id not found");


        }


    }


}
