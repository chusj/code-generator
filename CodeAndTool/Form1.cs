namespace CodeAndTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //��ֹ�Ŵ���С��������
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
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
    }
}
