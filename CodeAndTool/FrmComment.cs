using SqlSugar;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Text;

namespace CodeAndTool
{
    public partial class FrmComment : Form
    {
        /// <summary>
		/// Db连接字符串
		/// </summary>
		private string ConnStr = string.Empty;

        public FrmComment(string connStr)
        {
            InitializeComponent();

            ConnStr = connStr;

            // 设置窗体禁用调整大小
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            //设置焦点
            this.txbTableName.Select();

            //ListBox默认禁用
            listBox1.Enabled = false;

            txbPath.Text = ConfigurationManager.AppSettings["FileSavePath"];

            OperationTips("Db连接成功，服务器时间：" + InitDb().Ado.GetString("select sysdate from dual"));
        }


        private SqlSugarClient InitDb()
        {
            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
            {
                DbType = SqlSugar.DbType.Oracle,
                ConnectionString = ConnStr,
                IsAutoCloseConnection = true
            });

            return db;
        }

        #region 事件

        /// <summary>
        /// 查询
        /// </summary>
        private void BtnSearch_Click(object sender, EventArgs e)
        {

            SqlSugarClient db = InitDb();

            StringBuilder sb = new StringBuilder();
            sb.Append(" select table_name,num_rows from user_tables where 1 = 1");
            if (!string.IsNullOrEmpty(txbTableName.Text.Trim()))
            {
                sb.Append(" and table_name like '" + txbTableName.Text.Trim().ToUpper() + "%'");
            }
            sb.Append(" order by table_name");

            DataTable dt = db.Ado.GetDataTable(sb.ToString());

            listBox1.DataSource = dt;
            listBox1.DisplayMember = "table_name"; // 设置显示的列名
            listBox1.ValueMember = "table_name"; // 设置值的列名

            if (dt.Rows.Count > 0)
            {
                listBox1.Enabled = true;
            }
            OperationTips("查询成功,数据条数:" + dt.Rows.Count);
        }

        /// <summary>
        /// 单击，查看表注释
        /// </summary>
        private void listBox1_Click(object sender, EventArgs e)
        {
            string selectedValue = listBox1.SelectedValue.ToString();

            if (!txbCode.Text.Contains(selectedValue))
            {
                txbCode.Text += AppendTableComments(selectedValue); //拼接多个表的注释，并避免重复
            }

            OperationTips("单击了表" + selectedValue);
        }

        /// <summary>
        /// 双击，查看字段注释
        /// </summary>
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            string selectedValue = listBox1.SelectedValue.ToString();

            txbCode.Text = AppendColumnComments(selectedValue);

