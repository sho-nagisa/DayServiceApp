using System.ComponentModel.DataAnnotations;

namespace DayServiceApp.Models
{
    public class User
    {
        [Key]
        public int user_id { get; set; }      // usersテーブルの主キー
        public string? name { get; set; }    // 名前
    }
}
