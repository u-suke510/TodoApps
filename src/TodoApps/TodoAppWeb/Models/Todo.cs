using TodoAppLibs.Entities;
using TodoAppLibs.Repositories;
using TodoAppWeb.Resources;
using TodoAppWeb.ViewModels.Todo;

namespace TodoAppWeb.Models
{
    /// <summary>
    /// ToDoのModelインタフェース
    /// </summary>
    public interface ITodo : IModelBase
    {
        /// <summary>
        /// ToDoフォーム画面のViewModelを取得します。
        /// </summary>
        /// <param name="id">ToDoID</param>
        /// <returns>ViewModel</returns>
        FormViewModel GetFormViewModel(int? id);

        /// <summary>
        /// ToDoフォームを登録します。
        /// </summary>
        /// <param name="viewModel">ToDoフォーム</param>
        /// <param name="userId">ユーザーID</param>
        /// <returns>処理結果</returns>
        (bool Ret, string Msg) RegisterForm(FormViewModel viewModel, string userId);
    }

    /// <summary>
    /// ToDoのModelクラス
    /// </summary>
    public class Todo : ModelBase, ITodo
    {
        /// <summary>
        /// コンストラクタ。
        /// </summary>
        /// <param name="provider">サービスプロバイダー</param>
        /// <param name="logger">ロガー</param>
        public Todo(IServiceProvider provider, ILogger<Todo> logger) : base(provider, logger)
        {
        }

        /// <summary>
        /// ToDoフォーム画面のViewModelを取得します。
        /// </summary>
        /// <param name="id">ToDoID</param>
        /// <returns>ViewModel</returns>
        public FormViewModel GetFormViewModel(int? id)
        {
            // 新規登録
            if (!id.HasValue)
            {
                return new FormViewModel();
            }

            // 編集データの取得
            var repository = provider.GetService<ITodoRepository>();
            var item = repository.GetItemById(id.Value);
            if (item == null)
            {
                // 既に削除済みの場合、新規登録として処理
                return new FormViewModel{
                    Msg = CmnResource.ErrMsgIsDeletedItem,
                    IsDeleted = true
                };
            }

            // ViewModelの生成
            var viewModel = new FormViewModel {
                Id = item.Id,
                Title = item.Title,
                DueDt = item.DueDt
            };
            return viewModel;
        }

        /// <summary>
        /// ToDoフォームを登録します。
        /// </summary>
        /// <param name="viewModel">ToDoフォーム</param>
        /// <param name="userId">ユーザーID</param>
        /// <returns>処理結果</returns>
        public (bool Ret, string Msg) RegisterForm(FormViewModel viewModel, string userId)
        {
            var repository = provider.GetService<ITodoRepository>();

            // 新規登録
            if (viewModel.Id <= 0)
            {
                repository.InsEntity(new TTodo {
                    Title = viewModel.Title,
                    DueDt= viewModel.DueDt,
                    SInsDtm = DateTime.Now,
                    SInsUsr = userId,
                    SInsClass = GetType().Name
                });
                return (true, string.Empty);
            }

            // 更新データの取得
            var target = repository.GetItemById(viewModel.Id);
            if (target == null || target.CompFlg)
            {
                return (false, TodoResource.ErrMsgClosedItem);
            }

            // 変更なし
            if (!isUpdate(target, viewModel))
            {
                return (true, string.Empty);
            }

            // 更新情報の設定
            target.Title = viewModel.Title;
            target.DueDt = viewModel.DueDt;
            target.SUpdDtm = DateTime.Now;
            target.SUpdUsr = userId;
            target.SUpdClass = GetType().Name;
            // 更新
            repository.UpdEntity(target);

            return (true, string.Empty);

            /// <summary>
            /// 更新の有無をチェックします。
            /// </summary>
            /// <param name="src">更新前データ</param>
            /// <param name="dest">更新データ</param>
            /// <returns>チェック結果</returns>
            bool isUpdate(TTodo src, FormViewModel dest)
            {
                // タイトルの変更
                if (src.Title != dest.Title)
                {
                    return true;
                }
                // 期日の変更
                if (src.DueDt != dest.DueDt)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
