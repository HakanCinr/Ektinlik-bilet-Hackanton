using BiletHackanton.Context;
using BiletHackanton.Models.Dtos.CategoryDto.Request;
using BiletHackanton.Models.Dtos.CategoryDto.Response;
using BiletHackanton.Models.Dtos.ImageDto.Request;
using BiletHackanton.Models.Dtos.ImageDto.Response;
using BiletHackanton.Models.Orm;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BiletHackanton.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        MyContext db;
        public ImageController()
        {
            db = new MyContext();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<GetAllImageResponseDto> Images = db.Images.Select(q => new GetAllImageResponseDto()
            {
                ImageID = q.ImageID,
                EventID = q.EventID,
                ImageURL = q.ImageURL
            }).ToList();

            if (Images.Count != 0)
            {
                return Ok(Images);
            }
            else
            {
                return NotFound("Data not found");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Image Image = db.Images.FirstOrDefault(c => c.ImageID == id);

            if (Image == null)
            {
                return NotFound(id + " User with id not found");
            }
            else
            {
                GetAllImageResponseDto response = new GetAllImageResponseDto();
                response.ImageID = Image.ImageID;
                response.EventID = Image.EventID;
                response.ImageURL = Image.ImageURL;
                return Ok(response);
            }
        }


        [HttpPost]
        public IActionResult Post(CreateImageRequestDto createImage)
        {

            Image Image = new Image();
            Image.EventID = createImage.EventID;
            Image.ImageURL = createImage.ImageURL;
            db.Images.Add(Image);
            db.SaveChanges();
            return Ok(createImage);

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateImageRequestDto Image)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");

            var result = db.Images.FirstOrDefault(p => p.ImageID == id);

            if (result != null)
            {
                result.EventID = Image.EventID;
                result.ImageURL = Image.ImageURL;
                db.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            List<GetAllImageResponseDto> response = db.Images.Select(c => new GetAllImageResponseDto
            {
                ImageID = c.ImageID,
                EventID = c.EventID,
                ImageURL = c.ImageURL,
            }).ToList();
            return Ok(response);
        }





        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Image Image = db.Images.FirstOrDefault(q => q.ImageID == id);

            if (Image != null)
            {
                db.Images.Remove(Image);
                db.SaveChanges();
                return Ok("Deleted");
            }
            else

                return NotFound("Image with id not found");


        }
    }
}
