using AspnetRunBasics.Extensions;
using AspnetRunBasics.Models;
using AspnetRunBasics.Services.Abstracts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AspnetRunBasics.Services.Concretes
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

        public async Task<IEnumerable<CatalogModel>> GetCatalogs()
        {
            _logger.LogInformation("Getting Catalog Products from url: {url} and the custom property: {customProperty}", _httpClient.BaseAddress, 6);

            var response = await _httpClient.GetAsync("/Catalog");

            return await response.ReadContentAs<IEnumerable<CatalogModel>>();
        }

        public async Task<CatalogModel> GetCatalog(string id)
        {
            var response = await _httpClient.GetAsync($"/Catalog/{id}");

            return await response.ReadContentAs<CatalogModel>();
        }

        public async Task<IEnumerable<CatalogModel>> GetCatalogsByCategory(string category)
        {
            var response = await _httpClient.GetAsync($"/Catalog/GetProductByCategory/{category}");

            return await response.ReadContentAs<IEnumerable<CatalogModel>>();
        }

        public async Task<CatalogModel> CreateCatalog(CatalogModel model)
        {
            var response = await _httpClient.PostAsJson("/Catalog", model);

            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<CatalogModel>();
            else
            {
                throw new Exception("Something went wrong when calling api.");
            }
        }
    }
}
