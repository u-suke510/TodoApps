using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using TodoAppWeb.Models;
using TodoAppWeb.ViewModels.Todo;

namespace TodoAppWeb.Controllers
{
    /// <summary>
    /// ToDoのControllerクラス
    /// </summary>
    public class TodoController : ControllerBase
    {
        private ITodo model => (ITodo)_model;

        /// <summary>
        /// コンストラクタ。
        /// </summary>
        /// <param name="model">Modelクラス</param>
        /// <param name="engine">ViewEngine</param>
        /// <param name="logger">ロガー</param>
        public TodoController(ITodo model, ICompositeViewEngine engine, ILogger<TodoController> logger) : base(model, engine, logger)
        {
        }

        /// <summary>
        /// ToDo一覧の初期表示処理を実装します。
        /// </summary>
        /// <returns>ビュー</returns>
        public IActionResult Index()
        {
            ActionLog($"Start Index.");

            return View();
        }

        /// <summary>
        /// ToDoフォームの初期表示処理を実装します。
        /// </summary>
        /// <param name="id">ToDoID</param>
        /// <returns>ビュー</returns>
        public IActionResult Form(int? id)
        {
            ActionLog($"Start Form.(id={id})");

            // 画面表示
            var viewModel = model.GetFormViewModel(id);
            return View(viewModel);
        }

        /// <summary>
        /// ToDoフォームの登録処理を実装します。
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns>ビュー</returns>
        [HttpPost]
        public IActionResult Form(FormViewModel viewModel)
        {
            ActionLog($"Register Form.({viewModel.Title})");

            // 入力値チェック
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            // 登録処理
            var result = model.RegisterForm(viewModel, "TestUser");
            if (result.Ret)
            {
                return RedirectToAction("Index");
            }

            // 登録失敗時はエラー情報を設定
            viewModel.Msg = result.Msg;
            return View(viewModel);
        }
    }
}
