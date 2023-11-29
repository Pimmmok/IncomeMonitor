using Autofac.Extensions.DependencyInjection;
using Autofac;
using IncomeMonitor.WebUI.Infrastructure;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//string connection = builder.Configuration.GetConnectionString("DefaultConnection");
string connection = builder.Configuration.GetConnectionString("ConnectionWithDocker");

//string connection = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<EFDbContext>(options => options.UseSqlServer(connection));

//builder.Services.AddDbContext<EFDbContext>(options => options.UseSqlServer(connection)); TO DO

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

// Call ConfigureContainer on the Host sub property 
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new PersistanceAutofacModule(connection)) ;
});

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
    pattern: "{controller=Procedure}/{action=List}");

app.Run();

