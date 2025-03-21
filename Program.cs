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

builder.Services.AddCors(options => // 加入CORS預設Policy
 options.AddDefaultPolicy(builder => builder.AllowAnyOrigin())); // 允許任何Origin

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseOpenApi(); // 使用Swagger 2.0 (OpenApi)產生器中介軟體
app.UseSwaggerUi3(); // 使用 Swagger UI 3.0 中介軟

app.UseAuthorization();

app.MapControllers();

app.Run();
