﻿using SqlSugar;
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
            this.toolStripStatusLabel1.Text =  "Markdown文件创建成功，" + DateTime.Now.ToString("hh:mm:ss");
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
