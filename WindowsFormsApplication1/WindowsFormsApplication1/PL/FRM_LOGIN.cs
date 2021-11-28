using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.PL
{
    public partial class FRM_LOGIN : Form
    {
        BL.CLS_LOGIN login = new BL.CLS_LOGIN();
        public FRM_LOGIN()
        {
            InitializeComponent();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            DataTable dt = login.LOGIN(txtid.Text, txtpwd.Text);
            if(dt.Rows.Count>0)
            {
                Program.salesnam = dt.Rows[0]["fullname"].ToString();//اسم المستخدم
                //FRM_MAIN frm = new FRM_MAIN();
                //علشان اقدر اتعامل مع عناصر فورم من فورم اخرى لازم اخلى حالة العناصر اللى عاوز اتحكم فيها بابلك بدول بريفيت
                //frm.العملاءToolStripMenuItem.Enabled = true;//مش هيتغير حاجة لانى طبقت على نسخة تانية من الفورم الرئيسية لازم اطبق على النسخة الرئيسية
                //الطريقة الصح تبح محاضرة 11 بردو
                //انا لما بعدل على الكائن دة عن طريق الجت الكائن دة جواه الكلاس نفسة 
                //فلما بعدل علية بعدل على الكائن
                if (dt.Rows[0][2].ToString() == "مدير")
                {
                    FRM_MAIN.getmainform.المنتجاتToolStripMenuItem.Enabled = true;
                    FRM_MAIN.getmainform.العملاءToolStripMenuItem.Enabled = true;
                    FRM_MAIN.getmainform.المستخدمونToolStripMenuItem.Enabled = true;//هتتفعل لكن لو مش باينة مش هيعرف يستخدمها فلازم اظهر الاول علشان لو حد مش مدير سجل
                    FRM_MAIN.getmainform.انشاءنسخةاحتياطيةToolStripMenuItem.Enabled = true;
                    FRM_MAIN.getmainform.استرجاعنسخةاحتياطيةToolStripMenuItem.Enabled = true;
                    FRM_MAIN.getmainform.المستخدمونToolStripMenuItem.Visible = true;//لو حد مش مدير سجل الدخول مش هيبان قايمه المستخدمين فلازم اظهر قايمة المستخدمين لما المدير يسجل
                    //هقفل نافذة تسجيل الدخول بعد اما يكتب الاسم والباس صح مش لاوم اليوزر يقفلها يعنى
                    this.Close();
                }
                else if(dt.Rows[0][2].ToString() == "مستخدم عادى")
                {
                    FRM_MAIN.getmainform.المنتجاتToolStripMenuItem.Enabled = true;
                    FRM_MAIN.getmainform.العملاءToolStripMenuItem.Enabled = true;
                    FRM_MAIN.getmainform.المستخدمونToolStripMenuItem.Visible = false;//مش لازم الغى التفعيل كدة كدة مخفية مش هيعرف يستخدمها
                    FRM_MAIN.getmainform.انشاءنسخةاحتياطيةToolStripMenuItem.Enabled = true;
                    FRM_MAIN.getmainform.استرجاعنسخةاحتياطيةToolStripMenuItem.Enabled = true;
                    //هقفل نافذة تسجيل الدخول بعد اما يكتب الاسم والباس صح مش لاوم اليوزر يقفلها يعنى
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("login failer");
            }
        }
    }
}
