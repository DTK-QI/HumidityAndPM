using Hangfire;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//���Uhangfire�åB�ϥΰO����O�s�Ƶ{�A
//�w�]�ҤU����HangFire�M��i�H�ϥ�sqlserver�A�i�z�Lconfig.UseSqlServerStorage();�A���ݭn�]�w
builder.Services.AddHangfire(config => {
    config.UseInMemoryStorage();
});
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
app.UseHangfireDashboard();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
