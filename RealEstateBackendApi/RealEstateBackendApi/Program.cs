using Microsoft.EntityFrameworkCore;
using RealEstateBackendApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add Swagger services.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Connect to SQL Server.
builder.Services.AddDbContext<RealEstateDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("AppDbConnection")));

// Configure CORS.
var allowedOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowedOrigins,
        policy =>
        {
            policy
                .WithOrigins("http://localhost:5173")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Enable Swagger.
    app.UseSwagger();

    // Enable Swagger UI.
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Enable CORS.
app.UseCors(allowedOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();