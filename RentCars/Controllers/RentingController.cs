using Microsoft.AspNetCore.Mvc;
using RentCars.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RentCars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentingController : ControllerBase
    {
        // GET: api/<RentingController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<RentingController>/5
        [HttpGet("{id}")]
        public string Get(int id)//מחפש רכב ומציג אותו לפי ID
        {
            return "value";
        }

        // POST api/<RentingController>
        [HttpPost]
        //public void Post([FromBody] string value)
        public void Post(Car c)//-ליצור חדש ולהוסיף אותו להוסיף רכב להשכרה
        {
        }

        // PUT api/<RentingController>/5
        [HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        public void Put(Car c)//עדכון רכב שהושכר- לשנות סטטוס
        {
        }

        // DELETE api/<RentingController>/5
        [HttpDelete("{id}")]
        // public void Delete(int id)
        public void Delete(Orders o)
        {
        }
    }
}
