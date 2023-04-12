## Install pakeges :

#### dotnet add package FluentAssertions 
#### dotnet add package Bogus

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

```csharp

![My Remote Image](https://github.com/nosratifarhad/UnitTest_XUnit_Mock_Faker/blob/main/doc/runresult.png)
