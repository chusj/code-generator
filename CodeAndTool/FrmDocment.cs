using SqlSugar;
using System.Configuration;
using System.Data;
using System.Text;

namespace CodeAndTool
{
    public partial class FrmDocment : Form
    {
        private string ConnStr = string.Empty;

        public FrmDocment(string connStr)
        {
            InitializeComponent();
            ConnStr = connStr;

            txbConnstr.Text = connStr;
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

        private void btnWord_Click(object sender, EventArgs e)
        {

        }

        private void btnHtml_Click(object sender, EventArgs e)
        {
            string diskPath = ConfigurationManager.AppSettings["FileSavePath"];
            string fileName = DateTime.Now.ToString("yyyy-MM-dd") + ".html"; //处理文件名
            string filePath = Path.Combine(diskPath, fileName);
            string content = AppendHtml(SearchTableInfo());

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(content);
            }
        }

        private string AppendHtml(List<UserTables> tables)
        {
            StringBuilder sb = new StringBuilder();        //主html

            sb.AppendLine("<!DOCTYPE html>");
            sb.AppendLine("<html>");

            sb.AppendLine("<head>");
            sb.AppendLine("<meta charset=\"utf-8\"> ");
            sb.AppendLine("<title>数据库说明文档,HTML格式</title>");
            sb.AppendLine("<link rel=\"stylesheet\" href=\"https://cdn.staticfile.org/twitter-bootstrap/3.3.7/css/bootstrap.min.css\"> ");
            sb.AppendLine("<script src=\"https://cdn.staticfile.org/jquery/2.1.1/jquery.min.js\"></script>");
            sb.AppendLine("<script src=\"https://cdn.staticfile.org/twitter-bootstrap/3.3.7/js/bootstrap.min.js\"></script>");
            sb.AppendLine("</head>");

            sb.AppendLine("<body>");
            sb.AppendLine("<div class=\"container\">");   //div开始1
            sb.AppendLine("<div class=\"row clearfix\">");//div开始2

            //左侧导航
            sb.AppendLine("<div class=\"col-md-4 column\">");
            sb.AppendLine("<ol>");
            foreach (UserTables t in tables)
            {
                sb.Append(AppendHtmlNavModule(t.table_name));
            }
            sb.AppendLine("</ol>");
            sb.AppendLine("</div>");

            //右侧内容
            sb.AppendLine("<div class=\"col-md-8 column\">");
            foreach (UserTables t in tables)
            {
                sb.Append(AppendHtmlContentModule(t.table_name, t.comments));
            }
            sb.AppendLine("</div>");


            //结尾
            sb.AppendLine("</div>");  //div结束2
            sb.AppendLine("</div>");  //div结束1
            sb.AppendLine("</body>");
            sb.AppendLine("</html>");

            return sb.ToString();
        }

        /// <summary>
        /// HTML中，导航模块
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        private string AppendHtmlNavModule(string tableName)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<li>");
            sb.AppendFormat("<a href=\"#{0}\">{1}</a></li>", tableName, tableName);
            sb.AppendLine("</li>");
            return sb.ToString();
        }

        /// <summary>
        /// HTML中，内容模块(N个表格)
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        private string AppendHtmlContentModule(string tableName, string comments)
        {
            StringBuilder sb = new StringBuilder();

            //表格上方的表名和注释
            sb.AppendFormat("<h3 id=\"{0}\">{1}</h3>", tableName, tableName);
            sb.AppendFormat("<p>{0}</p>", comments);
            sb.AppendLine(" <table class=\"table\">");

            //表头
            sb.AppendLine("<thead>" +
                "<tr><th>字段</th>" +
                "<th>类型（长度）</th>" +
                "<th>说明</th></tr> </thead>");

            //表格内容
            sb.AppendLine("<tbody>");
            List<UserTableColumns> columns = SearchFieldInfo(tableName);
            foreach (UserTableColumns col in columns)
            {
                sb.AppendFormat("<tr>" +
                    "<td>{0}</td>" +
                    "<td>{1}</td>" +
                    "<td>{2}</td></tr>", col.column_name, col.data_type, col.comments);

                sb.AppendLine();   //一行html后主动换行
            }
            sb.AppendLine("</tbody>");

            sb.AppendLine("</table>");
            return sb.ToString();
        }

