namespace CodeAndTool
{
    partial class FrmDocment
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
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            labDbType = new Label();
            btnMarkdown = new Button();
            btnWord = new Button();
            btnHtml = new Button();
            btnPdf = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 75);
            label1.Name = "label1";
            label1.Size = new Size(80, 17);
            label1.TabIndex = 0;
            label1.Text = "链接字符串：";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(108, 72);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(649, 131);
            textBox1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 24);
            label2.Name = "label2";
            label2.Size = new Size(80, 17);
            label2.TabIndex = 2;
            label2.Text = "数据库类型：";
            // 
            // labDbType
            // 
            labDbType.AutoSize = true;
            labDbType.Location = new Point(108, 24);
            labDbType.Name = "labDbType";
            labDbType.Size = new Size(46, 17);
            labDbType.TabIndex = 3;
            labDbType.Text = "Oracle";
            // 
            // btnMarkdown
            // 
            btnMarkdown.Location = new Point(615, 239);
            btnMarkdown.Name = "btnMarkdown";
            btnMarkdown.Size = new Size(142, 56);
            btnMarkdown.TabIndex = 4;
            btnMarkdown.Text = "Markdown格式";
            btnMarkdown.UseVisualStyleBackColor = true;
            // 
            // btnWord
            // 
            btnWord.Location = new Point(108, 239);
            btnWord.Name = "btnWord";
            btnWord.Size = new Size(142, 56);
            btnWord.TabIndex = 5;
            btnWord.Text = "Word格式";
            btnWord.UseVisualStyleBackColor = true;
            // 
            // btnHtml
            // 
            btnHtml.Location = new Point(275, 239);
            btnHtml.Name = "btnHtml";
            btnHtml.Size = new Size(142, 56);
            btnHtml.TabIndex = 6;
            btnHtml.Text = "Html格式";
            btnHtml.UseVisualStyleBackColor = true;
            // 
            // btnPdf
            // 
            btnPdf.Location = new Point(445, 239);
            btnPdf.Name = "btnPdf";
            btnPdf.Size = new Size(142, 56);
            btnPdf.TabIndex = 7;
            btnPdf.Text = "PDF格式";
            btnPdf.UseVisualStyleBackColor = true;
            // 
            // FrmDocment
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnPdf);
            Controls.Add(btnHtml);
            Controls.Add(btnWord);
            Controls.Add(btnMarkdown);
            Controls.Add(labDbType);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "FrmDocment";
            Text = "数据库说明文档";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private Label labDbType;
        private Button btnMarkdown;
        private Button btnWord;
        private Button btnHtml;
        private Button btnPdf;
    }
}