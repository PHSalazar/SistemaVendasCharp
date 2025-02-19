using api_SistemaVendas.Data;
using api_SistemaVendas.Middlewares;
using api_SistemaVendas.Repositories;
using api_SistemaVendas.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SistemaVendasDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<FuncionarioRepository>();
builder.Services.AddScoped<FuncionarioService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware(typeof(GlobalErrorHandlingMiddleware));
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
