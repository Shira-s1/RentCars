using Microsoft.AspNetCore.Mvc;
using RentCars.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RentCars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        // GET: api/<Client>
        [HttpGet]
        public IEnumerable<Client> Get()
        {
            return DataContext.clientList;
        }

        // GET api/<Client>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var client1 = DataContext.clientList.FirstOrDefault(t => t.Id == id);
            if (client1 == null)
            {
                return "User not found";
            }

            return "value";
        }

        // POST api/<Client>
        [HttpPost]
        //public void Post([FromBody] string value)
        public void Post([FromBody] Client c)
        {
            DataContext.clientList.Add(c);
        }

        // PUT api/<Client>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Client c)
        {
            Client res = DataContext.clientList.FirstOrDefault(c1=>c1.Id==c.Id);
            res = c;//לוודא שאכן משנה את הליסט 
        }

        // DELETE api/<Client>/5
        [HttpDelete("{id}")]
        public void Delete(Client c)
        {
            DataContext.clientList.Remove(c);
        }
    }
}
