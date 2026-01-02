using Repository_Pattern.Models;
using Repository_Pattern.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MongoSetting>(
    builder.Configuration.GetSection("MongoDB"));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<MongoService>();
builder.Services.AddScoped(typeof(IDBService<>), typeof(DBService<>));



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
