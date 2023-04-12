using ECommerce.Service.Contract;
using ECommerce.Service.InputModels.ProductInputModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        #region Fields
        private readonly IProductService _productService;
        #endregion Fields

        #region Ctor
        public ProductsController(IProductService productService)
        {
           this._productService = productService;
        }

        #endregion Ctor

        /// <summary>
        /// Get Product List
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/products")]
        public async Task<IActionResult> GetProducts()
        {
            var productVMs = await _productService.GetProducts().ConfigureAwait(false);
            
            return Ok(productVMs);
        }

        /// <summary>
        /// CreateProduct
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("/api/product")]
        public async Task<IActionResult> CreateProduct(CreateProductInputModel inputModel)
        {
            int productId = await _productService.CreateProductAsync(inputModel).ConfigureAwait(false);

            return CreatedAtRoute(nameof(GetProduct), new { productId = productId }, new { ProductId = productId });
        }

        /// <summary>
        /// GetProduct
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet("/api/product/{productId:int}", Name = nameof(GetProduct))]
        public async Task<IActionResult> GetProduct(int productId)
        {
            var product =await _productService.GetProduct(productId).ConfigureAwait(false);

            return Ok(product);
        }

        /// <summary>
        /// Update Product
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("/api/product/{productId:int}")]
        public async Task<IActionResult> UpdateProduct(int productId, UpdateProductInputModel inputModel)
        {
            if (productId != inputModel.ProductId)
                return BadRequest();

            await _productService.UpdateProductAsync(inputModel).ConfigureAwait(false);

            return NoContent();
        }

        /// <summary>
        /// Delete Product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpDelete("/api/product/{productId:int}")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            await _productService.DeleteProductAsync(productId).ConfigureAwait(false);
            
            return NoContent();
        }

        ///// <summary>
        ///// Upsert Product Picture
        ///// </summary>
        ///// <param name="productId"></param>
        ///// <param name="command"></param>
        ///// <returns></returns>
        //[HttpPut("/api/v1/product/{productId:int}/picture")]
        //public async Task<IActionResult> UpsertProductPicture(int productId, ProductPictureCommand command)
        //{
        //    if (productId != command.ProductId)
        //        return BadRequest("Bad Request Message");

        //    return CreatedAtRoute(nameof(GetProductPicture), new { productId = productId }, new { ProductId = productId });
        //}

        ///// <summary>
        ///// Get Product Picture
        ///// </summary>
        ///// <param name="productId"></param>
        ///// <returns></returns>
        //[HttpGet("/api/v1/product/{productId:int}/picture", Name = nameof(GetProductPicture))]
        //public async Task<IActionResult> GetProductPicture(int productId)
        //{
        //    List<ProductPictureVM> productPictureVMs = ProductPictureMockData.ProductPictureVMs;

        //    return Ok(productPictureVMs);
        //}

        ///// <summary>
        ///// Create Product Price
        ///// </summary>
        ///// <param name="productId"></param>
        ///// <param name="command"></param>
        ///// <returns></returns>
        //[HttpPost("/api/v1/product/{productId:int}/price")]
        //public async Task<IActionResult> CreateProductPrice(int productId, CreateProductPriceCommand command)
        //{
        //    if (productId != command.ProductId)
        //        return BadRequest("Bad Request Message");

        //    return CreatedAtRoute(nameof(GetProductPrice), new { productId = productId }, new { ProductId = productId });
        //}

        ///// <summary>
        ///// Get Product Price
        ///// </summary>
        ///// <param name="productId"></param>
        ///// <returns></returns>
        //[HttpGet("/api/v1/product/{productId:int}/price", Name = nameof(GetProductPrice))]
        //public async Task<IActionResult> GetProductPrice(int productId)
        //{
        //    ProductPriceVM productPriceVM = ProductPriceMockData.productPriceVMMockData;

        //    return Ok(productPriceVM);
        //}

        ///// <summary>
        ///// Update Product Price
        ///// </summary>
        ///// <param name="productId"></param>
        ///// <param name="command"></param>
        ///// <returns></returns>
        //[HttpPut("/api/v1/product/{productId:int}/price")]
        //public async Task<IActionResult> UpdateProductPrice(int productId, UpdateProductPriceCommand command)
        //{
        //    if (productId != command.ProductId)
        //        return BadRequest("Bad Request Message");

        //    return NoContent();
        //}
    }
}
