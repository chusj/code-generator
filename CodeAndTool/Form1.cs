using SqlSugar;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Text;

namespace CodeAndTool
{
    public partial class Form1 : Form
    {
        private string ConnStr;

        public Form1()
        {
            InitializeComponent();

            //禁止放大缩小；并居中
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;

            //ConfigurationManager.AppSettings["FileSavePath"];

            //读取数据库连接文件，并读取内容
            string path = ConfigurationManager.AppSettings["FileSavePath"];
            string fileName = ConfigurationManager.AppSettings["DbConnFile"];
            string fullName = path + fileName;
            if (string.IsNullOrEmpty(path) || string.IsNullOrEmpty(fileName))
            {
                toolStripStatusLabel1.Text = "Db配置文件缺失";
            }
            else if (!File.Exists(fullName))
            {
                toolStripStatusLabel1.Text = "文件不存在";
            }
            else
            {
                txbDbConn.Text = fullName.Trim();
                ConnStr = File.ReadAllText(txbDbConn.Text);

                toolStripStatusLabel1.Text = "Db连接成功，服务器时间：" + InitDb().Ado.GetString("select sysdate from dual");
            }
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

        /// <summary>
        /// 打开代码生成
        /// </summary>
        private void btnCode_Click(object sender, EventArgs e)
        {
            FrmCode code = new FrmCode(ConnStr);
            code.Show();
        }

        /// <summary>
        /// 打开注释处理
        /// </summary>
        private void btnComment_Click(object sender, EventArgs e)
        {
            FrmComment code = new FrmComment(ConnStr);
            code.Show();
        }

        private void btnNewField_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("功能开发中……");
            FrmDocment code = new FrmDocment(ConnStr);
            code.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string folderPath = ConfigurationManager.AppSettings["FileSavePath"].Trim(); // 指定文件夹路径

            if (Directory.Exists(folderPath))
            {
                Process.Start("explorer", folderPath);
            }
            else
            {
                toolStripStatusLabel1.Text = "文件夹不存在，请检查路径";
            }
        }
    }
}
