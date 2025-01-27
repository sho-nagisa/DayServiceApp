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

        // �R���X�g���N�^�ŗ����̈ˑ��֌W�𒍓�
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
            // user_id �ɑΉ����郆�[�U�[���擾
            var user = _context.Users.FirstOrDefault(u => u.user_id == user_id);
            if (user == null)
            {
                return NotFound(); // ���[�U�[��������Ȃ��ꍇ��404
            }

            return View(user); // User���f�����r���[�֓n��
        }

        public IActionResult IndividualRecords()
        {
            // users�e�[�u������f�[�^���擾
            var users = _context.Users.ToList();

            // �擾�������X�g���r���[�ɓn��
            return View(users);
        }
        public IActionResult RecordsView()
        {
            // Records �e�[�u���� User �e�[�u�����֘A�t���ăf�[�^���擾
            var records = _context.Records
                .Include(r => r.User) // User ���֘A�t���ă��[�h
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
