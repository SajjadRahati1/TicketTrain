using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Ticket.Application.Interfaces.Contexts;
using Ticket.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Ticket.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.OData;
using Hangfire.AspNetCore;
using Hangfire;
using EndPoint.Site.Helpers;
using Ticket.Common.Interfaces.FacadPatterns;
using Ticket.Application.Services.Users.FacadPattern;
using Ticket.Application.Services.Email.Commands;
using Ticket.Application.Services.Sms.Commands;
using Ticket.Application.Services.FacadPattern;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddOData(opt =>
{
    opt.Select().Filter().OrderBy().Count();
    //for use with attribute in actions:
    //[EnableQuery]
})
    .AddRazorRuntimeCompilation();
    //.AddJsonOptions(option=>option.JsonSerializerOptions.);

builder.Services.AddTransient<IDbContext, MyDbContext>();
//builder.Services.AddScoped<SecurityStampValidator<User>>();

builder.Services
    .AddEntityFrameworkSqlServer()
    .AddDbContext<MyDbContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("sqlServer"));
    });

builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<MyDbContext>()//توسط چه فریم ورکی ذخیره شود
    .AddDefaultTokenProviders()//پرو وایدر برای ایجاد توکن ها
    .AddRoles<Role>() //role رو باید از لایه های زیر دریافت کرد
    .AddErrorDescriber<CustomIdentityError>()//نمایش ارور ها را فارسی سازی کنیم
    .AddPasswordValidator<MyPasswordValidator>();//برای اینکه پسورد را خودمان هم چک کنیم مثلا پسورد های عامیانه نباشد

builder.Services.AddAuthorization(options =>
{
    //اینجا باید تکمیل شود
    options.AddPolicy("HaveNameClaim", policy =>
    {
        policy.RequireClaim("Name");
    });
});

//تنظمیات Identity
builder.Services.Configure<IdentityOptions>(options =>
{
    //یونیک بودن ایمیل ها
    options.User.RequireUniqueEmail = true;
    //کاراکتر هایی که میتواند به عنوان یوزنیم وارد کند
    //options.User.AllowedUserNameCharacters

    //حداقل تعداد کاراکتر های غیر تکراری
    options.Password.RequiredUniqueChars = 2;
    //آیا شامل کاراکتر غیر حروف هم حتما باشد (مثل ادساین)
    options.Password.RequireNonAlphanumeric = false;
    //آیا حتما شامل عدد هم باشد
    options.Password.RequireDigit = false;
    //آیا حتما شامل حروف کوچک هم باشد
    options.Password.RequireLowercase = false;
    //آیا حتما شامل حروف بزرگ هم باشد
    options.Password.RequireUppercase = false;
    //حداقل تعداد کاراکتر پسورد
    options.Password.RequiredLength = 4;


    //اگر این تعداد بار اشتباه رمز زد قفل بشه
    options.Lockout.MaxFailedAccessAttempts = 5;
    //اگر قفل شد چند دقیقه قفل بمونه بعد باز بشه
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
    //کاربر جدید به صورت خودکار قفل باشه یا نه
    options.Lockout.AllowedForNewUsers = false;

    
    //فقط یوزر هایی میتونن ساین این شوند که اکانتشان کانفریم شده باشد
    options.SignIn.RequireConfirmedAccount = false;
    //مشابه
    options.SignIn.RequireConfirmedPhoneNumber = false;
    //مشابه
    options.SignIn.RequireConfirmedEmail = false;
    
    //نام کلیم آیدی چی باشه
    //options.ClaimsIdentity.UserIdClaimType = "Id";

});

//تنظیمات کوکی
builder.Services.ConfigureApplicationCookie(options =>
{

    options.ExpireTimeSpan = TimeSpan.FromMinutes(25);

    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
    //وقتی کاربری به صفحه ای دسترسی نداره مثل صفحه ادمین که هر کاربری دسترسی نداره به این صفحه میفرستیمش
    options.AccessDeniedPath = "/Account/AccessDenied";

    //به ازای هر بار استفاده تایم اسپن از نو گرفته شود
    options.SlidingExpiration = true;
});


//---------Facad Patterns
builder.Services.AddScoped<IUserFacad, UserFacad>();
builder.Services.AddScoped<IDomesticFlightFacad, DomesticFlightFacad>();
builder.Services.AddScoped<IFinancialFacad, FinancialFacad>();
builder.Services.AddScoped<ISendEmailService, SendEmailService>();
builder.Services.AddScoped<ISendSms, SendSms>();
//-----------------------


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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "MyArea",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
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


