using DayServiceApp.Data;
using DayServiceApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DayServiceApp.Controllers
{
    public class RecordController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecordController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Save(Record model)
        {
            // 必須項目のバリデーションがOKか確認
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                                               .Select(e => e.ErrorMessage)
                                               .ToList();
                return BadRequest(errors); // エラー内容を返す
            }


            // 日時を自動設定したい場合 (必要に応じて)
            model.created_at = DateTime.Now;
            model.updated_at = DateTime.Now;

            // データベースに保存
            _context.Records.Add(model);
            _context.SaveChanges();

            // 保存後のリダイレクト先
            // 例: ホーム画面に戻る
            return RedirectToAction("Index", "Home");
        }
    }
}
