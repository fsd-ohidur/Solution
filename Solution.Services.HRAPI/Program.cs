using Microsoft.EntityFrameworkCore;
using Solution.Core.Models;
using Solution.Services.HRAPI.Configurations;
using Solution.Services.HRAPI.Data;
using Solution.Services.HRAPI.Repository.IRepository;

//Register start from here
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));
builder.Services.AddHttpContextAccessor();
builder.Services.AddAutoMapper(typeof(MappingInitializer));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(c =>
{
	c.AddPolicy("CorsPolicy", builder =>
		builder.AllowAnyOrigin()
			.AllowAnyMethod()
			.AllowAnyHeader());
});

// Middleware start from here
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
