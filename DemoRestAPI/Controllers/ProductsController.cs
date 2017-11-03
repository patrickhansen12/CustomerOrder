using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using DemoBLL.Facade;
using DemoBLL.BusinessObjects;

namespace DemoRestAPI.Controllers
{
    [EnableCors("MyPolicy")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        BLLFacade facade = new BLLFacade();
        // GET: api/values
        [HttpGet]
        public IEnumerable<ProductBO> Get()
        {
            return facade.ProductService.GetAll();
        }

        // GET
        [HttpGet("{id}")]
        public ProductBO Get(int id)
        {
            return facade.ProductService.Get(id);
        }

        // POST
        [HttpPost]
        public IActionResult Post([FromBody]ProductBO product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(facade.ProductService.Create(product));
        }

        // PUT
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]ProductBO product)
        {
            if (id != product.Id)
            {
                return StatusCode(405, "Path Id does not match Product Id in json object");
            }
            try
            {
                var productUpdated = facade.ProductService.Update(product);
                return Ok(productUpdated);
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
            facade.ProductService.Delete(id);
        }
    }
}