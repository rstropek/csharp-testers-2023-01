using TicTacToe.Api;
using TicTacToe.Logic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IBoardContent, BoardContent>();
builder.Services.AddSingleton<IGame, Game>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/ping", () => "pong");
app.MapGet("/greet", (string name) => $"Hello {name}!");
app.MapPost("/people", (Person person) => $"Hello {person.Name}, your are {person.Age} years old!");

app.MapGet("/tictactoe", TicTacToeApiHandlers.GetBoard);
app.MapPost("/tictactoe", TicTacToeApiHandlers.Set);

app.Run();

record Person(string Name, int Age);
