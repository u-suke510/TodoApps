using Microsoft.EntityFrameworkCore;
using TodoAppLibs.Entities;

namespace TodoAppLibs
{
    /// <summary>
    /// ToDoアプリのDbコンテキストクラス
    /// </summary>
    public class AppDbContext : DbContext
    {
        public virtual DbSet<TTodo> ToDos { get; set; }

        protected AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
