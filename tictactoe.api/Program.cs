using Microsoft.EntityFrameworkCore;
using tictactoe.data;
using tictactoe.data.Repositories;
using MediatR;
using System.Reflection;
using tictactoe.domain.Commands;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.WebHost.UseUrls("http://127.0.0.1:5000");


builder.Services.AddControllers();

// Registracija MediatR-a
builder.Services.AddMediatR(typeof(CreatePlayerCommand).Assembly);
// Registracija UnitOfWork-a i repozitorijuma
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader());
});

var app = builder.Build();

app.UseRouting();
app.UseCors("AllowAll"); // Enable CORS policy
app.UseDeveloperExceptionPage(); // Add this
app.MapControllers();  // Enables controller routing

app.Run();
