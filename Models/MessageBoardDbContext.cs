using Microsoft.EntityFrameworkCore;

namespace A9223145_homework3.Models
{
    public class MessageBoardDbContext : DbContext
    {
        // 建立資料庫內容類別建構式
        public MessageBoardDbContext(DbContextOptions<MessageBoardDbContext> options)
        : base(options)
        {
        }
        public DbSet<MessageRecord>? MessageRecords { get; set; } // 定義留言紀錄實體集屬性
    }
}
