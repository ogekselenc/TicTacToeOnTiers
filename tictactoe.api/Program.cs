using Microsoft.EntityFrameworkCore;
using tictactoe.data;
using tictactoe.data.Repositories;
using MediatR;
using System.Reflection;
using tictactoe.domain.Commands;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registracija MediatR-a
builder.Services.AddMediatR(typeof(CreatePlayerCommand).Assembly);
// Registracija UnitOfWork-a i repozitorijuma
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddControllers();

var app = builder.Build();
app.UseDeveloperExceptionPage(); // Add this
app.MapControllers();  // Enables controller routing

app.Run();
