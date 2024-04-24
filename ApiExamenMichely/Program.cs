using ApiExamenMichely.Data;
using ApiExamenMichely.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string connectionString = builder.Configuration.GetConnectionString("SqlAzure");
builder.Services.AddTransient<RepositorySeries>();
builder.Services.AddDbContext<SeriesContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Api Examen",
            Description = "Estamos realizando una Api de Series",
            Version = "v1",
            Contact = new OpenApiContact()
            {
                Name = "Mihcely"
            }
        });
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
    app.UseSwagger();
app.UseSwaggerUI(
options =>
{
   options.SwaggerEndpoint(
       url: "/swagger/v1/swagger.json", name: "Api v1");
   options.RoutePrefix = "";
});

if (app.Environment.IsDevelopment())
{
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
