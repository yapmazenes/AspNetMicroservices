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
    public class CatalogService : ICatalogService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<CatalogService> _logger;

        public CatalogService(HttpClient httpClient, ILogger<CatalogService> logger)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<CatalogModel>> GetCatalog()
        {
            var response = await _httpClient.GetAsync("/api/v1/Catalog");

            return await response.ReadContentAs<IEnumerable<CatalogModel>>();
        }

        public async Task<CatalogModel> GetCatalog(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                _logger.LogError("CatalogId cannot be null or empty");
                throw new ArgumentException("CatalogId cannot be null or empty");
            }

            var response = await _httpClient.GetAsync($"/api/v1/Catalog/{id}");

            return await response.ReadContentAs<CatalogModel>();
        }

        public async Task<IEnumerable<CatalogModel>> GetCatalogByCategory(string category)
        {
            if (string.IsNullOrEmpty(category))
            {
                _logger.LogError("Category cannot be null or empty");
                throw new ArgumentException("Category cannot be null or empty");
            }

            var response = await _httpClient.GetAsync($"/api/v1/Catalog/GetProductByCategory/{category}");

            return await response.ReadContentAs<IEnumerable<CatalogModel>>();
        }
    }
}
