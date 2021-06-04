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
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;
        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        // GET all /api/brand

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var brands = await _brandService.GetAll();
                if (brands == null)
                {
                    return Problem("Returned null, unexspected behavior!");
                }
                else if (brands.Count == 0)
                {
                    return NoContent();
                }
                return Ok(brands);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // GET /api/brand

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            try
            {
                var brand = await _brandService.GetById(id);
                if (brand == null)
                {
                    return NotFound();
                }
                return Ok(brand);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // POST /api/brand

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(Brand brand)
        {
            try
            {
                if (brand == null)
                {
                    return BadRequest("Creation of Brand failed!");
                }
                var newBrand = await _brandService.Create(brand);
                return Ok(newBrand);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // PUT /api/brand

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> Update([FromRoute] int id, Brand brand)
        {
            try
            {
                var updateBrand = await _brandService.Update(id, brand);

                if (updateBrand == null)
                {
                    return NotFound("Editing of brand not possible, Brand = null!");
                }
                return Ok(updateBrand);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // DELETE /api/brand

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var deleteBrand = await _brandService.Delete(id);

                if (deleteBrand == null)
                {
                    return NotFound("Brand with id: " + id + " does not exist");
                }
                return Ok(deleteBrand);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}
