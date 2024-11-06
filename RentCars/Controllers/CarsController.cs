using Microsoft.AspNetCore.Mvc;
using RentCars.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RentCars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        static List<Car> cars = new List<Car>() {
            new Car() { Id = 1, status = Enum.RentStatus.Available, CompanyId = 1 },
            new Car() { Id = 2, status = Enum.RentStatus.Rented, CompanyId = 4 },
            new Car() { Id = 3, status = Enum.RentStatus.Available, CompanyId = 6 },
            new Car() { Id = 4, status = Enum.RentStatus.UnderRepair, CompanyId = 1 }
        };

        // GET: api/<CarsController>
        [HttpGet]
        public ActionResult<List<Car>> Get()
        {
            int carsAvialible = cars.Count;

            return Ok(cars);
        }

        // GET api/<CarsController>/5
        [HttpGet("{id}")]
        public ActionResult<Car> Get(int id)
        {
            Car result = cars.FirstOrDefault(f => f.Id == id);
            if (result != null)
                return Ok(result);

            return NotFound();

        }

        // POST api/<CarsController>
        [HttpPost]
        public void Post([FromBody] Car newCar)
        {
            cars.Add(newCar);
        }

        // PUT api/<CarsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CarsController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(Car car)
        {
            try
            {
                cars.Remove(car);
                return Ok(true);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
