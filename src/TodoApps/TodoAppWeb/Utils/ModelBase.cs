namespace TodoAppWeb
{
    /// <summary>
    /// Modelクラスのベースインタフェース
    /// </summary>
    public interface IModelBase
    {
    }

    /// <summary>
    /// Modelクラスのベースクラス
    /// </summary>
    public abstract class ModelBase : IModelBase
    {
        /// <summary>
        /// ロガー
        /// </summary>
        protected readonly ILogger logger;
        /// <summary>
        /// サービスプロバイダー
        /// </summary>
        protected readonly IServiceProvider provider;

        /// <summary>
        /// コンストラクタ。
        /// </summary>
        /// <param name="provider">サービスプロバイダー</param>
        /// <param name="logger">ロガー</param>
        public ModelBase(IServiceProvider provider, ILogger logger)
        {
            this.provider = provider;
            this.logger = logger;
        }
    }
}
