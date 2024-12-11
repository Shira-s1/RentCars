using Microsoft.AspNetCore.Mvc;
using RentCars.Core.Entities;
using RentCars.Core.Interfaces;
using RentCars.Service.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RentCars.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RentingController : ControllerBase
    {
        private readonly IRentingService _rentingService;
        public RentingController(IRentingService context)
        {
            _rentingService = context;
        }

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

        //לשאול - תמיד מדפיס שגיאה!
        public ActionResult Put(int id, [FromBody] Car updatedCar)//עדכון רכב שהושכר- לשנות סטטוס
        {
            try
            {
                _rentingService.Put(id, updatedCar);
                return Ok("Car updated successfully");
            }
            catch (Exception)
            {
                return NotFound("Car not found");
            }
        }
      
        //איך רואים את המחיקה אם מספר ההזמנה הוא אקראי?
        // DELETE api/<RentingController>/5
        [HttpDelete("{id}")]
        // public void Delete(int id)
        public void Delete(int numOrder)//מוחק לפי מספר הזמנה
        {
            var orderToDelete = _rentingService.Get(numOrder);//מציג את הרכב
            if (orderToDelete != null)
            {
                _rentingService.Delete(numOrder);
            }
           
        }
        
        
    }
}
