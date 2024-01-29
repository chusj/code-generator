namespace CodeAndTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //禁止放大缩小；并居中
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        /// <summary>
        /// 打开代码生成
        /// </summary>
        private void btnCode_Click(object sender, EventArgs e)
        {
           
        }

        /// <summary>
        /// 打开注释处理
        /// </summary>
        private void btnComment_Click(object sender, EventArgs e)
        {

        }

        private void btnNewField_Click(object sender, EventArgs e)
        {
            MessageBox.Show("功能开发中……");
        }
    }
}
