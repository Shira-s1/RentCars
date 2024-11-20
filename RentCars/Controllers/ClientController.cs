using Microsoft.AspNetCore.Mvc;
using RentCars.Entities;
using RentCars.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RentCars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IDataContext _dataContext;
        public ClientController(IDataContext context)
        {
            _dataContext = context;
        }
        // GET: api/<Client>
        [HttpGet]
        public IEnumerable<Client> Get()
        {
            return _dataContext.clientList;
        }

        // GET api/<Client>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var client1 = _dataContext.clientList.FirstOrDefault(t => t.Id == id);
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
            _dataContext.clientList.Add(c);
        }

        // PUT api/<Client>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Client c)
        {
            Client res = _dataContext.clientList.FirstOrDefault(c1 => c1.Id == c.Id);

            res = c;//לוודא שאכן משנה את הליסט 
        }

        // DELETE api/<Client>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var clientToDelete = _dataContext.clientList.FirstOrDefault(c => c.Id == id); 
            if (clientToDelete != null) { 
                _dataContext.clientList.Remove(clientToDelete); 
            }
        }
    }
}
