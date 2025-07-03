using System.ComponentModel.DataAnnotations;
using TodoAppWeb.Resources;

namespace TodoAppWeb.ViewModels.Todo
{
    /// <summary>
    /// ToDoフォームのViewModelクラス
    /// </summary>
    public class FormViewModel : ViewModelBase
    {
        /// <summary>
        /// ToDoID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// タイトル
        /// </summary>
        [Display(Name = "LblTitle", ResourceType = typeof(TodoResource))]
        [Required(ErrorMessageResourceName = "ErrMsgRequired", ErrorMessageResourceType = typeof(CmnResource))]
        [MaxLength(40, ErrorMessageResourceName = "ErrMsgMaxLength", ErrorMessageResourceType = typeof(CmnResource))]
        public string Title { get; set; }

        /// <summary>
        /// 期限
        /// </summary>
        [Display(Name = "LblDueDt", ResourceType = typeof(TodoResource))]
        [DataType(DataType.Date)]
        [Required(ErrorMessageResourceName = "ErrMsgRequired", ErrorMessageResourceType = typeof(CmnResource))]
        [Range(typeof(DateTime), "1900/01/01", "9999/12/31", ErrorMessageResourceName = "ErrMsgDtRange", ErrorMessageResourceType = typeof(CmnResource))]
        public DateTime DueDt { get; set; } = DateTime.Today;

        /// <summary>
        /// 完了フラグ
        /// </summary>
        public bool IsCompleted { get; set; }

        /// <summary>
        /// 削除済みフラグ
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
