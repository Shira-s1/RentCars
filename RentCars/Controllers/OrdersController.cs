using Microsoft.AspNetCore.Mvc;
using RentCars.Core.DTOs;
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
        private readonly IOrdersService _rentingService;
        public OrdersController(IOrdersService context)
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
        public OrdersDTO Get(int orderNum)//מחפש רכב ומציג אותו לפי מספר הזמנה
        {
            var order = _rentingService.Get(orderNum);
            if (order == null)
            {
                Console.WriteLine("Car not found");
                return null;
            }
            return order;

        }

        //public ActionResult<OrdersDTO> Get(int orderNum) // מחפש רכב ומציג אותו לפי מספר הזמנה
        //{
        //    // מחפש את ההזמנה לפי מספר הזמנה
        //    var order = _rentingService.Get(orderNum);

        //    // אם לא נמצא רכב עם מספר הזמנה זה, מחזירים תשובת שגיאה עם קוד 404
        //    if (order == null)
        //    {
        //        return NotFound(new { ErrorMsg = "Order not found", StatusCode = 404 });
        //    }

        //    // אם נמצאה ההזמנה, מחזירים את ה-OrdersDTO
        //    return Ok(order); // מחזירים את האובייקט OrdersDTO
        //}

        // POST api/<RentingController>
        [HttpPost]
        public ActionResult Post([FromBody] Orders o)// ליצור הזמנה חדשה ולהוסיף לרשימת הזמנות
        {
            if (o == null)
            {
                return BadRequest("Invalid car data");
            }
            _rentingService.Post(o);
            return Ok();
        }

        // PUT api/<RentingController>/5
        [HttpPut("{id}")]

       
        public void Put([FromBody] OrdersDTO order)//עדכון הזמנה-שינוי פרטים
        {
            OrdersDTO updateOrder = Get(order.NumOrder);
            if (updateOrder != null)
                _rentingService.Put(updateOrder);

            else
                throw new Exception("Car not found");
        }


        //שיניתי את הכותרת הממשק שתקבל משתנה מסוג הזמנות דיטיאו
        // public void Put([FromBody] Orders order)//עדכון הזמנה- לשנות סטטוס
        //{
        //    OrdersDTO updateOrder = Get(order.NumOrder);
        //    if (updateOrder != null)
        //    {

        //        _rentingService.Put(updateOrder);
        //    }
        //    else
        //        throw new Exception("Car not found");

        //}




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
