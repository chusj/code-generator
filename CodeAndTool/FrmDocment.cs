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
    }
}
