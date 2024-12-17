using Hangfire;
using HumidityAndPM.Function;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//註冊hangfire並且使用記憶體保存排程，
//預設所下載的HangFire套件可以使用sqlserver，可透過config.UseSqlServerStorage();，但需要設定
#if DEBUG
builder.Services.AddHangfire(config => {
    config.UseInMemoryStorage();
});
#elif RELEASE
builder.Services.AddHangfire(config => {
    config.UseSqlServerStorage("Server=ISLAB-210\\ISLAB_210;Database=HangfireDB;User ID=sa;Password=123456789;TrustServerCertificate=True;");
});
#endif
//註冊hangfire要使用的伺服器，伺服器就是上面所寫的使用記憶體當伺服器
builder.Services.AddHangfireServer();

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

//使用hangfire內建的儀表板
app.UseHangfireDashboard("/hangfire", new DashboardOptions
{
    Authorization = new[] { new AllowAllAuthorizationFilter() }
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


//添加排程

//每一小時執行一次
var HumidityAndPMData = new CallHumidityAndPMData();
// 定期工作：每小時執行一次
RecurringJob.AddOrUpdate(
    "SaveHumidityAndPMData", // 工作名稱（唯一）
    () => HumidityAndPMData.SaveHumidityAndPMData(),
    Cron.Hourly // CRON 表達式：每小時執行
);

app.Run();
