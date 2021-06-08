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
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService;
        public OrderDetailsController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        // GET all /api/orderdetail

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var orderDetails = await _orderDetailService.GetAll();
                if (orderDetails == null)
                {
                    return Problem("Returned null, unexspected behavior!");
                }
                else if (orderDetails.Count == 0)
                {
                    return NoContent();
                }
                return Ok(orderDetails);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // GET /api/orderdetail

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            try
            {
                var orderDetail = await _orderDetailService.GetById(id);
                if (orderDetail == null)
                {
                    return NotFound();
                }
                return Ok(orderDetail);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
        // ++++ COMMENTED OUT TEMP ++++ 
        //// POST /api/orderdetail

        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> Create(OrderDetail orderDetail)
        //{
        //    try
        //    {
        //        if (orderDetail == null)
        //        {
        //            return BadRequest("Creation of Order Detail failed!");
        //        }
        //        var newOrderDetail = await _orderDetailService.Create(orderDetail);
        //        return Ok(newOrderDetail);
        //    }
        //    catch (Exception e)
        //    {
        //        return Problem(e.Message);
        //    }
        //}

        // PUT /api/orderdetail

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> Update([FromRoute] int id, OrderDetail orderDetail)
        {
            try
            {
                var updateOrderDetail = await _orderDetailService.Update(id, orderDetail);

                if (updateOrderDetail == null)
                {
                    return NotFound("Editing of order detail not possible, Brand = null!");
                }
                return Ok(updateOrderDetail);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // DELETE /api/orderdetail

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var deleteOrderDetail = await _orderDetailService.Delete(id);

                if (deleteOrderDetail == null)
                {
                    return NotFound("Order Detail with id: " + id + " does not exist");
                }
                return Ok(deleteOrderDetail);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}
