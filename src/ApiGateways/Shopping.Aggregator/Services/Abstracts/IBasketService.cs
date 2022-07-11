using Shopping.Aggregator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Aggregator.Services.Abstracts
{
    public interface IBasketService
    {
        Task<BasketModel> GetBasket(string userName);
    }
}
