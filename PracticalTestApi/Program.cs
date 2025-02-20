using Application.AppMapper;
using Application.Service;
using Application.ServiceInterface;
using AutoMapper;
using Domain.RepositoryInterface;
using Infrastructure.Context;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using InfrastructDomain.Model;
using Microsoft.Extensions.Configuration;
using Application.TokenGenerator;

var builder = WebApplication.CreateBuilder(args);

var mappingConfig = new MapperConfiguration(options => options.AddProfile(new EmployeeProfile()));
var mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
 DbConfigAdo.connectionStr= builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
//    .AddEntityFrameworkStores<ApplicationDbContext>()
//    .AddDefaultTokenProviders();

//builder.Services.AddAuthentication("Bearer")
//    .AddJwtBearer(Options =>
//    {
//        Options.Authority = "";
//        Options.Audience = "";
//        Options.RequireHttpsMetadata = false;
//    });

//builder.Services.AddAuthorization();
builder.Services.AddScoped<TokenGenerator>();
builder.Services.AddScoped<IServiceInfra, ServiceInfra>();
builder.Services.AddScoped<IServiceInfraRepo, ServiceInfraRepo>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepo, ProductRepo>();
builder.Services.AddTransient<IEmailService, EmailService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) 
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.UseCors(policy=>policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
//app.MapControllers();
app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Auth}/{action=Index}/{id?}");


app.Run();
