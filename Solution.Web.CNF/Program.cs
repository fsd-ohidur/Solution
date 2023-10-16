using Solution.Core;
using Solution.Web.CNF.Services;
using Solution.Web.CNF.Services.IServices;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddHttpClient<IUnitOfService, UnitOfService>();
SD.CNFAPIBase = builder.Configuration["ServiceUrls:CNFAPI"];
SD.HRAPIBase = builder.Configuration["ServiceUrls:HRAPI"];
builder.Services.AddScoped<IUnitOfService, UnitOfService>();

builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAnyOrigin", builder =>
	{
		builder.AllowAnyOrigin()
				   .AllowAnyHeader()
				   .AllowAnyMethod();
	});
});

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseCors("AllowAnyOrigin");

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
