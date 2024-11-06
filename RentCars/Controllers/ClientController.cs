﻿using Microsoft.AspNetCore.Mvc;
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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<Client>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Client>
        [HttpPost]
        //public void Post([FromBody] string value)
        public void Post(Client client)
        {
        }

        // PUT api/<Client>/5
        [HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        public void Put(Client c, string phone)//לעדכן טלפון
        {
        }

        // DELETE api/<Client>/5
        [HttpDelete("{id}")]
        public void Delete(int id)//מחפש לקוח לפי ID ומוחק
        {
        }
    }
}
