using Microsoft.AspNetCore.Mvc;
using UnitTestUsingXUnit.Business;
using UnitTestUsingXUnit.DataAccess.Dtos;

namespace UnitTestUsingXUnit.Api.Controllers
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
        /// GetProductList
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/v1/products")]
        public async Task<IActionResult> GetProductList()
        {
            var productLists = await _productService.GetProductsAsync();

            return Ok(productLists);
        }

        /// <summary>
        /// CreateProduct
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("/api/v1/product")]
        public async Task<IActionResult> CreateProduct(CreateProduct command)
        {
            var productId = await _productService.CreateProductAsync(command);

            return CreatedAtRoute(nameof(GetProduct), new { productId = productId }, new { ProductId = productId });
        }

        /// <summary>
        /// GetProduct
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet("/api/v1/product/{productId:int}", Name = nameof(GetProduct))]
        public async Task<IActionResult> GetProduct(int productId)
        {
            var productDto = await _productService.GetProductAsync(productId);

            return Ok(productDto);
        }
    }
}
