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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET all /api/category
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var categories = await _categoryService.GetAll();
                if(categories == null)
                {
                    return Problem("Returned null, unexspected behavior!");
                }
                else if(categories.Count == 0)
                {
                    return NoContent();
                }
                return Ok(categories);
            }
            catch (Exception e)
            {
              return Problem(e.Message);
            } 
        }


        // POST /api/category

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> Create(Category category)
        {
            try
            {
                if (category == null)
                {
                    return BadRequest("Failed to create category!");
                }
                var newCategory = await _categoryService.Create(category);
                return Ok(newCategory);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // PUT /api/category

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> Update([FromRoute] int id, Category category)
        {
            try
            {
                var updateCategory = await _categoryService.Update(id, category);
                if (updateCategory == null)
                {
                    return NotFound("It was not possible to edit this category! Not Found");
                }
                return Ok(updateCategory);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // DELETE /api/category

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var deleteCategory = await _categoryService.Delete(id);
                if (deleteCategory == null)
                {
                    return NotFound("Category with id: " + id + " does not exist!");
                }
                return Ok(deleteCategory);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

    }
}
