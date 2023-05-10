﻿using Bogus;
using ECommerce.Api.Domain;
using ECommerce.Api.Domain.Entitys;

namespace ECommerce.Api.Infra.Properties.WriteRepositories.ProductWriteRepositories
{
    public class ProductWriteRepository : IProductWriteRepository
    {
        public async Task<int> CreateProductAsync(Product product)
        {
            await Task.Delay(1000);
            return await Task.FromResult(new Faker().Random.Number(1, 5));
        }

        public async Task DeleteProductAsync(int productId)
        {
            await Task.Delay(1000);
        }

        public async Task UpdateProductAsync(Product product)
        {
            await Task.Delay(1000);
        }
    }
}
