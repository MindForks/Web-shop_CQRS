using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using WS_Core.Domain.Models;
using WS_Core.Domain.Queries;

namespace WS_Core.Api.Controllers
{
    public class ProductController : ApiControllerBase
    {

        public ProductController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Product), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Product>> GetCustomerAsync(string id)
        {
            return Single(await QueryAsync(new GetProductrQuery(new ObjectId(id))));
        }

        // GET: api/Products
        //public IQueryable<Product> GetProducts()
        //{
        //    return _productService.GetAll();
        //}

        // GET: api/Products/5
        //[ResponseType(typeof(Product))]
        //public async Task<IHttpActionResult> GetProductAsync(string id)
        //{
        //    id = "5cf7cf16030c38386810198d";
        //    var query = new GetProductrQuery(new ObjectId(id));
        //    return Ok(await _mediator.Send(query));
        //}

        // PUT: api/Products/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutProduct(string id) //Product product)
        //{
        //    //product.Id = new ObjectId(id);
        //    //_productService.Update(product);

        //    //try
        //    //{
        //    //    product.Id = new ObjectId(id);
        //    //    _productService.Update(product);
        //    //}
        //    //catch (DbUpdateConcurrencyException)
        //    //{
        //    //    if (_productService.GetById(new ObjectId(id)) != null)
        //    //    {
        //    //        return NotFound();
        //    //    }
        //    //    else
        //    //    {
        //    //        throw;
        //    //    }
        //    //}

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/Products
        //// [ResponseType(typeof(Product))]
        //public IHttpActionResult PostProduct()//Product product)
        //{
        //    //if (!ModelState.IsValid)
        //    //{
        //    //    return BadRequest(ModelState);
        //    //}
        //    //_productService.Create(product);
        //    return Ok();
        //}

        //// DELETE: api/Products/5
        ////  [ResponseType(typeof(Product))]
        //public IHttpActionResult DeleteProduct(string id)
        //{
        //    //var product = _productService.GetById(new ObjectId(id));
        //    //if (product == null)
        //    //{
        //    //    return NotFound();
        //    //}
        //    //_productService.Delete(new ObjectId(id));
        //    return Ok();
        //}

    }
}
