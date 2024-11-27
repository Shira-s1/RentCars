using Microsoft.AspNetCore.Mvc;
using RentCars.Core.Entities;
using RentCars.Core.Interfaces;
using RentCars.Service.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RentCars.Core.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RentingController : ControllerBase
    {
        private readonly IDataContext _dataContext;
        public RentingController(IDataContext context)
        {
            _dataContext = context;
        }
        private readonly RentingService _rentingService;
        public RentingController(RentingService rentingService)
        { _rentingService = rentingService; }


        // GET: api/<RentingController>
        [HttpGet]
        public ActionResult<IEnumerable<Car>> Get()
        {
            var cars = _rentingService.Get();
            return Ok(cars);
        }

        // GET api/<RentingController>/5
        [HttpGet("{id}")]
        public ActionResult<Car> Get(int id)//מחפש רכב ומציג אותו לפי ID
        {
            var car = _rentingService.Get(id);
            if (car == null)
            {
                return NotFound("Car not found");
            }
            return Ok(car);
        }

        // POST api/<RentingController>
        [HttpPost]
        //public void Post([FromBody] string value)
        public ActionResult Post([FromBody] Car c)//-ליצור חדש ולהוסיף אותו להוסיף רכב להשכרה
        {
            if (c == null)
            {
                return BadRequest("Invalid car data");
            }
            _rentingService.Post(c);
            return Ok();
        }

        // PUT api/<RentingController>/5
        [HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        public ActionResult Put(int id, [FromBody] Car updatedCar)//עדכון רכב שהושכר- לשנות סטטוס
        {
            var carToUpdate = _rentingService.Get(id);
            if (carToUpdate == null)
            {
                return NotFound("Car not found");
            }
            _rentingService.Put(id, updatedCar);
            return NoContent();
        }

        // DELETE api/<RentingController>/5
        [HttpDelete("{id}")]
        // public void Delete(int id)
        public void Delete(int numOrder)//מוחק לפי מספר הזמנה
        {
            var orderToDelete = _dataContext.orderList.FirstOrDefault(o => o.NumOrder == numOrder);
            if (orderToDelete != null)
            {
                _rentingService.Delete(numOrder);
            }
        }
    }
}
