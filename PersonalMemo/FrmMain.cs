using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PersonalMemo.dal;
using PersonalMemo.model;
using PersonalMemo.context;
using PersonalMemo.common;
/* ==============================================================================
 * 功能描述：Class1  
  * 创 建 者：liqiao
  * 创建日期：2017/5/19 14:40:20
  * email:120911940@qq.com
  * ==============================================================================*/
namespace PersonalMemo
{
    /// <summary>
    /// 
    /// </summary>
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        { 
            FrmLogin frmL = new FrmLogin();
            DialogResult result = frmL.ShowDialog();
            if (result != DialogResult.OK)
            {
                this.Close();
            }
            else
            { 
                InitTabControl();
                InitLoadTagTabControl();
                InitLoadTagMenuStrip();
                InitFormText();
            }
        }
        private void InitFormText() {
            this.lblWelcome.Text = string.Format("{0},欢迎您使用个人备忘录，它可以让你放心记录！", Session.currUser.name);
            this.Text = string.Format("个人备忘录-{0}", Session.currUser.name);
        }
        private void InitLoadTagMenuStrip()
        {
            List<Tag> tags = TagDal.GetMyTags(Session.currUser.id);
            
            tsdropBtnTags.DropDownItems.Clear();
            if (tags != null)
                foreach (Tag tag in tags)
                {
                    NewTagMenu(tag.id, tag.tag);
                }
        }
        private void InitLoadTagTabControl()
        {
            tabControlMain.TabPages.Clear();
        }
        //添加标签菜单
        private void NewTagMenu(string key, string text)
        {
            ToolStripItem menu = new ToolStripMenuItem();
            menu.Tag = key;
            menu.Text = text;
            menu.Click += new EventHandler(tsMenuItemTag_Click);
            tsdropBtnTags.DropDownItems.Add(menu);
        }

        #region tabcontroll操作区
        private const int CLOSE_SIZE = 10;
        //tabPage标签图片
        private Bitmap image = new Bitmap(Environment.CurrentDirectory + "\\ico_close.gif");
        //绘制“Ｘ”号即关闭按钮
        private void MainTabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                Rectangle myTabRect = this.tabControlMain.GetTabRect(e.Index);

                //先添加TabPage属性   
                e.Graphics.DrawString(this.tabControlMain.TabPages[e.Index].Text, this.Font, SystemBrushes.ControlText, myTabRect.X + 2, myTabRect.Y + 2);

                //再画一个矩形框
                using (Pen p = new Pen(Color.White))
                {
                    myTabRect.Offset(myTabRect.Width - (CLOSE_SIZE + 3), 2);
                    myTabRect.Width = CLOSE_SIZE;
                    myTabRect.Height = CLOSE_SIZE;
                    e.Graphics.DrawRectangle(p, myTabRect);
                }

                //填充矩形框
                Color recColor = e.State == DrawItemState.Selected ? Color.White : Color.White;
                using (Brush b = new SolidBrush(recColor))
                {
                    e.Graphics.FillRectangle(b, myTabRect);
                }

