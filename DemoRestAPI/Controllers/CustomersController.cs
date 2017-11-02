using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using DemoBLL.Facade;
using DemoBLL.BusinessObjects;

namespace DemoRestAPI.Controllers
{
    [EnableCors("MyPolicy")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        BLLFacade facade = new BLLFacade();
        // GET: api/values
        [HttpGet]
        public IEnumerable<CustomerBO> Get()
        {
            return facade.CustomerService.GetAll();
        }

        // GET
        [HttpGet("{id}")]
        public CustomerBO Get(int id)
        {
            return facade.CustomerService.Get(id);
        }

        // POST
        [HttpPost]
        public IActionResult Post([FromBody]CustomerBO cust)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(facade.CustomerService.Create(cust));
        }

        // PUT
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]CustomerBO cust)
        {
            if (id != cust.Id)
            {
                return StatusCode(405, "Path Id does not match Customer Id in json object");
            }
            try
            {
                var customerUpdated = facade.CustomerService.Update(cust);
                return Ok(customerUpdated);
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }
        }

        // DELETE
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            facade.CustomerService.Delete(id);
        }
    }
}