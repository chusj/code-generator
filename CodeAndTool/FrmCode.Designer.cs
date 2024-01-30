namespace CodeAndTool
{
    partial class FrmCode
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {

            listBox1 = new ListBox();
            txbTableName = new TextBox();
            BtnSearch = new Button();
            txbCode = new TextBox();
            label1 = new Label();
            label2 = new Label();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            BtnCreateFile = new Button();
            txbNameSpace = new TextBox();
            label3 = new Label();
            txbPath = new TextBox();
            label4 = new Label();
            btnSaveFile = new Button();
            chkViewEntity = new CheckBox();
            chkRequestEntity = new CheckBox();
            chkDbEntity = new CheckBox();
            statusStrip1.SuspendLayout();
            SuspendLayout();

            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(50, 169);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(414, 531);
            listBox1.TabIndex = 0;
            listBox1.Click += listBox1_Click;
            listBox1.DoubleClick += listBox1_DoubleClick;
            // 
            // txbTableName
            // 
            txbTableName.Location = new Point(50, 103);
            txbTableName.Name = "txbTableName";
            txbTableName.Size = new Size(237, 38);
            txbTableName.TabIndex = 1;
            // 
            // BtnSearch
            // 
            BtnSearch.Location = new Point(314, 98);
            BtnSearch.Name = "BtnSearch";
            BtnSearch.Size = new Size(150, 46);
            BtnSearch.TabIndex = 2;
            BtnSearch.Text = "查询";
            BtnSearch.UseVisualStyleBackColor = true;
            BtnSearch.Click += BtnSearch_Click;
            // 
            // txbCode
            // 
            txbCode.Location = new Point(506, 98);
            txbCode.Multiline = true;
            txbCode.Name = "txbCode";
            txbCode.ScrollBars = ScrollBars.Both;
            txbCode.Size = new Size(1085, 767);
            txbCode.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(50, 42);
            label1.Name = "label1";
            label1.Size = new Size(397, 31);
            label1.TabIndex = 4;
            label1.Text = "输入表名模糊查询（like' name%'）";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(506, 42);
            label2.Name = "label2";
            label2.Size = new Size(207, 31);
            label2.TabIndex = 5;
            label2.Text = "生成的Model代码";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(32, 32);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 962);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1619, 41);
            statusStrip1.TabIndex = 6;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(182, 31);
            toolStripStatusLabel1.Text = "数据库连接状态";
            // 
            // BtnCreateFile
            // 
            BtnCreateFile.Location = new Point(50, 888);
            BtnCreateFile.Name = "BtnCreateFile";
            BtnCreateFile.Size = new Size(414, 55);
            BtnCreateFile.TabIndex = 7;
            BtnCreateFile.Text = "批量创建";
            BtnCreateFile.UseVisualStyleBackColor = true;
            BtnCreateFile.Click += BtnCreateFile_Click;
            // 
            // txbNameSpace
            // 
            txbNameSpace.Location = new Point(50, 772);
            txbNameSpace.Name = "txbNameSpace";
            txbNameSpace.Size = new Size(414, 38);
            txbNameSpace.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(50, 724);
            label3.Name = "label3";
            label3.Size = new Size(246, 31);
            label3.TabIndex = 9;
            label3.Text = "命名空间 namespace";
            // 
            // txbPath
            // 
            txbPath.Location = new Point(693, 909);
            txbPath.Name = "txbPath";
            txbPath.Size = new Size(723, 38);
            txbPath.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Underline, GraphicsUnit.Point, 134);
            label4.Location = new Point(502, 912);
            label4.Name = "label4";
            label4.Size = new Size(174, 31);
            label4.TabIndex = 11;
            label4.Text = "路径(双击打开)";
            label4.DoubleClick += label4_DoubleClick;
            // 
            // btnSaveFile
            // 
            btnSaveFile.Location = new Point(1441, 904);
            btnSaveFile.Name = "btnSaveFile";
            btnSaveFile.Size = new Size(150, 46);
            btnSaveFile.TabIndex = 12;
            btnSaveFile.Text = "保存文件";
            btnSaveFile.UseVisualStyleBackColor = true;
            btnSaveFile.Click += btnSaveFile_Click;
            // 
            // chkViewEntity
            // 
            chkViewEntity.AutoSize = true;
            chkViewEntity.Location = new Point(186, 830);
            chkViewEntity.Name = "chkViewEntity";
            chkViewEntity.Size = new Size(142, 35);
            chkViewEntity.TabIndex = 13;
            chkViewEntity.Text = "视图对象";
            chkViewEntity.UseVisualStyleBackColor = true;
            // 
            // chkRequestEntity
            // 
            chkRequestEntity.AutoSize = true;
            chkRequestEntity.Location = new Point(322, 830);
            chkRequestEntity.Name = "chkRequestEntity";
            chkRequestEntity.Size = new Size(142, 35);
            chkRequestEntity.TabIndex = 14;
            chkRequestEntity.Text = "请求对象";
            chkRequestEntity.UseVisualStyleBackColor = true;
            // 
            // chkDbEntity
            // 
            chkDbEntity.AutoSize = true;
            chkDbEntity.Checked = true;
            chkDbEntity.CheckState = CheckState.Checked;
            chkDbEntity.Location = new Point(50, 830);
            chkDbEntity.Name = "chkDbEntity";
            chkDbEntity.Size = new Size(127, 35);
            chkDbEntity.TabIndex = 15;
            chkDbEntity.Text = "DB对象";
            chkDbEntity.UseVisualStyleBackColor = true;



            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1619, 1003);

            Controls.Add(chkDbEntity);
            Controls.Add(chkRequestEntity);
            Controls.Add(chkViewEntity);
            Controls.Add(btnSaveFile);
            Controls.Add(label4);
            Controls.Add(txbPath);
            Controls.Add(label3);
            Controls.Add(txbNameSpace);
            Controls.Add(BtnCreateFile);
            Controls.Add(statusStrip1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txbCode);
            Controls.Add(BtnSearch);
            Controls.Add(txbTableName);
            Controls.Add(listBox1);
            this.Text = "FrmCode";
            this.Text = "Oracle库代码生成器";
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox ListTable;
        private TextBox txbTableName;
        private Button BtnSearch;
        private TextBox txbCode;
        private Label label1;
        private Label label2;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private Button BtnCreateFile;
        private ListBox listBox1;
        private TextBox txbNameSpace;
        private Label label3;
        private TextBox txbPath;
        private Label label4;
        private Button btnSaveFile;
        private CheckBox chkViewEntity;
        private CheckBox chkRequestEntity;
        private CheckBox chkDbEntity;
    }
}