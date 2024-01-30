using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace CodeAndTool
{
    public partial class FrmCode : Form
    {
        /// <summary>
		/// Db连接字符串
		/// </summary>
		public string ConnStr { get; set; }

        /// <summary>
        /// 视图对象后缀(默认)
        /// </summary>
        private string SuffixViewObjDefault = "Vo";

        /// <summary>
        /// 请求对象后缀(默认)
        /// </summary>
        private string SuffixRequestObjDefault = "Request";

        /// <summary>
        /// 视图对象后缀
        /// </summary>
        private string SuffixViewObj = ConfigurationManager.AppSettings["ViewObjSuffix"];

        /// <summary>
        /// 请求对象后缀
        /// </summary>
        private string SuffixRequestObj = ConfigurationManager.AppSettings["RequestObjSuffix"];

        /// <summary>
        /// 视图对象和请求对象，过滤的字段
        /// </summary>
        private List<string> FilterFieldList = ConfigurationManager.AppSettings["FilterFields"].Split(',').ToList();


        public FrmCode(string connstr)
        {
            InitializeComponent();

            ConnStr = connstr;

            // 设置窗体禁用调整大小
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            //设置焦点
            this.txbTableName.Select();

            //设置命名空间
            txbNameSpace.Text = ConfigurationManager.AppSettings["NameSpace"];

            //ListBox默认禁用
            listBox1.Enabled = false;

            txbPath.Text = ConfigurationManager.AppSettings["FileSavePath"];

            //配置了后缀名，默认选中2个视图代码
            if (!string.IsNullOrEmpty(SuffixRequestObj))
            {
                chkRequestEntity.Checked = true;
            }
            if (!string.IsNullOrEmpty(SuffixViewObj))
            {
                chkViewEntity.Checked = true;
            }

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
            sb.Append(" SELECT b.table_name,a.comments");
            sb.Append(" FROM user_tab_comments a,user_tables b where a.table_name = b.table_name");
            if (!string.IsNullOrEmpty(txbTableName.Text.Trim()))
            {
                sb.Append(" and b.table_name like '" + txbTableName.Text.Trim().ToUpper() + "%'");
            }
            sb.Append(" order by a.table_name");
            if (string.IsNullOrEmpty(txbTableName.Text.Trim()))
            {
                sb.Append(" OFFSET 1 ROWS FETCH NEXT 20 ROWS ONLY"); //无查询条件，按照顺序最多加载20个表
            }

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
        /// 单击，查看数据库实体
        /// </summary>
        private void listBox1_Click(object sender, EventArgs e)
        {
            string selectedValue = listBox1.SelectedValue.ToString();

            txbCode.Text = AppendClassFile(selectedValue, true, string.Empty);

            OperationTips("单击了表" + selectedValue);
        }

        /// <summary>
        /// 双击，查看视图实体
        /// </summary>
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            string selectedValue = listBox1.SelectedValue.ToString();

            //视图对象后缀
            string suffix = "Vo";
            if (!string.IsNullOrEmpty(SuffixViewObj))
            {
                suffix = SuffixViewObj;
            }

            //请求对象后缀
            if (chkRequestEntity.Checked)
            {
                suffix = "Request";
                if (!string.IsNullOrEmpty(SuffixRequestObj))
                {
                    suffix = SuffixRequestObj;
                }
            }

            txbCode.Text = AppendClassFile(selectedValue, false, suffix);

            OperationTips("双击了表" + selectedValue);
        }

        /// <summary>
        ///  单个表，保存文件
        /// </summary>
        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            int i = 0;
            string tableName = listBox1.SelectedValue.ToString();

            CreateFile(tableName, out i);

            OperationTips(i + "文件保存成功");

        }

        /// <summary>
        /// 多个表，创建文件
        /// </summary>
        private void BtnCreateFile_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (var item in listBox1.Items)
            {
                if (item is System.Data.DataRowView dataRowView)
                {
                    DataRowView rowView = dataRowView;
                    string tableName = rowView["table_name"].ToString();

                    CreateFile(tableName, out i);
                }
            }

            OperationTips(i + "个文件,创建成功");
        }

        #endregion

        #region 生成类文件

        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="nums">返回参数：创建的文件数目</param>
        private void CreateFile(string tableName, out int nums)
        {
            int i = 0;
            string path = txbPath.Text.Trim();
            if (CheckPath(path))
            {
                if (chkViewEntity.Checked)   //视图对象
                {
                    i++;
                    CreateClassFile(path, tableName, false, string.IsNullOrEmpty(SuffixViewObj) ? SuffixViewObjDefault : SuffixViewObj);
                }
                if (chkRequestEntity.Checked) //请求对象
                {
                    i++;
                    CreateClassFile(path, tableName, false, string.IsNullOrEmpty(SuffixRequestObj) ? SuffixRequestObjDefault : SuffixRequestObj);
                }
                if (chkDbEntity.Checked)     //Db对象
                {
                    CreateClassFile(path, tableName, true, string.Empty);
                    i++;
                }
            }
            nums = i;
        }


        /// <summary>
        /// 创建类文件
        /// </summary>
        /// <param name="diskPath"></param>
        /// <param name="tableName"></param>
        /// <param name="IsDbEntity"></param>
        /// <param name="suffix"></param>
        private void CreateClassFile(string diskPath, string tableName, bool IsDbEntity, string suffix = "")
        {
            string fileName = ProcessTableNameOrColumnName(tableName) + suffix + ".cs"; //处理文件名
            string filePath = Path.Combine(diskPath, fileName);
            string content = AppendClassFile(tableName, IsDbEntity, suffix);

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(content);
            }
        }

        /// <summary>
        /// 拼接类文件
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        private string AppendClassFile(string tableName, bool IsDbEntity = true, string csFileNameSuffix = "")
        {
            SqlSugarClient db = InitDb();

            //1.获取注释
            string comments = db.Ado.GetString("SELECT comments FROM user_tab_comments where table_name = '" + tableName.ToUpper() + "';");

            //2.获取列
            StringBuilder sb = new StringBuilder();
            sb.Append(" SELECT a.table_name,a.column_id,a.column_name, b.comments,data_type, data_length,a.nullable,a.data_precision,a.data_scale");
            sb.Append(" FROM user_tab_columns a,user_col_comments b");
            sb.Append(" WHERE a.table_name = b.table_name and a.column_name = b.column_name");
            sb.Append(" and a.table_name = '" + tableName.ToUpper() + "'");
            sb.Append(" order by a.column_id;");

            List<ColumnInfo> columns = db.Ado.SqlQuery<ColumnInfo>(sb.ToString());

            //拼接内容
            StringBuilder sb2 = new StringBuilder();

            if (IsDbEntity)  //引用sqlsguar
            {
                sb2.Append("using SqlSugar;");
                sb2.Append("\r\n");
                sb2.Append("\r\n"); //空一行
            }

            //命名空间
            sb2.Append("namespace " + txbNameSpace.Text.Trim());
            sb2.Append("\r\n");
            sb2.Append("{");    //括弧1
            sb2.Append("\r\n");

            ///类注释和申明
            sb2.Append(AppendAnnotate(comments));


            if (IsDbEntity) //申明
            {
                sb2.Append("	[SugarTable(\"" + tableName + "\")]");
                sb2.Append("\r\n");
            }

            sb2.Append("	public class " + ProcessTableNameOrColumnName(tableName) + csFileNameSuffix); //处理类名
            sb2.Append("\r\n");
            sb2.Append("	{"); //括弧2

            //列对应字段信息
            foreach (var column in columns)
            {
                if (!IsDbEntity && IsFilterField(column.column_name))
                {
                    continue;
                }
                else
                {
                    sb2.Append("		" + AppendField(column, IsDbEntity));
                }
            }
            sb2.Append("	}"); //括弧2结束
            sb2.Append("\r\n");
            sb2.Append("}");     //括弧1结束

            return sb2.ToString();
        }

        /// <summary>
        /// 是否为过滤字段
        /// </summary>
        /// <param name="columnName">列名</param>
        /// <returns>true 是要过滤的字段，false 不是过滤字段</returns>
        private bool IsFilterField(string columnName)
        {
            bool flag = false;

            foreach (var field in FilterFieldList)
            {
                if (field.ToUpper() == columnName.ToUpper())
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }

        /// <summary>
        /// 拼接字段
        /// </summary>
        /// <param name="column">列信息</param>
        /// <returns></returns>
        private string AppendField(ColumnInfo column, bool IsDbEntity = true)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\r\n");
            sb.Append(AppendAnnotate(column.comments, 2));  //字段的注释
            if (IsDbEntity)
            {
                if (column.column_name.ToLower() == "id")
                {
                    sb.Append("		[SugarColumn(ColumnName = \"" + column.column_name + "\", IsNullable = false, IsPrimaryKey = true)]");
                }
                else
                {
                    sb.Append("		[SugarColumn(ColumnName = \"" + column.column_name + "\")]");
                }

                sb.Append("\r\n");
            }
            sb.Append("		public " + ConvertDbFiledType(column) + " " + ProcessTableNameOrColumnName(column.column_name) + " { get; set; }");
            sb.Append("\r\n");
            return sb.ToString();
        }

        /// <summary>
        /// 转换数据库字段类型
        /// </summary>
        /// <param name="dataType">数据类型</param>
        /// <returns>C# 类型</returns>
        public string ConvertDbFiledType(ColumnInfo column)
        {

            if (column.data_type.ToUpper() == "CHAR" ||
                column.data_type.ToUpper() == "VARCHAR2" ||
                column.data_type.ToUpper() == "CLOB")
            {
                return "string";
            }
            else if (column.data_type.ToUpper() == "NUMBER")
            {
                if (Convert.ToInt32(column.data_scale) == 0)
                {
                    return "int";
                }
                else
                {
                    /* 三种类型信息
					 * decimal类型：这是一种精确的十进制数类型，具有128位的存储空间，范围广，非常适合财务计算等需要高精度计算的场景。
					 * double类型：这是一种双精度浮点数类型，具有64位的存储空间，精度较高，但不如decimal类型精确。
					 * float类型：这是一种单精度浮点数类型，具有32位的存储空间，精度较低，但占用的存储空间更少。
					 */
                    return "float";
                }
            }
            else if (column.data_type.ToUpper().Contains("DATE"))
            {
                return "DateTime";
            }
            else
            {
                return "unknow";
            }
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
        /// 拼接注释
        /// </summary>
        /// <param name="annotate">注释</param>
        /// <param name="type">1.类注释 2.列注释</param>
        /// <returns></returns>
        private string AppendAnnotate(string annotate, int type = 1)
        {

            string TabStr = string.Empty;
            if (type == 2) //拼接列注释时，多增加一层缩进
            {
                TabStr = "	";
            }
            StringBuilder sb = new StringBuilder();
            sb.Append(TabStr + @"	/// <summary>");
            sb.Append("\r\n");
            sb.Append(TabStr + @"	/// " + RemoveNewLine(annotate));
            sb.Append("\r\n");
            sb.Append(TabStr + @"	/// </summary>");
            sb.Append("\r\n");
            return sb.ToString();
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
