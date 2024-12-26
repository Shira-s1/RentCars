using Microsoft.AspNetCore.Mvc;
using RentCars.Core.Entities;
using RentCars.Core.Interfaces;
using RentCars.Service.Services;
using System.Xml.Linq;

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
        public Car Get(int id)//מחפש רכב ומציג אותו לפי ID
        {
            var car = _rentingService.Get(id);
            if (car == null)
            {
                Console.WriteLine("Car not found");
                return null;
            }
            return car;
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
        //להוריד את האיידי ולהשוות את כל הערכים שקיימים באובייקט אחד אחד- אפשר לחפש בפרוייקטים קודמים- לעשות את זה ם בשאר הפרוייקטים!
        //ואז לעשות את מה שהמורה עשתה עם השמירת שינויים
        public void Put([FromBody] Car updatedCar)//עדכון רכב שהושכר- לשנות סטטוס
        {
            Car car = Get(updatedCar.Id);
            if (car != null) { 
 
                //car.LicensePlate = updatedCar.LicensePlate;
                //car.Id = updatedCar.Id;
                //car.Cname = updatedCar.Cname;
                //car.Name = updatedCar.Name;
                //car.Status = updatedCar.Status;
                //car.Price = updatedCar.Price;
                //car.Model = updatedCar.Model;

                //לקרוא לפונקציה של סרוויס
                _rentingService.Put(car);
            } 
            else 
           
                throw new Exception("Car not found"); 

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
