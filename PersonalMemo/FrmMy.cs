using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PersonalMemo.context;
using PersonalMemo.dal;
using PersonalMemo.model;
using PersonalMemo.common;

namespace PersonalMemo
{
    public partial class FrmMy : Form
    {
        public FrmMy()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtOldPwd.Text) && !string.IsNullOrWhiteSpace(txtNewPwd.Text) 
                && txtNewPwd.Text.Trim().Equals(txtNewPwdConfirm.Text.Trim()))
            {
                string oldPwd = txtOldPwd.Text.Trim();
                if(Session.EncryptMode)
                    oldPwd=EncryptUtil.EncryptMd5Salt(txtOldPwd.Text.Trim(), txtOldPwd.Text.Trim());
                if (Session.currUser.password.Equals(oldPwd))
                {
                    Session.currUser.password = EncryptUtil.EncryptMd5Salt(txtNewPwd.Text.Trim(), txtNewPwd.Text.Trim());
                    if (UserDal.Modify(Session.currUser))
                    {
                        if (MessageBox.Show("保存成功，是否退出?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            this.Close();
                    }
                    else {
                        Session.currUser.password = oldPwd ;      
                        ShowHint("保存失败");
                    }
                }
                else { 
                    ShowHint("原密码错误");
                    txtOldPwd.Focus();
                }
            }
            else if (string.IsNullOrWhiteSpace(txtOldPwd.Text))
            { ShowHint("请输入原密码");
            txtOldPwd.Focus();
            }
            else if (string.IsNullOrWhiteSpace(txtNewPwd.Text))
            { ShowHint("请输入新密码");
            txtNewPwd.Focus();
            }
            else if (!txtNewPwd.Text.Trim().Equals(txtNewPwdConfirm.Text.Trim()))
            { ShowHint("两次输入的密码不一致，请重新输入");
            txtNewPwd.Focus();
            }
        }
        private void ShowHint(string text)
        {
            lblHint.Text = text;
            lblHint.Show();
        }

        private void btnOkBase_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(txtName.Text))
            {
                string oldName = Session.currUser.name;
                Session.currUser.name = txtName.Text.Trim();
                if(UserDal.Modify(Session.currUser))
                {
                    if (MessageBox.Show("保存成功，是否退出?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        this.Close();
                }
            }else
            {MessageBox.Show("昵称不能为空");
                txtName.Focus();
            }
        }

        private void FrmMy_Load(object sender, EventArgs e)
        {
            this.txtName.Text = Session.currUser.name;
        } 
    }
}
