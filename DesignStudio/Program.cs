using System.Linq;
using System.Text.Json.Serialization;
using AutoMapper;
using DAL;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using DesignStudio.Middlewares;
using DesignStudio.Options.MVCOptions.Extensions;
using DesignStudio.Options.SwaggerOptions;
using Domain.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services;
using Services.Interfaces;
using Services.Mappers;

var builder = WebApplication.CreateBuilder(args);
var dbConnectionString = builder.Configuration.GetConnectionString("DBConnectionString");

// Add services to the container.
builder.Services.AddDbContext<ApplicationContext>(x => 
    x.UseLazyLoadingProxies().UseSqlServer(dbConnectionString, options => options.EnableRetryOnFailure()));

builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddSingleton(provider => new MapperConfiguration(cfg =>
{
    cfg.AddProfiles(new Profile[]
    {
        new CustomerProfile()
    });
    cfg.AllowNullCollections = true;
}).CreateMapper());

builder.Services.AddControllers(options =>
{
    options.UseDateOnlyTimeOnlyStringConverters();
})
.AddJsonOptions(options =>
{
    options.UseDateOnlyTimeOnlyStringConverters();
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.PostConfigure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = actionContext =>
    {
        string error = string.Join(" | ", actionContext.ModelState.Values
            .SelectMany(x => x.Errors)
            .Select(e => e.ErrorMessage));
        throw new BadRequestException(error);
    };
});

builder.Services.AddSwaggerGen(c =>
{
    c.UseDateOnlyTimeOnlyStringConverters();
});

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

var app = builder.Build();

app.Use(async (context, next) =>
{
    context.Features.Get<IHttpMaxRequestBodySizeFeature>()!.MaxRequestBodySize = 5_000_000;
    await next.Invoke();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API");
    });
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseSession();

app.Run();
