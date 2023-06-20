using BiletHackanton.Context;
using BiletHackanton.Models.Dtos.TicketDto.Request;
using BiletHackanton.Models.Dtos.TicketDto.Response;
using BiletHackanton.Models.Orm;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BiletHackanton.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        MyContext db;
        public TicketController()
        {
            db = new MyContext();
        }




        [HttpGet]
        public IActionResult GetAll()
        {
            List<GetAllTicketResponsDto> tickets = db.Ticket.Include(q => q.Event).Select(t => new GetAllTicketResponsDto
            {
                TicketID = t.TicketID,
                EventID = t.EventID,
                Title = t.Event.Title,
                SeatNumber = t.SeatNumber,
                Price = t.Price
            }).ToList();
            if (tickets.Count != 0)
            {
                return Ok(tickets);
            }
            else
            {
                return NotFound("Data not found");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Ticket ticket = db.Ticket.Include(q => q.Event).FirstOrDefault(q => q.TicketID == id);
            if (ticket == null)
                return NotFound();

            GetAllTicketResponsDto response = new GetAllTicketResponsDto
            {
                TicketID = ticket.TicketID,
                EventID = ticket.EventID,
                Title = ticket.Event.Title,
                SeatNumber = ticket.SeatNumber,
                Price = ticket.Price
            };

            return Ok(response);
        }

        [HttpPost]
        public IActionResult Post(CreateTicketRequestDto ticketDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");

            Ticket ticket = new Ticket
            {
                EventID = ticketDto.EventID,
                SeatNumber = ticketDto.SeatNumber,
                Price = ticketDto.Price
            };

            db.Ticket.Add(ticket);
            db.SaveChanges();
            List<GetAllTicketResponsDto> response = db.Ticket.Include(c => c.Event).Select(c => new GetAllTicketResponsDto
            {
                TicketID = c.TicketID,
                EventID = c.EventID,
                Title = c.Event.Title,
                SeatNumber = c.SeatNumber,
                Price = c.Price
            }).ToList();
            return Ok(response);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateTicketRequestDto ticketDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");

            Ticket ticket = db.Ticket.FirstOrDefault(q => q.TicketID == id);

            if (ticket != null)
            {
                ticket.EventID = ticketDto.EventID;
                ticket.SeatNumber = ticketDto.SeatNumber;
                ticket.Price = ticketDto.Price;
                db.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            List<GetAllTicketResponsDto> response = db.Ticket.Include(c => c.Event).Select(c => new GetAllTicketResponsDto
            {
                TicketID = c.TicketID,
                EventID = c.EventID,
                Title = c.Event.Title,
                SeatNumber = c.SeatNumber,
                Price = c.Price
            }).ToList();
            return Ok(response);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Ticket ticket = db.Ticket.FirstOrDefault(q => q.TicketID == id);

            if (ticket != null)
            {
                db.Ticket.Remove(ticket);
                db.SaveChanges();
                return Ok("Deleted");
            }
            else
            {
                return BadRequest("not found");
            }



        }

    }

}
