using Ticket.Application.Interfaces.Contexts;
using Ticket.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Ticket.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.OData;
using Hangfire.AspNetCore;
using Hangfire;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddOData(opt=>
{
    opt.Select().Filter().OrderBy().Count();
    //for use with attribute in actions:
    //[EnableQuery]
});


builder.Services.AddTransient<IDbContext, MyDbContext>();
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<MyDbContext>()
    .AddDefaultTokenProviders();
builder.Services
    .AddEntityFrameworkSqlServer()
    .AddDbContext<MyDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("sqlServer"));
});
//افزودن دیتابیس برای هنگ فایر و اعمال جاب ها
builder.Services.AddHangfire(config =>
{
    config.UseSqlServerStorage(builder.Configuration.GetConnectionString("hangfireStorage"));
});
//سرور انجام دهنده جاب های هنگ فایر
builder.Services.AddHangfireServer();

//ریکوئست هایی که به خطا مواجه میشوند را هم میخوام لاگ کنم چه اطلاعاتی داشتن
builder.Services.AddHttpLogging(opt =>
{
    opt.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.RequestPropertiesAndHeaders;

});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

//لاگ های http
app.UseHttpLogging();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//داشبورد نمایش هنگ فایر ها و جاب ها
if (app.Environment.IsDevelopment())
{
    app.MapHangfireDashboard("/hangfire");
}
else
{
    app.MapHangfireDashboardWithAuthorizationPolicy("Master", "/hangfire");
}
app.Run();


