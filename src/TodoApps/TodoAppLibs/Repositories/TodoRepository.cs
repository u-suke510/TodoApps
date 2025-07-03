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

        /// <summary>
        /// ToDo一覧の表示データを取得します。
        /// </summary>
        /// <returns>ToDo情報</returns>
        List<TTodo> GetListItems();
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

        /// <summary>
        /// ToDo一覧の表示データを取得します。
        /// </summary>
        /// <returns>ToDo情報</returns>
        public List<TTodo> GetListItems()
        {
            var query = from todo in context.ToDos
                        where !todo.CompFlg && !todo.DelFlg
                        orderby todo.DueDt
                        select todo;
            var items = query.ToList();
            logger.LogInformation(MsgResource.FmtDbSelectCount, items.Count);
            return items;
        }
    }
}
