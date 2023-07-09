using BiletHackanton.Context;
using BiletHackanton.Models.Dtos.CategoryDto.Request;
using BiletHackanton.Models.Dtos.CategoryDto.Response;
using BiletHackanton.Models.Dtos.ImageDto.Request;
using BiletHackanton.Models.Dtos.ImageDto.Response;
using BiletHackanton.Models.Orm;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            List<GetAllImageResponseDto> responseDtos = db.Images.Select(q => new GetAllImageResponseDto()
            {
                ImageID = q.ImageID,
                EventID = q.EventID,
                PosterURL = q.PosterURL,
                ImageURL = q.ImageURL
            }).ToList();

            if (responseDtos.Count != 0)
            {
                return Ok(responseDtos);
            }
            else
            {
                return NotFound("Data not found");
            }
        }

        [HttpGet("card")]
        public IActionResult Getcard()
        {
            List<CardImageResponseDto> responseDtos = db.Images.Include(c => c.Event).Select(q => new CardImageResponseDto()
            {
                ImageID = q.ImageID,
                Title = q.Event.Title,
                Description = q.Event.Description,
                PosterURL = q.PosterURL,
                ImageURL = q.ImageURL
            }).ToList();

            if (responseDtos.Count != 0)
            {
                return Ok(responseDtos);
            }
            else
            {
                return NotFound("Data not found");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Image image = db.Images.FirstOrDefault(c => c.ImageID == id);

            if (image == null)
            {
                return NotFound(id + " User with id not found");
            }
            else
            {
                GetAllImageResponseDto response = new GetAllImageResponseDto();
                response.ImageID = image.ImageID;
                response.EventID = image.EventID;
                response.PosterURL = image.PosterURL;
                response.ImageURL = image.ImageURL;
                return Ok(response);
            }
        }


        [HttpPost]
        public IActionResult Post(CreateImageRequestDto createImage)
        {

            Image image = new Image();
            image.EventID = createImage.EventID;
            image.ImageURL = createImage.ImageURL;
            db.Images.Add(image);
            db.SaveChanges();
            return Ok(createImage);

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateImageRequestDto image)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");

            var result = db.Images.FirstOrDefault(p => p.ImageID == id);

            if (result != null)
            {
                result.EventID = image.EventID;
                result.PosterURL = image.PosterURL;
                result.ImageURL = image.ImageURL;
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
                PosterURL = c.PosterURL,
                ImageURL = c.ImageURL,
            }).ToList();
            return Ok(response);
        }





        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Image image = db.Images.FirstOrDefault(q => q.ImageID == id);

            if (image != null)
            {
                db.Images.Remove(image);
                db.SaveChanges();
                return Ok("Deleted");
            }
            else

                return NotFound("Image with id not found");


        }
    }
}
