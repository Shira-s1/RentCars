using Microsoft.AspNetCore.Mvc;
using RentCars.Entities;
using RentCars.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RentCars.Controllers
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
        // GET: api/<RentingController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<RentingController>/5
        [HttpGet("{id}")]
        public ActionResult<Car> Get(int id)//מחפש רכב ומציג אותו לפי ID
        {
            var car = _dataContext.carList.FirstOrDefault(c => c.Id == id);
            if (car == null)
            {
                return NotFound("Car not found");
            }
            return Ok(car);
        }

        // POST api/<RentingController>
        [HttpPost]
        //public void Post([FromBody] string value)
        public ActionResult Post(Car c)//-ליצור חדש ולהוסיף אותו להוסיף רכב להשכרה
        {
            if (c == null)
            {
                return BadRequest("Invalid car data");
            }
            _dataContext.carList.Add(c);
            return Ok();
        }

        // PUT api/<RentingController>/5
        [HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        public ActionResult Put(int id, [FromBody] Car c)//עדכון רכב שהושכר- לשנות סטטוס
        {
            var carToUpdate = _dataContext.carList.FirstOrDefault(c1 => c1.Id == id); 
            if (carToUpdate == null) {
                return NotFound("Car not found"); 
            }
            carToUpdate.Status = c.Status; 
            // משנה את הסטטוס לרכב שהושכר או אחר // ניתן להוסיף שדות נוספים לשינוי בהתאם לדרישות
             return Ok();
        }

        // DELETE api/<RentingController>/5
        [HttpDelete("{id}")]
        // public void Delete(int id)
        public void Delete(int numOrder)//מוחק לפי מספר הזמנה
        {
            var orderToDelete = _dataContext.orderList.FirstOrDefault(o => o.NumOrder == numOrder);
            if (orderToDelete != null) {
                _dataContext.orderList.Remove(orderToDelete);
            }
        }
    }
}
