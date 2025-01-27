using DayServiceApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using DayServiceApp.Data;
using System.Linq;

namespace DayServiceApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        // コンストラクタで両方の依存関係を注入
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult IndividualSupportPlans(int user_id)
        {
            // user_id に対応するユーザーを取得
            var user = _context.Users.FirstOrDefault(u => u.user_id == user_id);
            if (user == null)
            {
                return NotFound(); // ユーザーが見つからない場合は404
            }

            return View(user); // Userモデルをビューへ渡す
        }

        public IActionResult IndividualRecords()
        {
            // usersテーブルからデータを取得
            var users = _context.Users.ToList();

            // 取得したリストをビューに渡す
            return View(users);
        }
        public IActionResult RecordsView()
        {
            // Records テーブルと User テーブルを関連付けてデータを取得
            var records = _context.Records
                .Include(r => r.User) // User を関連付けてロード
                .ToList();

            return View(records);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
