using FluentValidation;
using FluentValidation.AspNetCore;
using IdeaBank.Data;
using IdeaBank.Infra;
using IdeaBank.Validation.IdeaDtosValidation;
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
builder.Services.AddValidatorsFromAssemblyContaining<CreateIdeaDtoValidator>();
builder.Services.AddAuthenticationServices(builder.Configuration);


var app = builder.Build();

app.UseAuthentication();

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

