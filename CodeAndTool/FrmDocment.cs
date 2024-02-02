using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        }

        private void SearchTableInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" SELECT b.table_name,a.comments");
            sb.Append(" FROM user_tab_comments a,user_tables b where a.table_name = b.table_name");
            
            sb.Append(" order by a.table_name");
            

            DataTable dt = InitDb().Ado.GetDataTable(sb.ToString());
        }
    }
}
