using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PersonalMemo.dal;
using PersonalMemo.context;
using PersonalMemo.model;
using PersonalMemo.common;

namespace PersonalMemo
{
    /// <summary>
    /// 新建，编辑
    /// </summary>
    enum FormOperations { 
        add,edit
    }
    public partial class FrmTag : Form
    {
        public FrmTag()
        {
            InitializeComponent();
        }
        public Tag currTag=null;//保存新建成功或者要修改的的tag
        public Memo memo = null;//保存新建成功的memo
        private FormOperations operation=FormOperations.add;//操作模式，默认为新建
        public string tagId;//用于修改tag 
        public void initEditData(string tagid,string tagtext) {
            this.tagId = tagid; 
            operation = FormOperations.edit;
            txtTagName.Text = tagtext;
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtTagName.Text))
            {
                if (operation == FormOperations.add)
                {
                    if (!TagDal.IsExistTag(Session.currUser.id, txtTagName.Text.Trim()))
                    {
                        currTag = new Tag();
                        currTag.id = StringUtil.getGuidN();
                        currTag.tag = txtTagName.Text.Trim();
                        currTag.userid = Session.currUser.id;
                        currTag.addtime = DateTime.Now;

                        memo = new Memo();
                        memo.tagid = currTag.id;
                        memo.content = "";
                        memo.lasttime = DateTime.Now;
                        if (TagDal.AddTagAndMemo(currTag, memo))
                        {
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            ShowHint("保存失败");
                        }
                    }
                    else
                    {
                        ShowHint("已存在相同名称的备忘录，请输入另外的名称");
                        txtTagName.Focus();
                    }
                }
                else {
                    currTag = TagDal.Get(tagId);
                    if (currTag != null)
                    {
                        currTag.tag = txtTagName.Text.Trim();
                        if (TagDal.Modify(currTag))
                        {
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                            ShowHint("保存失败");
                    }
                    else
                    {
                        MessageBox.Show("数据异常，保存失败");
                        this.Close();
                    }
                }
            }
            else {
                ShowHint("请输入名称");
                txtTagName.Focus();
            }
        }
        private void ShowHint(string text)
        {
            lblHint.Text = text;
            lblHint.Show();
        }
    }
}
