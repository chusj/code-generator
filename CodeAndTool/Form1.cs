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

            //��ֹ�Ŵ���С��������
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;

            //ConfigurationManager.AppSettings["FileSavePath"];

            //��ȡ���ݿ������ļ�������ȡ����
            string DbConnFile = ConfigurationManager.AppSettings["DbConnFile"];
            if (string.IsNullOrEmpty(DbConnFile))
            {
                toolStripStatusLabel1.Text = "Db�����ļ�ȱʧ";
            }
            else if (!File.Exists(DbConnFile))
            {
                toolStripStatusLabel1.Text = "�ļ�������";
            }
            else
            {
                txbDbConn.Text = DbConnFile.Trim();
                ConnStr = File.ReadAllText(DbConnFile);

                toolStripStatusLabel1.Text = "Db���ӳɹ���������ʱ�䣺" + InitDb().Ado.GetString("select sysdate from dual");
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
        /// �򿪴�������
        /// </summary>
        private void btnCode_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// ��ע�ʹ���
        /// </summary>
        private void btnComment_Click(object sender, EventArgs e)
        {

        }

        private void btnNewField_Click(object sender, EventArgs e)
        {
            MessageBox.Show("���ܿ����С���");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string folderPath = txbDbConn.Text.Trim(); // ָ���ļ���·��

            if (Directory.Exists(folderPath))
            {
                Process.Start("explorer", folderPath);
            }
            else
            {
                toolStripStatusLabel1.Text = "�ļ��в����ڣ�����·��";
            }
        }
    }
}
