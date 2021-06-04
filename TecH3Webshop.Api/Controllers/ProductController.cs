using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Webshop.Api.Domain;
using TecH3Webshop.Api.Services;

namespace TecH3Webshop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET All /api/product

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var products = await _productService.GetAll();
                if (products == null)
                {
                    return Problem("Returned null, unexspected behavior.");
                }
                else if (products.Count == 0)
                {
                    return NoContent();
                }
                return Ok(products);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }

        }


        // GET By Id /api/product

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> Get([FromRoute] int id)
        {
            try
            {
                var product = await _productService.GetById(id);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }


        // POST /api/product

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> Create(Product product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest("Creation of Product failed!");
                }
                var newProduct = await _productService.Create(product);
                return Ok(newProduct);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }


        // PUT /api/product

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> Update([FromRoute] int id, Product product)
        {
            try
            {
                var updateProduct = await _productService.Update(id, product);

                if (updateProduct == null)
                {
                    return NotFound("Editing of product not possible, Product = null.");
                }
                return Ok(updateProduct);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }


        // DELETE /api/product

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var deleteProduct = await _productService.Delete(id);

                if (deleteProduct == null)
                {
                    return NotFound("Product with id: " + id + " does not exist");
                }
                return Ok(deleteProduct);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }

}

