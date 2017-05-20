namespace PersonalMemo
{
    partial class FrmFind
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnNext = new System.Windows.Forms.RadioButton();
            this.rbtnPre = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "查找内容：";
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(109, 25);
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(251, 28);
            this.txtContent.TabIndex = 2;
            this.txtContent.TextChanged += new System.EventHandler(this.txtContent_TextChanged);
            // 
            // btnFind
            // 
            this.btnFind.Enabled = false;
            this.btnFind.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFind.Location = new System.Drawing.Point(378, 22);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(101, 36);
            this.btnFind.TabIndex = 5;
            this.btnFind.Text = "查  找";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtnNext);
            this.groupBox1.Controls.Add(this.rbtnPre);
            this.groupBox1.Location = new System.Drawing.Point(157, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 65);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "方向";
            // 
            // rbtnNext
            // 
            this.rbtnNext.AutoSize = true;
            this.rbtnNext.Checked = true;
            this.rbtnNext.Location = new System.Drawing.Point(113, 28);
            this.rbtnNext.Name = "rbtnNext";
            this.rbtnNext.Size = new System.Drawing.Size(69, 22);
            this.rbtnNext.TabIndex = 6;
            this.rbtnNext.TabStop = true;
            this.rbtnNext.Text = "向下";
            this.rbtnNext.UseVisualStyleBackColor = true;
            // 
            // rbtnPre
            // 
            this.rbtnPre.AutoSize = true;
            this.rbtnPre.Location = new System.Drawing.Point(23, 29);
            this.rbtnPre.Name = "rbtnPre";
            this.rbtnPre.Size = new System.Drawing.Size(69, 22);
            this.rbtnPre.TabIndex = 5;
            this.rbtnPre.Text = "向上";
            this.rbtnPre.UseVisualStyleBackColor = true;
            // 
            // FrmFind
            // 
            this.AcceptButton = this.btnFind;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 143);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFind";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查找";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtnNext;
        private System.Windows.Forms.RadioButton rbtnPre;
    }
}