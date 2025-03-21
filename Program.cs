using Microsoft.EntityFrameworkCore;
using A9223145_homework3.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MessageBoardDbContext>(options =>
 options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDocument();

builder.Services.AddCors(options => // �[�JCORS�w�]Policy
 options.AddDefaultPolicy(builder => builder.AllowAnyOrigin())); // ���\����Origin

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseOpenApi(); // �ϥ�Swagger 2.0 (OpenApi)���;������n��
app.UseSwaggerUi3(); // �ϥ� Swagger UI 3.0 �����n

app.UseAuthorization();

app.MapControllers();

app.Run();