        private void btnPdf_Click(object sender, EventArgs e)
        {

        }

        private void btnMarkdown_Click(object sender, EventArgs e)
        {
            string path = ConfigurationManager.AppSettings["FileSavePath"];

            string content = AppendMarkdown(SearchTableInfo());

            CreateFile(path, content);
            this.toolStripStatusLabel1.Text = "Markdown文件创建成功，" + DateTime.Now.ToString("hh:mm:ss");
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.Green;
        }

        /// <summary>
        /// 拼接Markdown
        /// </summary>
        /// <param name="tables"></param>
        /// <returns></returns>
        private string AppendMarkdown(List<UserTables> tables)
        {
            string NewLine = "\n";
            StringBuilder sb = new StringBuilder();

            foreach (UserTables table in tables)
            {
                //表名和注释
                sb.AppendFormat("### {0}{1} ", table.table_name, NewLine);
                sb.AppendFormat("#### {0}{1} ", table.comments, NewLine);


                //表头
                sb.Append("| 字段名 | 类型(长度) | 说明 |");
                sb.Append('\n');
                sb.Append("| --- | --- | --- |");
                sb.Append('\n');

                //字段
                List<UserTableColumns> columns = SearchFieldInfo(table.table_name);
                foreach (UserTableColumns column in columns)
                {
                    string length = column.data_length;
                    if (column.data_type == "NUMBER")  //NUMBER类型使用精度 + 长度
                    {
                        length = column.data_precision + "," + column.data_scale;
                    }
                    sb.AppendFormat("| {0} | {1}({2}) | {3} |", column.column_name, column.data_type, length, FrmCode.RemoveNewLine(column.comments));
                    sb.Append('\n');
                }

                sb.Append('\n');

                /* markdown 表格语法
                | 列标题1 | 列标题2 | 列标题3 |
                | --- | --- | --- |
                | 单元格内容1 | 单元格内容2 | 单元格内容3 |
                | 单元格内容4 | 单元格内容5 | 单元格内容6 |
                 */
            }

            return sb.ToString();
        }

        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="diskPath"></param>
        /// <param name="content">内容</param>
        private void CreateFile(string diskPath, string content)
        {
            string fileName = DateTime.Now.ToString("yyyy-MM-dd") + ".md"; //处理文件名
            string filePath = Path.Combine(diskPath, fileName);

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(content);
            }
        }

        /// <summary>
        /// 查询表信息
        /// </summary>
        /// <returns></returns>
        private List<UserTables> SearchTableInfo()
        {
            List<UserTables> tables = new List<UserTables>();

            StringBuilder sb = new StringBuilder();
            sb.Append(" SELECT b.table_name,a.comments");
            sb.Append(" FROM user_tab_comments a,user_tables b where a.table_name = b.table_name");
            sb.Append(" order by a.table_name");


            DataTable dt = InitDb().Ado.GetDataTable(sb.ToString());

            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                if (i > 10)
                {
                    break;
                }
                UserTables userTables = new UserTables();
                userTables.table_name = dr[0].ToString();
                userTables.comments = dr[1].ToString();

                tables.Add(userTables);

                i++;
            }

            return tables;
        }

        /// <summary>
        /// 查询字段信息
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        private List<UserTableColumns> SearchFieldInfo(string tableName)
        {
            //2.获取列信息
            StringBuilder sb = new StringBuilder();
            sb.Append("select table_name, column_name, data_type, data_length, data_precision, data_scale, data_default, column_id,");
            sb.Append("(select comments from user_col_comments b where a.table_name = b.table_name and a.column_name = b.column_name) as comments");
            sb.AppendFormat(" from user_tab_columns a where table_name = '{0}' order by a.column_id", tableName);

            List<UserTableColumns> columnList = InitDb().Ado.SqlQuery<UserTableColumns>(sb.ToString());

            return columnList;
        }
    }
}
