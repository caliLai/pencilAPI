using pencilAPI.Models;
using pencilAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// connect to db
builder.Services.Configure<PencilDB>(builder.Configuration.GetSection("PencilDB"));

builder.Services.AddSingleton<PencilService>();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
