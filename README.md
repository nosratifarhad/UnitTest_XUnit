## Install pakeges :
#### dotnet add package FluentAssertions 
#### dotnet add package Bogus

### User Bogus For Generate Fake Data In MockDatas Like This

```cshrp

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

```cshrp

### And Use FluentAssertions For Handle Assert Tests Like This
Note : You can See Excample Project In [This Repository](https://github.com/nosratifarhad/FluentValidation.git/).

```

[Theory]
[InlineData(1)]
[InlineData(2)]
[InlineData(3)]
public async void When_ValidProductIdInGetProductAsync_Then_ReturnedProductViewModel(int productId)
{
   var productReadRepository = new ProductReadRepository();

   var productViewModel = await productReadRepository.GetProductAsync(productId).ConfigureAwait(false);

   productViewModel.ProductId.Should().Be(productId);
   productViewModel.ProductName.Should().NotBeNull();
   productViewModel.ProductTitle.Should().NotBeNull();
   productViewModel.Should().NotBeNull();
}

```


![My Remote Image](https://github.com/nosratifarhad/UnitTest_XUnit_Mock_Faker/blob/main/doc/runresult.png)

