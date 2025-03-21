using System.ComponentModel.DataAnnotations.Schema;

namespace A9223145_homework3.Models
{
    [Table("MessageRecords")]
    public class MessageRecord
    {
        public int Id { get; set; } // 定義流水號欄位
        public string? Title { get; set; } // 定義留言標題欄位
        public string? Content { get; set; } // 定義留言內容欄位
        public string? Name { get; set; } // 定義留言者姓名欄位
        public DateTime MessageDate { get; set; } // 定義留言日期欄位
    }
}
