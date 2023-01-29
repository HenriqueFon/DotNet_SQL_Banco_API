
using Concessonaria.Data;
using Concessonaria.Repository;
using Concessonaria.Models.UI;
using Concessonaria.Services.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//variavel para pegar o valor da connection string de dentro do appSettings, de acordo com o model criado
//dentro da pasta UI.
var apiSettings = builder.Configuration.GetSection("ApiSettings").Get<ApiSettings>();

builder.Services.AddDbContext<DbContextApp>(options => options.UseSqlServer(apiSettings.SqlServerConnectionString));

builder.Services.AddScoped<IConcessonariaRepository, ConcessonariaRepository>();
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
