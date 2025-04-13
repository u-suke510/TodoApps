using Microsoft.EntityFrameworkCore;

namespace TodoAppLibs
{
    /// <summary>
    /// ToDoアプリのDbコンテキストクラス
    /// </summary>
    public class AppDbContext : DbContext
    {
        protected AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
