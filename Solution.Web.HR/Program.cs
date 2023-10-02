using Solution.Core;
using Solution.Web.HR.Services;
using Solution.Web.HR.Services.IServices;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddHttpClient<ICompanyService,CompanyService>();
SD.HRAPIBase = builder.Configuration["ServiceUrls:HRAPI"];
builder.Services.AddScoped<ICompanyService,CompanyService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IDesignationService, DesignationService>();


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

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
