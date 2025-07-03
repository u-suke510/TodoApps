namespace TodoAppWeb.ViewModels.Todo
{
    /// <summary>
    /// ToDo一覧のViewModelクラス
    /// </summary>
    public class IndexViewModel : ViewModelBase
    {
        /// <summary>
        /// ToDo一覧アイテム
        /// </summary>
        public List<ListItem> Items { get; } = new List<ListItem>();

        /// <summary>
        /// ToDo一覧アイテムクラス
        /// </summary>
        public class ListItem
        {
            /// <summary>
            /// ToDoID
            /// </summary>
            public int Id { get; set; }

            /// <summary>
            /// タイトル
            /// </summary>
            public string Title { get; set; }

            /// <summary>
            /// 期限
            /// </summary>
            public DateTime DueDt { get; set; }
        }
    }
}
