using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.REST.Models;

namespace TravelAgency.REST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private static List<TicketModel> tickets = new();

        [AllowAnonymous]
        [HttpGet]
        public ActionResult<IEnumerable<TicketModel>> GetAll()
        {
            return Ok(tickets);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult<TicketModel> Get(Guid id)
        {
            var ticket = tickets.FirstOrDefault(x => x.Id == id);

            if (ticket == null)
                return NotFound();

            return Ok(ticket);
        }

        [Authorize(Roles = "User,Manager,Admin")]
        [HttpPost]
        public ActionResult Create(TicketModel model)
        {
            model.Id = Guid.NewGuid();

            tickets.Add(model);

            return CreatedAtAction(nameof(Get),
                new { id = model.Id },
                model);
        }

        [Authorize(Roles = "Manager,Admin")]
        [HttpPut]
        public ActionResult Update(TicketModel model)
        {
            var ticket = tickets.FirstOrDefault(x => x.Id == model.Id);

            if (ticket == null)
                return NotFound();

            ticket.PassengerName = model.PassengerName;
            ticket.Price = model.Price;

            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var ticket = tickets.FirstOrDefault(x => x.Id == id);

            if (ticket == null)
                return NotFound();

            tickets.Remove(ticket);

            return Ok();
        }
    }
}