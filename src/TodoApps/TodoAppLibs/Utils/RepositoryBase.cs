using Microsoft.Extensions.Logging;

namespace TodoAppLibs
{
    /// <summary>
    /// Repositoryクラスのベースインタフェース
    /// </summary>
    public interface IRepositoryBase
    {
        /// <summary>
        /// エンティティを登録します。
        /// </summary>
        /// <param name="entity">登録エンティティ</param>
        void InsEntity(EntityBase entity);

        /// <summary>
        /// エンティティを更新します。
        /// </summary>
        /// <param name="entity">更新エンティティ</param>
        void UpdEntity(EntityBase entity);
    }

    /// <summary>
    /// Repositoryクラスのベースクラス
    /// </summary>
    public abstract class RepositoryBase : IRepositoryBase
    {
        /// <summary>
        /// DBコンテキスト
        /// </summary>
        protected AppDbContext context;
        /// <summary>
        /// ロガー
        /// </summary>
        protected readonly ILogger logger;

        /// <summary>
        /// コンストラクタ。
        /// </summary>
        /// <param name="context">DBコンテキスト</param>
        /// <param name="logger">ロガー</param>
        public RepositoryBase(AppDbContext context, ILogger logger)
        {
            this.context = context;
            this.logger = logger;
        }

        /// <summary>
        /// エンティティを登録します。
        /// </summary>
        /// <param name="entity">登録エンティティ</param>
        public void InsEntity(EntityBase entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }

        /// <summary>
        /// エンティティを更新します。
        /// </summary>
        /// <param name="entity">更新エンティティ</param>
        public void UpdEntity(EntityBase entity)
        {
            context.Attach(entity);
            context.SaveChanges();
        }
    }
}
