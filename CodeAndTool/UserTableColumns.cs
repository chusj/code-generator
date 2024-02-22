namespace CodeAndTool
{
	/// <summary>
	/// 
	/// </summary>
	public class UserTableColumns
	{
		/// <summary>
		/// 表名
		/// </summary>
        public string table_name { get; set; }

		/// <summary>
		/// 列名
		/// </summary>
		public string column_name { get; set; }

		/// <summary>
		/// 数据类型
		/// </summary>
		public string data_type { get; set; }

		/// <summary>
		/// 数据长度
		/// </summary>
		public string data_length { get; set; }

		/// <summary>
		/// 精度
		/// </summary>
		public string data_precision { get; set; }

		/// <summary>
		/// 小数点位
		/// </summary>
		public string data_scale { get; set; }

		/// <summary>
		/// 默认值
		/// </summary>
		public object data_default { get; set; }

		/// <summary>
		/// 列id
		/// </summary>
		public int column_id { get; set; }

		/// <summary>
		/// 是否可空：N.不可空  Y.可空
		/// </summary>
		public string nullable { get; set; }

		/// <summary>
		/// 注释
		/// </summary>
		public string comments { get; set; }

		/*
		 select table_name,column_name,data_type,data_length,data_precision,data_scale,data_default,column_id,
(select comments from user_col_comments b where a.table_name = b.table_name and a.column_name = b.column_name) as comments
 from user_tab_columns a where table_name = 'SMS_ACCOUNT'
 order by a.column_id;
		 */
	}
}
