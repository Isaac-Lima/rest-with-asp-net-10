using RestWithASPNet10.Configurations;
using RestWithASPNet10.Repositories;
using RestWithASPNet10.Repositories.Impl;
using RestWithASPNet10.Services;
using RestWithASPNet10.Services.Impl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.AddSeriLogLogging(); 

builder.Services.AddDatabaseConfiguration(builder.Configuration); 
builder.Services.AddScoped<IPersonServices, PersonServicesImpl>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();

builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();


app.Run();
