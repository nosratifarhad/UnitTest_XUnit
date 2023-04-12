﻿using ECommerce.Domain.Products.Enums;

namespace ECommerce.Domain.Products.Dtos.ProductDtos
{
    public class ProductDto
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductTitle { get; set; }

        public string ProductDescription { get; set; }

        public ProductCategory ProductCategory { get; set; }

        public string MainImageName { get; set; }

        public string MainImageTitle { get; set; }

        public string MainImageUri { get; set; }

        public ProductColor Color { get; set; }

        public bool IsFreeDelivery { get; set; }

        public bool IsExisting { get; set; }

        public List<Material> Materials { get; set; }

        public int Weight { get; set; }
    }
}
