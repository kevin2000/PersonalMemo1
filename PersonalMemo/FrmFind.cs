using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PersonalMemo.common;
/* ==============================================================================
 * 功能描述：Class1  
  * 创 建 者：liqiao
  * 创建日期：2017/5/19 14:40:20
  * email:120911940@qq.com
  * ==============================================================================*/
namespace PersonalMemo
{
    public partial class FrmFind : Form
    {
        public FrmFind()
        {
            InitializeComponent();
        }
        public RichTextBox rtxtBox;
        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtContent.Text.Trim()))
            { 
                 RichTextBoxTool.FindText(rtxtBox, txtContent.Text.Trim(), rbtnNext.Checked?RichTextBoxFinds.None:RichTextBoxFinds.Reverse);
             }
            else {
                MessageBox.Show("请向输入查询内容");
            }
        }

        private void txtContent_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtContent.Text.Trim()))
                btnFind.Enabled = true;
            else
                btnFind.Enabled = false;
        }
    }
}
