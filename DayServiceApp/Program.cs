using DayServiceApp.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 接続文字列を環境変数から取得（なければ appsettings.json の値を使用）
var connectionString = Environment.GetEnvironmentVariable("DATABASE_URL")
                       ?? builder.Configuration.GetConnectionString("DefaultConnection");

// 接続文字列が取得できなかった場合のエラーハンドリング
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("データベースの接続文字列が設定されていません。環境変数 'DATABASE_URL' を設定するか、appsettings.json に 'DefaultConnection' を追加してください。");
}

// デバッグ用のロギング（必要に応じて削除）
Console.WriteLine($"Using database connection string: {connectionString}");

// Add services to the container.
builder.Services.AddControllersWithViews();

// 正しいサービス登録方法に修正
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

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
