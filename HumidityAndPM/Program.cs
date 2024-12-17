using Hangfire;
using HumidityAndPM.Function;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//���Uhangfire�åB�ϥΰO����O�s�Ƶ{�A
//�w�]�ҤU����HangFire�M��i�H�ϥ�sqlserver�A�i�z�Lconfig.UseSqlServerStorage();�A���ݭn�]�w
#if DEBUG
builder.Services.AddHangfire(config => {
    config.UseInMemoryStorage();
});
#elif RELEASE
builder.Services.AddHangfire(config => {
    config.UseSqlServerStorage("Server=ISLAB-210\\ISLAB_210;Database=HangfireDB;User ID=sa;Password=123456789;TrustServerCertificate=True;");
});
#endif
//���Uhangfire�n�ϥΪ����A���A���A���N�O�W���Ҽg���ϥΰO�������A��
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

//�ϥ�hangfire���ت�����O
app.UseHangfireDashboard("/hangfire", new DashboardOptions
{
    Authorization = new[] { new AllowAllAuthorizationFilter() }
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


//�K�[�Ƶ{

//�C�@�p�ɰ���@��
var HumidityAndPMData = new CallHumidityAndPMData();
// �w���u�@�G�C�p�ɰ���@��
RecurringJob.AddOrUpdate(
    "SaveHumidityAndPMData", // �u�@�W�١]�ߤ@�^
    () => HumidityAndPMData.SaveHumidityAndPMData(),
    Cron.Hourly // CRON ��F���G�C�p�ɰ���
);

app.Run();
