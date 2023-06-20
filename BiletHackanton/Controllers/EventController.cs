using BiletHackanton.Context;
using BiletHackanton.Models.Dtos.EventDto.Request;
using BiletHackanton.Models.Dtos.EventDto.Response;
using BiletHackanton.Models.Orm;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BiletHackanton.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : Controller
    {

        MyContext db;
        public EventController()
        {
            db = new MyContext();
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            List<GetAllEventsResponseDto> result = db.Events.Include(c => c.Category).Select(x => new GetAllEventsResponseDto()
            {
                EventID = x.EventID,
                CategoryID = x.CategoryID,
                CategoryName = x.Category.Name,
                Title = x.Title,
                Description = x.Description,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                VenueName = x.VenueName,
                Address = x.Address,
                GoogleMapsLink = x.GoogleMapsLink
            }).ToList();

            if (result.Count != 0)
            {
                return Ok(result);
            }
            else
            {
                return NotFound("Data not found");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Event eventy = db.Events.Include(c => c.Category).FirstOrDefault(c => c.EventID == id);

            if (eventy == null)
            {
                return NotFound(id + " User with id not found");
            }
            else
            {
                GetAllEventsResponseDto response = new GetAllEventsResponseDto();
                response.EventID = eventy.EventID;
                response.CategoryID = eventy.CategoryID;
                response.CategoryName = eventy.Category.Name;
                response.Title = eventy.Title;
                response.Description = eventy.Description;
                response.StartDate = eventy.StartDate;
                response.EndDate = eventy.EndDate;
                response.VenueName = eventy.VenueName;
                response.Address = eventy.Address;
                response.GoogleMapsLink = eventy.GoogleMapsLink;
                return Ok(response);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateEventRequestDto request)
        {
            Event eventy = new Event();
            eventy.CategoryID = request.CategoryID;
            eventy.Title = request.Title.ToLower();
            eventy.Description = request.Description.ToLower();
            eventy.StartDate = request.StartDate;
            eventy.EndDate = request.EndDate;
            eventy.VenueName = request.VenueName;
            eventy.Address = request.Address;
            eventy.GoogleMapsLink = request.GoogleMapsLink;

            db.Events.Add(eventy);
            db.SaveChanges();

            return Ok(request);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateEventRequestDto eventDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid data");
            }

            var result = db.Events.FirstOrDefault(p => p.EventID == id);

            if (result != null)
            {
                result.CategoryID = eventDto.CategoryID;
                result.Title = eventDto.Title;
                result.Description = eventDto.Description;
                result.StartDate = eventDto.StartDate;
                result.EndDate = eventDto.EndDate;
                result.VenueName = eventDto.VenueName;
                result.Address = eventDto.Address;
                result.GoogleMapsLink = eventDto.GoogleMapsLink;

                db.SaveChanges();
            }
            else
            {
                return NotFound();
            }

            List<GetAllEventsResponseDto> response = db.Events.Include(c => c.Category).Select(c => new GetAllEventsResponseDto
            {
                EventID = c.EventID,
                CategoryID = c.CategoryID,
                CategoryName = c.Category.Name,
                Title = c.Title,
                Description = c.Description,
                StartDate = c.StartDate,
                EndDate = c.EndDate,
                VenueName = c.VenueName,
                Address = c.Address,
                GoogleMapsLink = c.GoogleMapsLink,
            }).ToList();

            return Ok(response);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Event eventy = db.Events.FirstOrDefault(x => x.EventID == id);
            if (eventy != null)
            {
                db.Events.Remove(eventy);
                db.SaveChanges();
                return Ok("Deleted");
            }
            else
                return NotFound("Event with id not found");
        }





    }
}
