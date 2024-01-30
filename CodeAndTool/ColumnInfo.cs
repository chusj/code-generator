namespace CodeAndTool
{
	/// <summary>
	/// 列信息
	/// </summary>
	public class ColumnInfo
    {
		/// <summary>
		/// 表名
		/// </summary>
		public string table_name {  get; set; }

		/// <summary>
		/// 列名
		/// </summary>
		public string column_name { get; set; }

		/// <summary>
		/// 字段说明
		/// </summary>
		public string comments { get; set; }

		/// <summary>
		/// 数据类型
		/// </summary>
		public string data_type { get; set; }

		/// <summary>
		/// 长度
		/// </summary>
		public string data_length { get; set; }

		/// <summary>
		/// 可空
		/// </summary>
		public string nullable { get; set; }

		/// <summary>
		/// 精度
		/// </summary>
		public string data_precision { get; set; }

		/// <summary>
		/// 小数点位
		/// </summary>
		public string data_scale { get; set; }

	}
}
