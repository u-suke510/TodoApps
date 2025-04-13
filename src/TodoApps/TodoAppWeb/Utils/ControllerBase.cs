using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace TodoAppWeb
{
    /// <summary>
    /// Controllerクラスのベースクラス
    /// </summary>
    public abstract class ControllerBase : Controller
    {
        /// <summary>
        /// ViewEngine
        /// </summary>
        protected readonly ICompositeViewEngine engine;
        /// <summary>
        /// ロガー
        /// </summary>
        protected readonly ILogger logger;
        /// <summary>
        /// Modelクラス
        /// </summary>
        protected readonly IModelBase _model;

        /// <summary>
        /// コンストラクタ。
        /// </summary>
        /// <param name="model">Modelクラス</param>
        /// <param name="engine">ViewEngine</param>
        /// <param name="logger">ロガー</param>
        public ControllerBase(IModelBase model, ICompositeViewEngine engine, ILogger logger)
        {
            _model = model;
            this.engine = engine;
            this.logger = logger;
        }

        /// <summary>
        /// アクションログを出力します。
        /// </summary>
        /// <param name="message">出力メッセージ</param>
        protected void ActionLog(string message)
        {
            logger.LogInformation($"[Action] {message}");
        }

        /// <summary>
        /// ビューを文字列形式で取得する。
        /// </summary>
        /// <param name="viewName">ViewName</param>
        /// <returns>ビュー文字列</returns>
        protected string CreateViewContent(string viewName)
        {
            var viewString = string.Empty;
            using (var writer = new StringWriter())
            {
                var viewResult = engine.FindView(ControllerContext, viewName, false);
                var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, writer, new HtmlHelperOptions());
                viewResult.View.RenderAsync(viewContext);
                viewString = writer.GetStringBuilder().ToString();
            }
            return viewString;
        }
    }
}