                //画关闭符号
                using (Pen objpen = new Pen(Color.Black))
                {
                    ////=============================================
                    //自己画X
                    ////"\"线
                    //Point p1 = new Point(myTabRect.X + 3, myTabRect.Y + 3);
                    //Point p2 = new Point(myTabRect.X + myTabRect.Width - 3, myTabRect.Y + myTabRect.Height - 3);
                    //e.Graphics.DrawLine(objpen, p1, p2);
                    ////"/"线
                    //Point p3 = new Point(myTabRect.X + 3, myTabRect.Y + myTabRect.Height - 3);
                    //Point p4 = new Point(myTabRect.X + myTabRect.Width - 3, myTabRect.Y + 3);
                    //e.Graphics.DrawLine(objpen, p3, p4);

                    ////=============================================
                    //使用图片
                    Bitmap bt = new Bitmap(image);
                    Point p5 = new Point(myTabRect.X, 4 + 2);
                    e.Graphics.DrawImage(bt, p5);
                    //e.Graphics.DrawString(this.MainTabControl.TabPages[e.Index].Text, this.Font, objpen.Brush, p5);
                }
                e.Graphics.Dispose();
            }
            catch (Exception)
            { }
        }
        //关闭按钮功能
        private void MainTabControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int x = e.X, y = e.Y;
                //计算关闭区域   
                Rectangle myTabRect = this.tabControlMain.GetTabRect(this.tabControlMain.SelectedIndex);

                myTabRect.Offset(myTabRect.Width - (CLOSE_SIZE + 3), 2);
                myTabRect.Width = CLOSE_SIZE;
                myTabRect.Height = CLOSE_SIZE;

                //如果鼠标在区域内就关闭选项卡   
                bool isClose = x > myTabRect.X && x < myTabRect.Right && y > myTabRect.Y && y < myTabRect.Bottom;
                if (isClose == true)
                {
                    this.tabControlMain.TabPages.Remove(this.tabControlMain.SelectedTab);
                }
            }
        }
        //初始化tabcontrol
        private void InitTabControl()
        {
            //清空控件
            //this.MainTabControl.TabPages.Clear();
            //绘制的方式OwnerDrawFixed表示由窗体绘制大小也一样
            this.tabControlMain.DrawMode = TabDrawMode.OwnerDrawFixed;
            this.tabControlMain.Padding = new System.Drawing.Point(15, 5);
            this.tabControlMain.DrawItem += new DrawItemEventHandler(this.MainTabControl_DrawItem);
            this.tabControlMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainTabControl_MouseDown);
        }
        //添加标签选项卡
        private void NewTagPage(string key, string text, Memo memo = null)
        {
            lblWelcome.Hide(); 
            for (int i = 0; i < tabControlMain.TabPages.Count; i++)
            {
                if (tabControlMain.TabPages[i].Tag.Equals(key))
                {
                    tabControlMain.SelectTab(i);
                    return;
                }
            }
            if (memo == null)
            {
                memo = MemoDal.Get(key);
            }
            TabPage page = new TabPage();
            page.Text = text;
            page.Tag = key; 
            RichTextBox txtBox = new RichTextBox();
            txtBox.Parent = page;
            txtBox.Width = page.Width;
            txtBox.Height = page.Height;
            txtBox.Text = memo.content;
            txtBox.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left;
            txtBox.KeyDown += new KeyEventHandler(RickTextBox_KeyDown);
            tabControlMain.TabPages.Add(page);
            tabControlMain.SelectTab(page);
        }
        #endregion

        private void tsMenuItemTag_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            NewTagPage(item.Tag.ToString(), item.Text);
        }

        private void tsbtnNew_Click(object sender, EventArgs e)
        {
            FrmTag frmTag = new FrmTag();
            if (DialogResult.OK == frmTag.ShowDialog())
            {
                NewTagPage(frmTag.currTag.id, frmTag.currTag.tag);
                InitLoadTagMenuStrip();
            }
        }
        //保存备忘录
        private void tsbtnSave_Click(object sender, EventArgs e)
        {
            SaveMemo();
        }
        private void SaveMemo()
        {
            TabPage page = tabControlMain.SelectedTab;
            if (page != null)
            {
                RichTextBox rtxtbox = page.Controls[0] as RichTextBox;
                Memo memo = new Memo();
                memo.tagid = page.Tag.ToString();
                memo.lasttime = DateTime.Now;
                memo.content = rtxtbox.Text.Trim();
                MemoDal.Modify(memo);
            }
            else
                MessageBox.Show("请先新建或者选择一个备忘录", "提示");
        }
        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {//ctrl+s 
                SaveMemo();
            }
            else if (e.Control && e.KeyCode == Keys.F)
            {
                FindMemo();
            }
            else if (e.Control && e.KeyCode == Keys.A)
            {
            }
        }
        private void RickTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F)
            {
                FindMemo();
            }
            else if (e.Control && e.KeyCode == Keys.A)
            {
            }
        }
        //备忘录内容查找
        private void FindMemo()
        {
            TabPage page = tabControlMain.SelectedTab;
            if (page != null)
            {
                RichTextBox rtxtbox = page.Controls[0] as RichTextBox;
                FrmFind frmFind = new FrmFind();
                frmFind.rtxtBox = rtxtbox;
                frmFind.Show(this);
            }
            else
                MessageBox.Show("请先新建或者选择一个备忘录", "提示");

        }
        //查找
        private void tsbtnFind_Click(object sender, EventArgs e)
        {
            FindMemo();
        }
        //删除tag及其memo
        private void tsMenuItemTadRemove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确定要删除吗？", "警告", MessageBoxButtons.OKCancel) == DialogResult.OK) {
                TabPage page = tabControlMain.SelectedTab;
                if (TagDal.RemoveTagAndMemo(page.Tag.ToString()))
                {
                    foreach (ToolStripItem item in tsdropBtnTags.DropDownItems)
                    {
                        if (item.Tag.Equals(page.Tag)) {
                            tsdropBtnTags.DropDownItems.Remove(item);
                             
                            break;
                        }
                    }
                    tabControlMain.TabPages.Remove(page);

                }
                else {
                    MessageBox.Show("删除失败");
                }
            }
        }
        /// <summary>
        /// 修改tag
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsMenuItemTagEdit_Click(object sender, EventArgs e)
        {
            FrmTag frmTag = new FrmTag();
            TabPage page = tabControlMain.SelectedTab;
            frmTag.initEditData(page.Tag.ToString(), page.Text);
            if (frmTag.DialogResult == DialogResult.OK)
            {
                page.Text = frmTag.currTag.tag;
                InitLoadTagMenuStrip();
            }
        }
         
        /// <summary>
        /// 右键菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControlMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                for (int i = 0; i < tabControlMain.TabPages.Count; i++)
                {
                    TabPage tp = tabControlMain.TabPages[i];
                    if (tabControlMain.GetTabRect(i).Contains(new Point(e.X, e.Y)))
                    {
                        tabControlMain.SelectedTab = tp; 
                        break;
                    }
                }
                cmStripTag.Show(tabControlMain,new Point(e.X, e.Y)); 
            }
        }

        private void tabControlMain_MouseLeave(object sender, EventArgs e)
        {
           // cmStripTag.Hide(); 
        }
        //我的
        private void tsbtnMy_Click(object sender, EventArgs e)
        {
            FrmMy frmMy = new FrmMy();
            frmMy.ShowDialog(this);
            InitFormText();
        }
        //帮助
        private void tsbtnAboud_Click(object sender, EventArgs e)
        {
            FrmAbout frmAbout = new FrmAbout();
            frmAbout.ShowDialog(this);
        }
    }
}
