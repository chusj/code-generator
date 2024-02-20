namespace CodeAndTool
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnCode = new Button();
            btnComment = new Button();
            btnNewField = new Button();
            Tips = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            label1 = new Label();
            txbDbConn = new TextBox();
            linkLabel1 = new LinkLabel();
            Tips.SuspendLayout();
            SuspendLayout();
            // 
            // btnCode
            // 
            btnCode.Location = new Point(46, 164);
            btnCode.Name = "btnCode";
            btnCode.Size = new Size(156, 57);
            btnCode.TabIndex = 0;
            btnCode.Text = "生成代码";
            btnCode.UseVisualStyleBackColor = true;
            btnCode.Click += btnCode_Click;
            // 
            // btnComment
            // 
            btnComment.Location = new Point(304, 164);
            btnComment.Name = "btnComment";
            btnComment.Size = new Size(156, 57);
            btnComment.TabIndex = 1;
            btnComment.Text = "表和字段注释";
            btnComment.UseVisualStyleBackColor = true;
            btnComment.Click += btnComment_Click;
            // 
            // btnNewField
            // 
            btnNewField.Location = new Point(538, 164);
            btnNewField.Name = "btnNewField";
            btnNewField.Size = new Size(156, 57);
            btnNewField.TabIndex = 2;
            btnNewField.Text = "数据库结构文档";
            btnNewField.UseVisualStyleBackColor = true;
            btnNewField.Click += btnNewField_Click;
            // 
            // Tips
            // 
            Tips.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            Tips.Location = new Point(0, 428);
            Tips.Name = "Tips";
            Tips.Size = new Size(800, 22);
            Tips.TabIndex = 3;
            Tips.Text = "操作提示：";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(131, 17);
            toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(46, 41);
            label1.Name = "label1";
            label1.Size = new Size(104, 17);
            label1.TabIndex = 4;
            label1.Text = "数据库配置文件：";
            // 
            // txbDbConn
            // 
            txbDbConn.Location = new Point(191, 38);
            txbDbConn.Name = "txbDbConn";
            txbDbConn.Size = new Size(385, 23);
            txbDbConn.TabIndex = 5;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(638, 41);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(56, 17);
            linkLabel1.TabIndex = 6;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "打开路径";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(linkLabel1);
            Controls.Add(txbDbConn);
            Controls.Add(label1);
            Controls.Add(Tips);
            Controls.Add(btnNewField);
            Controls.Add(btnComment);
            Controls.Add(btnCode);
            Name = "Form1";
            Text = "代码和工具";
            Tips.ResumeLayout(false);
            Tips.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCode;
        private Button btnComment;
        private Button btnNewField;
        private StatusStrip Tips;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private Label label1;
        private TextBox txbDbConn;
        private LinkLabel linkLabel1;
    }
}
