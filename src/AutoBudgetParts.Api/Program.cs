using AutoBudgetParts.Api.Filters;
using AutoBudgetParts.Application.Services.Budgets;
using AutoBudgetParts.Application.Services.Quotes;
using AutoBudgetParts.Infra;
using AutoBudgetParts.Infra.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMvc(config => config.Filters.Add(typeof(ExceptionFilter)));
builder.Services.AddInfra();
builder.Services.AddBudgetService();
builder.Services.AddQuoteService();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); 
    app.UseSwaggerUI(); 
}

app.UseCors(policy => policy
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();