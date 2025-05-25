using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoAppLibs.Entities
{
    /// <summary>
    /// ToDo情報
    /// </summary>
    [Table("t_todo")]
    public class TTodo : EntityBase
    {
        /// <summary>
        /// ToDoID
        /// </summary>
        [Column("id")]
        [Key]
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// タイトル
        /// </summary>
        [Column("title")]
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// 期限
        /// </summary>
        [Column("due_dt")]
        public DateTime DueDt
        {
            get;
            set;
        }

        /// <summary>
        /// 完了フラグ
        /// </summary>
        [Column("comp_flg")]
        public bool CompFlg
        {
            get;
            set;
        }

        /// <summary>
        /// 削除フラグ
        /// </summary>
        [Column("del_flg")]
        public bool DelFlg
        {
            get;
            set;
        }
    }
}
