# UnitTest In Xunit

 * Test All Methods And Logics In Service Layer .
 * Test All Methods In Repository Layer .
 * Test Exceptions .
 * Test All Validation .
----
### * Install pakeges :
* dotnet add package FluentAssertions
* dotnet add package Bogus
----

## I Use "FluentAssertions" For Handle Assert Tests 
* You can See All Sample "FluentAssertions" In [This Repository](https://github.com/nosratifarhad/FluentAssertions.git/).


### Test For Created Successed Product In Service Layer.
```csharp
[Fact]
public async void When_ValidCreateProductInputModelInCreateProductAsync_Then_ReturnCreatedProductId()
{
    var moqProductReadRepository = new Mock<IProductReadRepository>();
    var moqProductWriteRepository = new Mock<IProductWriteRepository>();

    moqProductWriteRepository.Setup(p => p.CreateProductAsync(It.IsAny<Product>())).ReturnsAsync(1);

    var productService = new ProductService(moqProductReadRepository.Object, moqProductWriteRepository.Object);

    var validC1reateProductInputModel = ProductMockData.ValidCreateProductInputModel();

    var response = await productService.CreateProductAsync(validC1reateProductInputModel).ConfigureAwait(false);

    response.Should().Be(1);
    response.Should().NotBe(0);
}
```

### Test For Created Successed Product In Repository Layer.
```csharp
[Fact]
public async void When_ValidProductInCreateProductAsync_Then_CreatedInDatabase()
{
    var validProduct = ProductMockData.CreateProduct();

    var productWriteRepository = new ProductWriteRepository();

    var productViewModel = await productWriteRepository.CreateProductAsync(validProduct).ConfigureAwait(false);

    productViewModel.Should().BeGreaterThan(1);
    productViewModel.Should().BeLessThanOrEqualTo(20);
}
```

### Test For Update Successed Product In Service Layer.
```csharp
[Fact]
public async void When_ValidUpdateProductInputModelInUpdateProductAsync_Then_UpdatedDatabase()
{
    var moqProductReadRepository = new Mock<IProductReadRepository>();
    var moqProductWriteRepository = new Mock<IProductWriteRepository>();

    var validUpdateProductInputModel = ProductMockData.ValidUpdateProductInputModel();

    moqProductReadRepository.Setup(p => p.GetProductAsync(It.IsAny<int>()))
        .ReturnsAsync(
        new ProductDto() 
        { 
            ProductId = validUpdateProductInputModel.ProductId ,
            ProductName = validUpdateProductInputModel.ProductName ,
            ProductTitle = validUpdateProductInputModel.ProductTitle ,
        });

    moqProductReadRepository.Setup(p => p.IsExistProductAsync(It.IsAny<int>())).ReturnsAsync(true);
        
    moqProductWriteRepository.Setup(p => p.UpdateProductAsync(It.IsAny<Product>()));

    var productService = new ProductService(moqProductReadRepository.Object, moqProductWriteRepository.Object);


    await productService.UpdateProductAsync(validUpdateProductInputModel).ConfigureAwait(false);

    var productViewModel = await productService.GetProductAsync(validUpdateProductInputModel.ProductId).ConfigureAwait(false);

    productViewModel.ProductId.Should().Be(validUpdateProductInputModel.ProductId);
    productViewModel.ProductName.Should().Be(validUpdateProductInputModel.ProductName);
    productViewModel.ProductTitle.Should().Be(validUpdateProductInputModel.ProductTitle);
}
```
### Test For Remove Successed Product In Service Layer.
```csharp
[Theory]
[InlineData(1)]
[InlineData(2)]
[InlineData(3)]
public async void When_ValidProductIdInDeleteProductAsync_Then_RemoveFromDataBase(int productId)
{
    var moqProductReadRepository = new Mock<IProductReadRepository>();
    var moqProductWriteRepository = new Mock<IProductWriteRepository>();

    moqProductReadRepository.Setup(p => p.GetProductAsync(It.IsAny<int>())).ReturnsAsync(new ProductDto());

    moqProductReadRepository.Setup(p => p.IsExistProductAsync(It.IsAny<int>())).ReturnsAsync(true);

    var productService = new ProductService(moqProductReadRepository.Object, moqProductWriteRepository.Object);

    await productService.DeleteProductAsync(productId).ConfigureAwait(false);

    var productViewModel = await productService.GetProductAsync(productId).ConfigureAwait(false);

    productViewModel.ProductId.Should().Be(0);
    productViewModel.ProductName.Should().Be(null);
    productViewModel.ProductTitle.Should().Be(null);
}
```

### User Bogus For Generate Fake Data In MockDatas Like This
```csharp
private static ProductDto CreateFakerProductDto(int productId)
   => new Faker<ProductDto>()
      .RuleFor(bp => bp.ProductId, f => f.Random.Number(1, 20))
      .RuleFor(bp => bp.ProductName, f => f.Name.FirstName())
      .RuleFor(bp => bp.ProductTitle, f => f.Name.JobTitle())
      .RuleFor(bp => bp.ProductDescription, f => f.Name.JobDescriptor())
      .RuleFor(bp => bp.ProductCategory, f => f.Random.Enum<ProductCategory>())
      .RuleFor(bp => bp.MainImageName, f => f.Name.FullName())
      .RuleFor(bp => bp.MainImageTitle, f => f.Name.FullName())
      .RuleFor(bp => bp.MainImageUri, f => f.Name.FullName())
      .RuleFor(bp => bp.Color, f => f.Random.Enum<ProductColor>())
      .RuleFor(bp => bp.IsFreeDelivery, f => f.Random.Bool())
      .RuleFor(bp => bp.IsExisting, f => f.Random.Bool())
      .RuleFor(bp => bp.Weight, f => f.Random.Number());
```

### Passed All Tests
![My Remote Image](https://github.com/nosratifarhad/UnitTest_XUnit_Mock_Faker/blob/main/doc/runresult.png)

