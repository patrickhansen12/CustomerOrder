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
    [Route("api/[controller]")]
    public class AddressesController : Controller
    {

        BLLFacade facade = new BLLFacade();

        [HttpPost]
        public IActionResult Post([FromBody]AddressBO address)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(facade.AddressService.Create(address));
        }
    }
}