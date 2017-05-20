using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PersonalMemo.model;
using PersonalMemo.dal;
using PersonalMemo.context;
/* ==============================================================================
 * 功能描述：Class1  
  * 创 建 者：liqiao
  * 创建日期：2017/5/19 14:40:20
  * email:120911940@qq.com
  * ==============================================================================*/
namespace PersonalMemo
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtUserName.Text)&& !string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                SysUser user = UserDal.get(txtUserName.Text.Trim(), txtPassword.Text.Trim());
                if (user != null)
                {
                    Session.currUser = user;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                    showHint("用户名或者密码错误");
            }else
                showHint("请输入用户名和密码");  
        }
        private void showHint(string text) {
            lblHint.Text = text;
            lblHint.Show();
        }
    }
}
