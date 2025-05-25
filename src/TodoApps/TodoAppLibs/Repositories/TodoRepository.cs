using Microsoft.Extensions.Logging;
using TodoAppLibs.Entities;
using TodoAppLibs.Resources;

namespace TodoAppLibs.Repositories
{
    /// <summary>
    /// ToDo情報のRepositoryインターフェース
    /// </summary>
    public interface ITodoRepository : IRepositoryBase
    {
        /// <summary>
        /// ToDo情報をToDoIDから取得します。
        /// </summary>
        /// <param name="id">ToDoID</param>
        /// <returns>ToDo情報エンティティ</returns>
        TTodo GetItemById(int id);
    }

    /// <summary>
    /// ToDo情報のRepositoryクラス
    /// </summary>
    public class TodoRepository : RepositoryBase, ITodoRepository
    {
        /// <summary>
        /// コンストラクタ。
        /// </summary>
        /// <param name="context">DBコンテキスト</param>
        /// <param name="logger">ロガー</param>
        public TodoRepository(AppDbContext context, ILogger<TodoRepository> logger) : base(context, logger)
        {
        }

        /// <summary>
        /// ToDo情報をToDoIDから取得します。
        /// </summary>
        /// <param name="id">ToDoID</param>
        /// <returns>ToDo情報エンティティ</returns>
        public TTodo GetItemById(int id)
        {
            var item = context.ToDos.SingleOrDefault(x => x.Id == id && !x.DelFlg);
            logger.LogInformation(MsgResource.FmtDbSelectCount, item == null ? 0 : 1);
            return item;
        }
    }
}
