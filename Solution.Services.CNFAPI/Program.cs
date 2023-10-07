using Microsoft.EntityFrameworkCore;
using Solution.Services.CNFAPI.Configurations;
using Solution.Services.CNFAPI.Data;
using Solution.Services.CNFAPI.Repository;
using Solution.Services.CNFAPI.Repository.IRepository;

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
