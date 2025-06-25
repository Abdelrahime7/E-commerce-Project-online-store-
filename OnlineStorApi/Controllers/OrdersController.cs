using Application.Services;
using Domain.entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStorAccess.Services;
using System.Threading.Tasks;

namespace OnlineStorApi.Controllers
{
    [Route("api/Orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {


        private readonly OrderService _orderService;

        public OrdersController(OrderService orderServices)
        {
            _orderService = orderServices;
        }

        [HttpGet("All", Name = "GetAllOrder")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<IEnumerable<Order>>> AllOrdersAsync()
        {

            var OrdersList = await _orderService.GettallAsync();
            if (OrdersList.Count() == 0)
            {
                return NotFound("No Orders Found");

            }
            return Ok(OrdersList);

        }

        [HttpGet("{ID}", Name = "GetOrderByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Order>> GetOrderByIDAsync(int ID)
        {
            if (ID > 1)
            {
                return BadRequest($"invalid {ID}");
            }

            // we retriev full Order here ,maybe we  need some of its method to do some logic
            var Order = await _orderService.GetByIDAsync(ID);

            if (Order is null)
            {
                return NotFound("No Order found");
            }
            else
            {

                return Ok(Order);
            }
        }

        [HttpPost(Name = "AddOrder")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Order>> AddOrderAsync(Order Order)
        {
            if (Order == null )

            {
                return BadRequest($"invalid Order Data ");
            }


            var OrderID =await _orderService.AddAsync(Order);


            if (OrderID != 0)
            {
                return CreatedAtRoute($"GetOrderByID", new { id = OrderID }, Order);
            }
            else
                return BadRequest($"Saving Failed  :( ");

        }


        [HttpPut("{ID}", Name = "UdateOrder")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Order>> UbdateOrderAsync(int ID, Order UpdatedOrder)
        {
            if (ID < 1 || UpdatedOrder == null )
            {
                return BadRequest($"invalid Data ");
            }


            var Order = await _orderService.GetByIDAsync(ID);



            if (Order != null)
            {

                UpdatedOrder.Id = Order.Id;

               await _orderService.UpdateAsync(UpdatedOrder);
                {
                    return Ok($"Order with ID = {ID} Updated Successfully ");
                }

            }
            return BadRequest($"invalid Order Data ");

        }


        [HttpDelete("{ID}", Name = "DeleteOrder")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeletOrderAsync(int ID)
        {

            if (ID < 1)
            {
                return BadRequest("Invalid ID");
            }
            var Order =await _orderService.GetByIDAsync(ID);

            if (Order != null)
            {

                if (await _orderService.DeleteAsync(ID))
                {
                    return Ok($"Order with ID = {ID} Deleted Successfully ");
                }

            }
            return BadRequest($" there is NO Order with ID = {ID} ");

        }
    }
}
