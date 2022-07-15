﻿using AspnetRunBasics.Extensions;
using AspnetRunBasics.Models;
using AspnetRunBasics.Services.Abstracts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRunBasics.Services.Concretes
{
    public class CatalogService : ICatalogService
    {
        private readonly HttpClient _httpClient;

        public CatalogService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<IEnumerable<CatalogModel>> GetCatalogs()
        {
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