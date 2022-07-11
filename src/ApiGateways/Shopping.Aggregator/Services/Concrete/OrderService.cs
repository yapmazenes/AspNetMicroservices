using Microsoft.Extensions.Logging;
using Shopping.Aggregator.Extensions;
using Shopping.Aggregator.Models;
using Shopping.Aggregator.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Shopping.Aggregator.Services.Concrete
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<OrderService> _logger;

        public OrderService(HttpClient httpClient, ILogger<OrderService> logger)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<OrderResponseModel>> GetOrdersByUserName(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                _logger.LogError("userName cannot be null or empty");
                throw new ArgumentException("userName cannot be null or empty");
            }

            var response = await _httpClient.GetAsync($"/api/v1/Order/{userName}");

            return await response.ReadContentAs<IEnumerable<OrderResponseModel>>();
        }
    }
}
