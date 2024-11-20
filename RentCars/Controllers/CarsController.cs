using Microsoft.AspNetCore.Mvc;
using RentCars.Entities;
using RentCars.Interfaces;
using System.Diagnostics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RentCars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly IDataContext _dataContext;
        public CarsController(IDataContext context)
        {
            _dataContext = context;
        }

        // GET: api/<CarsController>
        [HttpGet]
        public ActionResult<List<Car>> Get()
        {
            // סופרת את מספר הרכבים הזמינים ברשימה
            int carsAvialible = _dataContext.carList.Count;

            return Ok(carsAvialible);
        }


        // GET api/<CarsController>/5
        [HttpGet("{id}")]
        public ActionResult<Car> Get(int id)
        {
            Car result = _dataContext.carList.FirstOrDefault(f => f.Id == id);// מחפשת רכב לפי מזהה
            if (result != null)
               return Ok(result);

            return NotFound();

        }

        // POST api/<CarsController>
        [HttpPost]
        public void Post([FromBody] Car newCar)
        {
            // מוסיפה רכב חדש לרשימת הרכבים
            _dataContext.carList.Add(newCar);
        }

        // PUT api/<CarsController>/5
        [HttpPut("{id}")]
        // public void Put(int id, [FromBody] string value)
        public void Put([FromBody] Car c)
        {
            Car newCar = _dataContext.carList.FirstOrDefault(f1 => f1.Id == c.Id);
            newCar = c;// מעדכנת את המידע של הרכב ברשימה
        }

        // DELETE api/<CarsController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(Car car)
        {
            try
            {
                _dataContext.carList.Remove(car);// מסירה את הרכב מהרשימה
                return Ok(true);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
