namespace CodeAndTool
{
    /// <summary>
    /// 用户表，对应视图：user_tables
    /// </summary>
    public class UserTables
	{
		/// <summary>
		/// 表名
		/// </summary>
		public string table_name { get; set; }

		/// <summary>
		/// 注释
		/// </summary>
		public string comments { get; set; }

		/// <summary>
		/// 行数
		/// </summary>
		public string num_rows { get; set; }

		/// <summary>
		/// 列数
		/// </summary>
		public string num_columns { get; set;}


		/*
		 select table_name,num_rows,
		(select count(0) from user_tab_columns b where a.table_name = b.table_name) as num_columns,
		(select comments from user_tab_comments c where a.table_name = c.table_name) as comments 
		from user_tables a where table_name = 'SMS_ACCOUNT';
		order by a.table_name
		 */
	}
}
