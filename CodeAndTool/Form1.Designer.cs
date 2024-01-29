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
            SuspendLayout();
            // 
            // btnCode
            // 
            btnCode.Location = new Point(81, 164);
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
            btnNewField.Text = "新增字段";
            btnNewField.UseVisualStyleBackColor = true;
            btnNewField.Click += btnNewField_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnNewField);
            Controls.Add(btnComment);
            Controls.Add(btnCode);
            Name = "Form1";
            Text = "代码和工具";
            ResumeLayout(false);
        }

        #endregion

        private Button btnCode;
        private Button btnComment;
        private Button btnNewField;
    }
}
