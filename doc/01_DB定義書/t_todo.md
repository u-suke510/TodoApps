# テーブル定義書

## t_todo

ToDo情報

### columns

| 物理名称 | 論理名称 | データ型 | 初期値 | PK | ID | NN | 備考 |
|:-|:-|:-:|:-|:-:|:-:|:-:|:-|
| id | ToDoID | int || ○ | ○ | ○ ||
| title | タイトル | nvarchar(40) |||| ○ ||
| comp_flg | 完了フラグ | bit | 0 ||| ○ ||
| del_flg | 削除フラグ | bit | 0 ||| ○ ||

### indexes

| No. | 物理名称 | カラムリスト | UNIQUE |
|:-:|:-:|:-:|:-:|

## DDL

``` sql
CREATE TABLE t_todo(

  id int IDENTITY(1,1) NOT NULL,
  title nvarchar(40) NOT NULL,
  comp_flg bit DEFAULT 0 NOT NULL,
  del_flg bit DEFAULT 0 NOT NULL,
  s_ins_dtm datetime NOT NULL,
  s_ins_usr varchar(36) NOT NULL,
  s_ins_class varchar(40) NOT NULL,
  s_upd_dtm datetime,
  s_upd_usr varchar(36),
  s_upd_class varchar(40),

  CONSTRAINT PK_t_todo PRIMARY KEY (id)
);
```
