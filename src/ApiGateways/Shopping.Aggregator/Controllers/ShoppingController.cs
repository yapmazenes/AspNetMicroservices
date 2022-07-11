using Microsoft.AspNetCore.Mvc;
using Shopping.Aggregator.Models;
using Shopping.Aggregator.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Aggregator.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ShoppingController : ControllerBase
    {
        private readonly ICatalogService _catalogService;
        private readonly IBasketService _basketService;
        private readonly IOrderService _orderService;

        public ShoppingController(ICatalogService catalogService, IBasketService basketService, IOrderService orderService)
        {
            _catalogService = catalogService ?? throw new ArgumentNullException(nameof(catalogService));
            _basketService = basketService ?? throw new ArgumentNullException(nameof(basketService));
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
        }

        [HttpGet("{userName}", Name = "GetShopping")]
        [ProducesResponseType(typeof(ShoppingModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingModel>> GetShopping(string userName)
        {
            //Get Basket with userName
            //iterate basket Items and consume products with basket item productId member
            //map product related members into basketItem dto with extended columns
            //consume ordering microservices in order to retrieve order list
            //return root ShoppingModel dto class which including all responses

            var shoppingModel = new ShoppingModel
            {
                UserName = userName,
            };

            var userBasket = await _basketService.GetBasket(userName);

            if (userBasket != null)
            {
                foreach (var item in userBasket.Items)
                {
                    var product = await _catalogService.GetCatalog(item.ProductId);

                    //set additional Product fields onto basket item
                    item.ProductName = product.Name;
                    item.Category = product.Category;
                    item.Summary = product.Summary;
                    item.Description = product.Description;
                    item.ImageFile = product.ImageFile;
                }

                var orders = await _orderService.GetOrdersByUserName(userName);

                shoppingModel.BasketWithProducts = userBasket;
                shoppingModel.Orders = orders;
            }

            return Ok(shoppingModel);
        }

    }
}
