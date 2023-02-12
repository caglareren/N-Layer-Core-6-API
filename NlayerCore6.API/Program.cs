using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NLayerCore6.API.Filters;
using NLayerCore6.API.Middlewares;
using NLayerCore6.API.Modules;
using NLayerCore6.Repository;
using NLayerCore6.Service.Mapping;
using NLayerCore6.Service.Validations;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
// Configuration
// Add services to the container.


builder.Services.AddControllers();

//builder.Services.AddControllers(options => options.Filters.Add(new ValidateFilterAttribute())).AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<AddressInfoDtoValidator>());

//builder.Services.Configure<ApiBehaviorOptions>(options =>
//{
//    options.SuppressModelStateInvalidFilter = true;

//});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = ".Net Core 6 API",
        Description = "Nlayer (Class Libraries; Caching, Core, Repository, Service), EF Core, PostgreSQL, MsSQL, AutoMapper, Autofac, Swashbuckle, FluentValidation | Unit Test; Xunit, InMemory Tests (EF Core, SQLite, SQL Server Express LocalDB) <br><br> The cache is refreshed on add, update and delete. In other queries, data is fetched from the cache. <br><br> districtNameOrderBy(query) 'Ascending' or 'Descending' ",
        //TermsOfService = new Uri("https://caglareren.com"),
        //Contact = new OpenApiContact
        //{
        //    Name = "Çaðlar Eren",
        //    Url = new Uri("https://caglareren.com")
        //},
        License = new OpenApiLicense
        {
            Name = "Screenshot",
            Url = new Uri("https://testapi.caglareren.com/screenshot.png")
        }
    });
});
builder.Services.AddMemoryCache();

builder.Services.AddScoped(typeof(NotFoundFilter<>));
builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
    //x.UseNpgsql(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    //{
    //    option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    //});
});

builder.Host.UseServiceProviderFactory
    (new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new RepoServiceModule()));

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}


app.UseStaticFiles();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", ".Net Core 6 API"));


app.UseHttpsRedirection();
app.UseCustomException();

app.UseAuthorization();

app.MapControllers();

app.Run();



