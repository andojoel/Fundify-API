using Fundify_API.Data;
using Fundify_API.DataModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Claims;

// var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

/*
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://fundify-paris.fr",
                              "http://www.fundify-paris.fr")
                              .AllowAnyMethod()
                              .AllowAnyHeader();
                      });
});
*/

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options => options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")!));

builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
builder.Services.AddAuthorizationBuilder();
builder.Services.AddIdentityCore<User>()
    .AddEntityFrameworkStores<DataContext>()
    .AddApiEndpoints();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
var appBaseRoute = app.MapGroup("/api/v1");

// Configure the HTTP request pipeline.
/*
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);
appBaseRoute.RequireCors(MyAllowSpecificOrigins);
*/

app.UseSwagger();
app.UseSwaggerUI();

// Add your endpoints here
appBaseRoute.MapGroup("user").MapIdentityApi<User>();

appBaseRoute.MapGet("/ping", (ClaimsPrincipal user) => Results.Ok($"Hello from the server !"));

appBaseRoute.MapGet("/", (ClaimsPrincipal user) => Results.Ok($"Hello {user.Identity!.Name} !"))
    .RequireAuthorization();



app.Run();