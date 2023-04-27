using FormProject.Business.Abstract;
using FormProject.Business.Concrate;
using FormProject.Data.Abstract;
using FormProject.Data.Concrate.EFCore;
using FormProject.Data.Concrate.EFCore.Context;
using FormProject.Entity.Concrate.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



builder.Services.AddDbContext<FormProjectContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));
builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<FormProjectContext>()
    .AddDefaultTokenProviders();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/account/login";//Eðer kullanýcý eriþebilmesi için login olmak zorunda olduðu bir yere istekte bulunursa, login sayfasýna yönlendirilecek. 
});

builder.Services.AddScoped<IFormService, FormManager>();

builder.Services.AddScoped<IFormRepository, EFCoreFormRepository>();

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
