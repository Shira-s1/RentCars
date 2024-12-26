using Microsoft.AspNetCore.Mvc;
using RentCars.Core.Entities;
//using RentCars.Entities;
using RentCars.Core.Interfaces;
using RentCars.Service.Services;
using System.Diagnostics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RentCars.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarsController(ICarService context)
        {
            _carService = context;
        }

        // GET: api/<CarsController>
        [HttpGet]
        public ActionResult<List<Car>> Get()
        {
            // מחזירה את רשימת הרכבים
            List<Car> cars = _carService.GetCars();
           // if(cars == null)
             //   return NotFound();
            return Ok(cars);
        }


        // GET api/<CarsController>/5
        [HttpGet("{id}")]
        public Car Get(int id)
        {
            // מחפשת את הרכב הרצוי
            Car ans = _carService.GetSearch(id);
            if (ans == null)
                return null;
            return ans;
        }

        // POST api/<CarsController>
        [HttpPost]
        public void Post([FromBody] Car newCar)
        {
            if (newCar != null)
                // מוסיפה רכב חדש לרשימת הרכבים
                _carService.AddCar(newCar);
        }

        // PUT api/<CarsController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Car updatedCar)
        {
            Car car = _carService.GetSearch(updatedCar.Id);
            if (car != null)
            {
                _carService.UpdateCar(updatedCar); // מעדכנת את המידע של הרכב ברשימה
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE api/<CarsController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            try
            {
                _carService.Delete(id);// מסירה את הרכב מהרשימה
                return Ok(true);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
