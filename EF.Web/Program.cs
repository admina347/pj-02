using EF.DataAccessLibrary.Dataaccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: false);
builder.Configuration.AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: false);


// Add services to the container.
builder.Services.AddRazorPages();
//
builder.Services.AddDbContext<LibraryContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

/* builder.Services.AddDbContext<LibraryContext>(
  options =>
      options.UseSqlServer(
          builder.Configuration.GetConnectionString("LibraryContext"),
          b => b.MigrationsAssembly("EF.Web")));
          //b => b.MigrationsAssembly("EF.DataAccessLibrary"))); */

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
