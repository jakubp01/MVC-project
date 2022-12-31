using Hospital;
using Hospital.DbContextAndBuilders.ApiDbContext;
using MediatR;
using MVC_Hospital_project.Queries;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVC_Hospital_project.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<HospitalDbContext>();
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
})
.AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddMediatR(typeof(GetVisits.Handler).Assembly);
builder.Services.AddMediatR(typeof(GetSingleVisit.Handler).Assembly);
builder.Services.AddMediatR(typeof(CreateVisit.Handler).Assembly);
builder.Services.AddMediatR(typeof(UpdateVisit.Handler).Assembly);
builder.Services.AddMediatR(typeof(DeleteVisit.Handler).Assembly);


var app = builder.Build();
Seeder.seed(app);
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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Visits}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
