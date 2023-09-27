using Application.Repositories;
using Application.Services;
using Database.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

#region dbContext
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString));
#endregion

#region Repositories
builder.Services.AddTransient<SerieRepository>();
builder.Services.AddTransient<ProducerRepository>();
builder.Services.AddTransient<GenderRepository>();
#endregion 

#region Services
builder.Services.AddScoped<SerieService>();
builder.Services.AddScoped<ProducerService>();
builder.Services.AddScoped<GenderService>();
#endregion

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
