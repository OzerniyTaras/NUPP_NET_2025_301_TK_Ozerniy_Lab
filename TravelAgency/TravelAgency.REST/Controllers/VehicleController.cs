using Microsoft.AspNetCore.Mvc;
using TravelAgency.REST.Models;

namespace TravelAgency.REST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : ControllerBase
    {
        private static List<VehicleModel> vehicles = new();

        [HttpGet]
        public ActionResult<IEnumerable<VehicleModel>> GetAll()
        {
            return Ok(vehicles);
        }

        [HttpGet("{id}")]
        public ActionResult<VehicleModel> Get(Guid id)
        {
            var vehicle = vehicles.FirstOrDefault(x => x.Id == id);

            if (vehicle == null)
                return NotFound();

            return Ok(vehicle);
        }

        [HttpPost]
        public ActionResult Create(VehicleModel model)
        {
            model.Id = Guid.NewGuid();

            vehicles.Add(model);

            return CreatedAtAction(nameof(Get),
                new { id = model.Id },
                model);
        }

        [HttpPut]
        public ActionResult Update(VehicleModel model)
        {
            var vehicle = vehicles.FirstOrDefault(x => x.Id == model.Id);

            if (vehicle == null)
                return NotFound();

            vehicle.Name = model.Name;

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var vehicle = vehicles.FirstOrDefault(x => x.Id == id);

            if (vehicle == null)
                return NotFound();

            vehicles.Remove(vehicle);

            return Ok();
        }
    }
}