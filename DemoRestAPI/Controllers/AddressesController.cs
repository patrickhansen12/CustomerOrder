using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DemoBLL.Facade;
using DemoBLL.BusinessObjects;
using Microsoft.AspNetCore.Cors;

namespace DemoRestAPI.Controllers
{
    [EnableCors("MyPolicy")]
    [Produces("application/json")]
    [Route("api/Addresses")]
    public class AddressesController : Controller
    {

        BLLFacade facade = new BLLFacade();

        [HttpGet]
        public IEnumerable<AddressBO> Get()
        {
            return facade.AddressService.GetAll();
        }

        [HttpPost]
        public IActionResult Post([FromBody]AddressBO address)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(facade.AddressService.Create(address));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]AddressBO address)
        {
            if (id != address.Id)
            {
                return StatusCode(405, "Path Id does not match Address Id in json object");
            }
            try
            {
                var addressUpdated = facade.AddressService.Update(address);
                return Ok(addressUpdated);
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            facade.AddressService.Delete(id);
        }
    }
}