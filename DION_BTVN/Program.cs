
using DION_BTVN.Models;
using DION_BTVN.Repositories;
using DION_BTVN.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DionThoaianhContext>(
    item => item.UseSqlServer(builder.Configuration.GetConnectionString("DION_BTVNConnection")));

//services
builder.Services.AddScoped<IAccountService, AccountService>();

//repository
builder.Services.AddScoped<IAccountRepository, AccountRepository>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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
