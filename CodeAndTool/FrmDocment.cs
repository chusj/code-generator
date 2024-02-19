using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        }

        private void btnPdf_Click(object sender, EventArgs e)
        {

        }

        private void btnMarkdown_Click(object sender, EventArgs e)
        {
            string path = ConfigurationManager.AppSettings["FileSavePath"];

            string content = AppendMarkdown(SearchTableInfo());

            CreateFile(path, content);

        }

        private string AppendMarkdown(List<UserTables> tables)
        {
            StringBuilder sb = new StringBuilder();

            foreach (UserTables table in tables)
            {
                sb.AppendFormat("### {0}{1}   ", table.table_name,"\n");
                sb.AppendFormat("#### {0}   ", table.comments);
                sb.Append("\n");
            }

            return sb.ToString();
        }

        /// <summary>
        /// 创建Sql文件
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
    }
}
