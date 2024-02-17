using Microsoft.EntityFrameworkCore;
using Todo_List_Project.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//This is a Connection string and Connection string name...
builder.Services.AddDbContext<TodoDBContext>(option => option.UseNpgsql(builder.Configuration.GetConnectionString("MyConnection")));

builder.Services.AddCors(option => option.AddPolicy("AllowAllOrigins", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("AllowAllOrigins");


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
