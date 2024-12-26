using Microsoft.AspNetCore.Mvc;
using RentCars.Core.Entities;
using RentCars.Core.Interfaces;
using RentCars.Service.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RentCars.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService context)
        {
            _clientService = context;
        }
       
        // GET: api/<Client>
        [HttpGet]
        public ActionResult<List<Client>> Get()
        {
            return Ok(_clientService.Get());
        }

        // GET api/<Client>/5
        [HttpGet("{id}")]
        public Client Get(int id)
        {
            var client = _clientService.Get(id);
            if (client == null)
            {
                Console.WriteLine("User not found");
                return client;
            }
            return null;
        }

        // POST api/<Client>
        [HttpPost]
        //public void Post([FromBody] string value)
        public void Post([FromBody] Client c)
        {
            _clientService.Post(c);
        }

        // PUT api/<Client>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Client updatedClient)
        {
            Client client = Get(updatedClient.Id);
           if (client != null)
            {
                _clientService.UpdateClient(updatedClient);
                return Ok("Client updated successfully");
            }
            else
            {
                return NotFound("Client not found");
            }
        }

        // DELETE api/<Client>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                _clientService.Delete(id); // מסירה את הלקוח מהרשימה
            }
            catch
            {
                BadRequest();
            }
        }
    }
}
