namespace PersonalMemo
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.tsbtnNew = new System.Windows.Forms.ToolStripButton();
            this.tsbtnFind = new System.Windows.Forms.ToolStripButton();
            this.tsbtnSave = new System.Windows.Forms.ToolStripButton();
            this.tsdropBtnTags = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsMenuItemTag = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbtnMy = new System.Windows.Forms.ToolStripButton();
            this.tsbtnAboud = new System.Windows.Forms.ToolStripButton();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.cmStripTag = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsMenuItemTagEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItemTadRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.toolStripMain.SuspendLayout();
            this.cmStripTag.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMain
            // 
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnNew,
            this.tsbtnFind,
            this.tsbtnSave,
            this.tsdropBtnTags,
            this.tsbtnMy,
            this.tsbtnAboud});
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(1054, 31);
            this.toolStripMain.TabIndex = 0;
            this.toolStripMain.Text = "toolStrip1";
            // 
            // tsbtnNew
            // 
            this.tsbtnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnNew.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnNew.Image")));
            this.tsbtnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnNew.Name = "tsbtnNew";
            this.tsbtnNew.Size = new System.Drawing.Size(50, 28);
            this.tsbtnNew.Text = "新建";
            this.tsbtnNew.Click += new System.EventHandler(this.tsbtnNew_Click);
            // 
            // tsbtnFind
            // 
            this.tsbtnFind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnFind.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnFind.Image")));
            this.tsbtnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnFind.Name = "tsbtnFind";
            this.tsbtnFind.Size = new System.Drawing.Size(50, 28);
            this.tsbtnFind.Text = "查找";
            this.tsbtnFind.Click += new System.EventHandler(this.tsbtnFind_Click);
            // 
            // tsbtnSave
            // 
            this.tsbtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSave.Image")));
            this.tsbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSave.Name = "tsbtnSave";
            this.tsbtnSave.Size = new System.Drawing.Size(50, 28);
            this.tsbtnSave.Text = "保存";
            this.tsbtnSave.Click += new System.EventHandler(this.tsbtnSave_Click);
            // 
            // tsdropBtnTags
            // 
            this.tsdropBtnTags.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsdropBtnTags.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuItemTag});
            this.tsdropBtnTags.Image = ((System.Drawing.Image)(resources.GetObject("tsdropBtnTags.Image")));
            this.tsdropBtnTags.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsdropBtnTags.Name = "tsdropBtnTags";
            this.tsdropBtnTags.Size = new System.Drawing.Size(113, 28);
            this.tsdropBtnTags.Text = "已有备忘录";
            // 
            // tsMenuItemTag
            // 
            this.tsMenuItemTag.Name = "tsMenuItemTag";
            this.tsMenuItemTag.Size = new System.Drawing.Size(255, 28);
            this.tsMenuItemTag.Text = "toolStripMenuItem1";
            this.tsMenuItemTag.Click += new System.EventHandler(this.tsMenuItemTag_Click);
            // 
            // tsbtnMy
            // 
            this.tsbtnMy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnMy.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnMy.Image")));
            this.tsbtnMy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnMy.Name = "tsbtnMy";
            this.tsbtnMy.Size = new System.Drawing.Size(50, 28);
            this.tsbtnMy.Text = "我的";
            this.tsbtnMy.Click += new System.EventHandler(this.tsbtnMy_Click);
            // 
            // tsbtnAboud
            // 
            this.tsbtnAboud.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnAboud.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnAboud.Image")));
            this.tsbtnAboud.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnAboud.Name = "tsbtnAboud";
            this.tsbtnAboud.Size = new System.Drawing.Size(50, 28);
            this.tsbtnAboud.Text = "帮助";
            this.tsbtnAboud.Click += new System.EventHandler(this.tsbtnAboud_Click);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMain.Location = new System.Drawing.Point(0, 34);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1054, 441);
            this.tabControlMain.TabIndex = 1;
            this.tabControlMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tabControlMain_MouseClick);
            this.tabControlMain.MouseLeave += new System.EventHandler(this.tabControlMain_MouseLeave);
            // 
            // cmStripTag
            // 
            this.cmStripTag.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuItemTagEdit,
            this.tsMenuItemTadRemove});
            this.cmStripTag.Name = "cmStripTag";
            this.cmStripTag.Size = new System.Drawing.Size(117, 60);
            // 
            // tsMenuItemTagEdit
            // 
            this.tsMenuItemTagEdit.Name = "tsMenuItemTagEdit";
            this.tsMenuItemTagEdit.Size = new System.Drawing.Size(116, 28);
            this.tsMenuItemTagEdit.Text = "修改";
            this.tsMenuItemTagEdit.Click += new System.EventHandler(this.tsMenuItemTagEdit_Click);
            // 
            // tsMenuItemTadRemove
            // 
            this.tsMenuItemTadRemove.Name = "tsMenuItemTadRemove";
            this.tsMenuItemTadRemove.Size = new System.Drawing.Size(116, 28);
            this.tsMenuItemTadRemove.Text = "删除";
            this.tsMenuItemTadRemove.Click += new System.EventHandler(this.tsMenuItemTadRemove_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWelcome.Font = new System.Drawing.Font("宋体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWelcome.Location = new System.Drawing.Point(0, 31);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(1054, 445);
            this.lblWelcome.TabIndex = 2;
            this.lblWelcome.Text = "欢迎使用我的备忘录";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 476);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.toolStripMain);
            this.Controls.Add(this.tabControlMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "备忘录";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMain_KeyDown);
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.cmStripTag.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton tsbtnNew;
        private System.Windows.Forms.ToolStripButton tsbtnFind;
        private System.Windows.Forms.ToolStripButton tsbtnSave;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.ToolStripDropDownButton tsdropBtnTags;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemTag;
        private System.Windows.Forms.ContextMenuStrip cmStripTag;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemTagEdit;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemTadRemove;
        private System.Windows.Forms.ToolStripButton tsbtnMy;
        private System.Windows.Forms.ToolStripButton tsbtnAboud;
        private System.Windows.Forms.Label lblWelcome;

    }
}

