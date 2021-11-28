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
    public partial class FRM_CONFIG : Form
    {
        public FRM_CONFIG()
        {
            InitializeComponent();
            //خلى بالك المستخدم لازم يكون لية الحق ف مشاركة المحتوى علشان تشوف البيانات هنا
            txtserver.Text = Properties.Settings.Default.server;
            txtdatabase.Text = Properties.Settings.Default.database;
            if (Properties.Settings.Default.mode == "SQL")
            {
                rbsql.Checked = true;
                txtusername.Text = Properties.Settings.Default.id;
                txtpass.Text = Properties.Settings.Default.password;
            }
            else
            {
                rbwindows.Checked =true ;
                //txtusername.Clear();
                //txtpass.Clear();
                txtusername.ReadOnly = true;
                txtpass.ReadOnly = true;
            }
        }

        private void butnsave_Click(object sender, EventArgs e)
        {
            //دى متغيرات اساسية بتتعمل للبرنامج كله بتبقى متعرفة على البرنامج كلة 
            //بديها قيم مبداية وبحط فيها معلومات الاتصال بالسيرفر لو حد عاوز يغيرها يغيرها من هنا
            //بجيبها من السوليوشن اكسبلولر وبعدين بروبيرتز وبعدين سيتنج وبعمل متغير جديد
            Properties.Settings.Default.server = txtserver.Text;
            Properties.Settings.Default.database = txtdatabase.Text;
            Properties.Settings.Default.mode = rbsql.Checked == true ? "SQL" : "Windows";
            Properties.Settings.Default.id = txtusername.Text;
            Properties.Settings.Default.password = txtpass.Text;
            Properties.Settings.Default.Save();//بتحفظ قيم المتغيرات
            MessageBox.Show("تم الحفظ", "الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void rbsql_CheckedChanged(object sender, EventArgs e)
        {
            txtusername.ReadOnly = false;
            txtpass.ReadOnly = false;
        }

        private void rbwindows_CheckedChanged(object sender, EventArgs e)
        {
            txtusername.ReadOnly = true;
            txtpass.ReadOnly = true;
        }

        private void butnclose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
