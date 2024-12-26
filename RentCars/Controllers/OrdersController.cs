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
    public class OrdersController : ControllerBase
    {
        private readonly IRentingService _rentingService;
        public OrdersController(IRentingService context)
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
        public Orders Get(int orderNum)//מחפש רכב ומציג אותו לפי מספר הזמנה
        {
            var order = _rentingService.Get(orderNum);
            if (order == null)
            {
                Console.WriteLine("Car not found");
                return null;
            }
            return order;
        }

        // POST api/<RentingController>
        [HttpPost]
        public ActionResult Post([FromBody] Car c)//wrong  -ליצור חדש ולהוסיף אותו להוסיף רכב להשכרה
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

        //לשאול - תמיד מדפיס שגיאה!
        public void Put([FromBody] Orders order)//עדכון הזמנה- לשנות סטטוס
        {
            Orders updateOrder = Get(order.NumOrder);
            if (updateOrder != null) { 

                _rentingService.Put(updateOrder);
            } 
            else 
                throw new Exception("Car not found"); 

        }
        //איך רואים את המחיקה אם מספר ההזמנה הוא אקראי?
        // DELETE api/<RentingController>/5
        [HttpDelete("{id}")]
        public void Delete(int numOrder)//מוחק לפי מספר הזמנה wrong!
        {
            var orderToDelete = _rentingService.Get(numOrder);//מציג את הרכב
            if (orderToDelete != null)
            {
                _rentingService.Delete(numOrder);
            }
            else throw new Exception("Order not found");
        }
        
        
    }
}
