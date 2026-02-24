using IdeaBank.Data;
using IdeaBank.Web.Endpoints.IdeaEndpoints;
using IdeaBank.Web.Endpoints.UserEndpoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<IdeaBankDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("IdeaBankConnection")));

builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var api = app.MapGroup("/api");

IdeaEndpoints.Map(api);
UserEndpoints.Map(api);

app.Run();

