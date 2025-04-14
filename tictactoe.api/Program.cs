using Microsoft.EntityFrameworkCore;
using tictactoe.data;
using tictactoe.data.Repositories;
using MediatR;
using System.Reflection;
using tictactoe.domain.Commands;
using tictactoe.domain.Queries;
using tictactoe.data.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.WebHost.UseUrls("http://127.0.0.1:5000");


builder.Services.AddControllers();

// Registracija MediatR-a
builder.Services.AddMediatR(typeof(CreatePlayerCommand).Assembly);
builder.Services.AddMediatR(typeof(GetPlayersQuery).Assembly);

// Registracija UnitOfWork-a i repozitorijuma
builder.Services.AddScoped<IGameReadRepository, GameReadRepository>();
builder.Services.AddScoped<IPlayerReadRepository, PlayerReadRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddScoped<IMoveRepository, MoveRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader());
});

var app = builder.Build();

app.UseRouting();
app.UseCors("AllowAll"); 
app.UseDeveloperExceptionPage(); 
app.MapControllers(); 

app.Run();
