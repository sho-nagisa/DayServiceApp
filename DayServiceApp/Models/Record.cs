using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DayServiceApp.Models
{
    public class Record
    {
        [Key]
        public int record_id { get; set; }

        [ForeignKey("User")]
        public int user_id { get; set; }

        [Required]
        public string recorder_name { get; set; }

        public string notices { get; set; }
        public string details { get; set; }
        public string support_details { get; set; }
        public string post_changes { get; set; }

        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }

        [ForeignKey("user_id")]
        public virtual User User { get; set; } // `?` を追加してオプションにする
    }

}