            OperationTips("双击了表" + selectedValue);

        }

        /// <summary>
        /// 多个表，创建文件
        /// </summary>
        private void BtnCreateFile_Click(object sender, EventArgs e)
        {
            string path = txbPath.Text.Trim();
            if (CheckPath(path))
            {
                int i = 0;

                StringBuilder sb = new StringBuilder();
                StringBuilder sbSqlScript1 = new StringBuilder();
                StringBuilder sbSqlScript2 = new StringBuilder();
                foreach (var item in listBox1.Items)
                {
                    if (item is System.Data.DataRowView dataRowView)
                    {
                        DataRowView rowView = dataRowView;
                        string tableName = rowView["table_name"].ToString();

                        sb.Append("--" + tableName);
                        sb.Append("\r\n");
                        sb.Append(AppendTableComments(tableName, false));
                        sb.Append(AppendColumnComments(tableName, false));


                        if (chkTable.Checked)
                        {
                            sbSqlScript1.Append(AppendTableComments(tableName, true));
                        }
                        if (chkColumn.Checked)
                        {
                            sbSqlScript2.Append(AppendColumnComments(tableName, true));
                            sb.Append("\r\n");
                        }
                    }
                }

                CreateSqlFile(path, "_1.备份表和字段的注释", sb.ToString());
                i++;

                if (!string.IsNullOrEmpty(sbSqlScript1.ToString()))
                {
                    CreateSqlFile(path, "_2.清空表注释", sbSqlScript1.ToString());
                    i++;
                }
                if (!string.IsNullOrEmpty(sbSqlScript2.ToString()))
                {
                    CreateSqlFile(path, "_3.清空列注释", sbSqlScript2.ToString());
                    i++;
                }
                OperationTips(i + "个文件,创建成功");
            }
        }

        #endregion

        #region 生成Sql脚本文件


        /// <summary>
        /// 创建Sql文件
        /// </summary>
        /// <param name="diskPath"></param>
        /// <param name="tableName"></param>
        /// <param name="content">内容</param>
        private void CreateSqlFile(string diskPath, string tableName, string content)
        {
            string fileName = DateTime.Now.ToString("yyyy-mm-dd") + tableName + ".sql"; //处理文件名
            string filePath = Path.Combine(diskPath, fileName);

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(content);
            }
        }

        /// <summary>
        /// 拼接表的注释
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="deleteComments">删除注释</param>
        /// <returns>可执行sql语句</returns>
        private string AppendTableComments(string tableName, bool deleteComments = false)
        {
            SqlSugarClient db = InitDb();

            //2.获取表信息
            StringBuilder sb = new StringBuilder();
            sb.Append(" select table_name,num_rows,");
            sb.Append(" (select count(0) from user_tab_columns b where a.table_name = b.table_name) as num_columns,");
            sb.Append(" (select comments from user_tab_comments c where a.table_name = c.table_name) as comments");
            sb.Append(" from user_tables a where 1 = 1");
            if (!string.IsNullOrEmpty(tableName))
            {
                sb.Append(" and table_name = '" + tableName.ToUpper() + "'");
            }
            sb.Append(" order by a.table_name");

            List<UserTables> tableList = db.Ado.SqlQuery<UserTables>(sb.ToString());


            //拼接内容
            StringBuilder sbSqlScript = new StringBuilder();
            foreach (UserTables table in tableList)
            {
                sbSqlScript.Append("comment on table ");
                sbSqlScript.Append(table.table_name);
                if (deleteComments)
                {
                    sbSqlScript.Append(" is '';");
                }
                else
                {
                    sbSqlScript.AppendFormat(" is '{0}';", RemoveNewLine(table.comments));
                }
                sbSqlScript.Append("\r\n");
            }

            return sbSqlScript.ToString();
        }

        /// <summary>
        /// 拼接列的注释
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="deleteComments">删除注释</param>
        /// <returns>可执行sql语句</returns>
        private string AppendColumnComments(string tableName, bool deleteComments = false)
        {
            SqlSugarClient db = InitDb();

            //2.获取列信息
            StringBuilder sb = new StringBuilder();
            sb.Append("select table_name, column_name, data_type, data_length, data_precision, data_scale, data_default, column_id,");
            sb.Append("(select comments from user_col_comments b where a.table_name = b.table_name and a.column_name = b.column_name) as comments");
            sb.AppendFormat(" from user_tab_columns a where table_name = '{0}' order by a.column_id", tableName);

            List<UserTableColumns> columnList = db.Ado.SqlQuery<UserTableColumns>(sb.ToString());

            //拼接内容
            StringBuilder sbSqlScript = new StringBuilder();
            sbSqlScript.AppendFormat("/* 处理表：{0} 的字段注释 */", tableName);
            sbSqlScript.Append("\r\n");
            foreach (UserTableColumns col in columnList)
            {
                //拼接
                sbSqlScript.Append("comment on column ");
                sbSqlScript.Append(col.table_name);
                sbSqlScript.Append(".");
                sbSqlScript.Append(col.column_name);
                if (deleteComments)
                {
                    sbSqlScript.AppendFormat(" is ''");
                }
                else
                {
                    sbSqlScript.AppendFormat(" is '{0}';", RemoveNewLine(col.comments));
                }
                sbSqlScript.Append("\r\n");
            }

            return sbSqlScript.ToString();
        }

        /// <summary>
        /// 处理表名或字段名称
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns></returns>
        private string ProcessTableNameOrColumnName(string name)
        {
            string NewName = string.Empty;

            if (name.IndexOf('_') > 1)
            {
                string[] strArray = name.Split('_');
                foreach (string str in strArray)
                {
                    NewName += CapitalizeFirstLetter(str);
                }
            }
            else
            {
                NewName = CapitalizeFirstLetter(name);
            }
            return NewName;
        }

        /// <summary>
        /// 首字母大写
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static string CapitalizeFirstLetter(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            char[] chars = input.ToCharArray();
            chars[0] = char.ToUpper(chars[0]);

            for (int i = 1; i < chars.Length; i++)
            {
                chars[i] = char.ToLower(chars[i]);
            }

            return new string(chars);
        }

        /// <summary>
        /// 移除字符串换行符后面的内容
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string RemoveNewLine(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            int index = input.IndexOf(Environment.NewLine); // \r\n

            if (index != -1)
            {
                return input.Substring(0, index);
            }
            else
            {
                index = input.IndexOf('\n');
                if (index != -1)
                {
                    return input.Substring(0, index);
                }
                else
                {
                    return input;
                }
            }
        }

        #endregion

        #region 其他方法

        /// <summary>
        /// 检查路径
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private bool CheckPath(string path)
        {
            bool flag = false;

            if (string.IsNullOrEmpty(path))
            {
                this.toolStripStatusLabel1.Text = "路径不可为空，" + DateTime.Now.ToString("hh:mm:ss");
                this.toolStripStatusLabel1.BackColor = System.Drawing.Color.Orange;
            }
            else if (!Directory.Exists(path))
            {
                this.toolStripStatusLabel1.Text = "路径不存在，" + DateTime.Now.ToString("hh:mm:ss");
                this.toolStripStatusLabel1.BackColor = System.Drawing.Color.Red;
            }
            else
            {
                flag = true;
            }

            return flag;
        }

        /// <summary>
        /// 操作提醒
        /// </summary>
        /// <returns></returns>
        private void OperationTips(string msg)
        {
            this.toolStripStatusLabel1.Text = msg + "，" + DateTime.Now.ToString("hh:mm:ss");
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.Green;
        }

        /// <summary>
        /// 打开路径
        /// </summary>
        private void label4_DoubleClick(object sender, EventArgs e)
        {
            string folderPath = txbPath.Text.Trim(); // 指定文件夹路径
            if (Directory.Exists(folderPath))
            {
                Process.Start("explorer", folderPath);
            }
            else
            {
                OperationTips("文件夹不存在，请检查路径");
            }
        }

        #endregion
    }
}
