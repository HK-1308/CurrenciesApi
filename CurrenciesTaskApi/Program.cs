using CurrenciesTaskApi.Data;
using CurrenciesTaskApi.Data.Interfaces;
using CurrenciesTaskApi.Data.Repositories;
using CurrenciesTaskApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ICurrencyRepository, CurrencyRepository>();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(x =>
{
    x.UseSqlite(connectionString);
});

builder.Services.AddMvc();

builder.Services.AddRazorPages();
builder.Logging.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "logger.txt"));

var app = builder.Build();

app.UseHttpsRedirection();

app.UseRouting();
app.UseDeveloperExceptionPage();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(name: "default", pattern: "{controller=CurrencyList}/{action=Index}/{id?}");
});

app.Run();
