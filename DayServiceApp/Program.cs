using DayServiceApp.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// �ڑ�����������ϐ�����擾�i�Ȃ���� appsettings.json �̒l���g�p�j
var connectionString = Environment.GetEnvironmentVariable("DATABASE_URL")
                       ?? builder.Configuration.GetConnectionString("DefaultConnection");

// �ڑ������񂪎擾�ł��Ȃ������ꍇ�̃G���[�n���h�����O
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("�f�[�^�x�[�X�̐ڑ������񂪐ݒ肳��Ă��܂���B���ϐ� 'DATABASE_URL' ��ݒ肷�邩�Aappsettings.json �� 'DefaultConnection' ��ǉ����Ă��������B");
}

// �f�o�b�O�p�̃��M���O�i�K�v�ɉ����č폜�j
Console.WriteLine($"Using database connection string: {connectionString}");

// Add services to the container.
builder.Services.AddControllersWithViews();

// �������T�[�r�X�o�^���@�ɏC��
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
