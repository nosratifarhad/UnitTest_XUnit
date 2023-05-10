using ECommerce.Api.Domain;
using ECommerce.Api.Infra.Repositories.ReadRepositories.ProductReadRepositories;
using ECommerce.Api.Infra.Repositories.WriteRepositories.ProductWriteRepositories;
using ECommerce.Api.Services;
using ECommerce.Api.Services.Contract;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Dependency Injection

#region [ Application ]

builder.Services.AddScoped<IProductService, ProductService>();

#endregion [Application]

#region [ Infra - Data ]

builder.Services.AddScoped<IProductReadRepository, ProductReadRepository>();
builder.Services.AddScoped<IProductWriteRepository, ProductWriteRepository>();

#endregion [ Infra - Data EventSourcing ]

#endregion Dependency Injection

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
