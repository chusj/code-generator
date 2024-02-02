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
            string path = ConfigurationManager.AppSettings["FileSavePath"];
            string fileName = ConfigurationManager.AppSettings["DbConnFile"];
            string fullName = path + fileName;
            if (string.IsNullOrEmpty(path) || string.IsNullOrEmpty(fileName))
            {
                toolStripStatusLabel1.Text = "Db�����ļ�ȱʧ";
            }
            else if (!File.Exists(fullName))
            {
                toolStripStatusLabel1.Text = "�ļ�������";
            }
            else
            {
                txbDbConn.Text = fullName.Trim();
                ConnStr = File.ReadAllText(txbDbConn.Text);

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
            FrmCode code = new FrmCode(ConnStr);
            code.Show();
        }

        /// <summary>
        /// ��ע�ʹ���
        /// </summary>
        private void btnComment_Click(object sender, EventArgs e)
        {
            FrmComment code = new FrmComment(ConnStr);
            code.Show();
        }

        private void btnNewField_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("���ܿ����С���");
            FrmDocment code = new FrmDocment(ConnStr);
            code.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string folderPath = ConfigurationManager.AppSettings["FileSavePath"].Trim(); // ָ���ļ���·��

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
