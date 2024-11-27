using Microsoft.AspNetCore.Mvc;
using RentCars.Core.Entities;
using RentCars.Core.Interfaces;
using RentCars.Srevice.Services;

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
        private readonly ClientService _clientService;
        public ClientController(ClientService clientService)
        {
            _clientService = clientService;
        }
        // GET: api/<Client>
        [HttpGet]
        public ActionResult<List<Client>> Get()
        {
            return Ok(_clientService.Get());
        }

        // GET api/<Client>/5
        [HttpGet("{id}")]
        public ActionResult<Client> Get(int id)
        {
            var client = _clientService.Get(id);
            if (client == null)
            {
                return NotFound("User not found");
            }
            return Ok(client);
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
        public IActionResult Put(int id, [FromBody] Client updatedClient)
        {
            try
            {
                _clientService.UpdateClient(id, updatedClient);
                return NoContent();
            }
            catch (Exception)
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
            catch (Exception ex)
            {
                 BadRequest();
            }
        }
    }
}
