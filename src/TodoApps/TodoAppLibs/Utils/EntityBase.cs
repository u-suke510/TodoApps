using System.ComponentModel.DataAnnotations.Schema;

namespace TodoAppLibs
{
    /// <summary>
    /// Entityクラスのベースクラス
    /// </summary>
    public abstract class EntityBase
    {
        /// <summary>
        /// 登録日時
        /// </summary>
        [Column("s_ins_dtm")]
        public DateTime SInsDtm
        {
            get;
            set;
        }

        /// <summary>
        /// 登録ユーザー
        /// </summary>
        [Column("s_ins_usr")]
        public string SInsUsr
        {
            get;
            set;
        }

        /// <summary>
        /// 登録処理
        /// </summary>
        [Column("s_ins_class")]
        public string? SInsClass
        {
            get;
            set;
        }

        /// <summary>
        /// 更新日時
        /// </summary>
        [Column("s_upd_dtm")]
        public DateTime? SUpdDtm
        {
            get;
            set;
        }

        /// <summary>
        /// 更新ユーザー
        /// </summary>
        [Column("s_upd_usr")]
        public string? SUpdUsr
        {
            get;
            set;
        }

        /// <summary>
        /// 更新処理
        /// </summary>
        [Column("s_upd_class")]
        public string? SUpdClass
        {
            get;
            set;
        }

        /// <summary>
        /// Table属性に指定されているテーブル名を取得します。
        /// </summary>
        /// <returns>テーブル名</returns>
        public string GetTableNameByTableAttr()
        {
            var type = GetType();
            dynamic attr = type.GetCustomAttributes(false).SingleOrDefault(x => x.GetType().Name == "TableAttribute");

            return attr?.Name;
        }
    }
}
