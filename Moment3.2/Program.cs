using Microsoft.EntityFrameworkCore;
using Moment_3._2.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<GenresContext>(opt =>

                opt.UseSqlite(builder.Configuration.GetConnectionString("SqliteAlbumsString")));

builder.Services.AddDbContext<AlbumsContext>(opt =>

                opt.UseSqlite(builder.Configuration.GetConnectionString("SqliteAlbumsString")));

builder.Services.AddDbContext<UsersContext>(opt =>

                opt.UseSqlite(builder.Configuration.GetConnectionString("SqliteAlbumsString")));

builder.Services.AddDbContext<RentalsContext>(opt =>

                opt.UseSqlite(builder.Configuration.GetConnectionString("SqliteAlbumsString")));


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
    pattern: "{controller=Genres}/{action=Index}/{id?}");

app.Run();
