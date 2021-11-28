using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace WindowsFormsApplication1.PL
{
    public partial class FRM_BACKUP : Form
    {
        SqlConnection cn = new SqlConnection(@"Server=.\SQLEXPRESS;DataBase=Product_DB;Integrated Security=true");
        SqlCommand cmd = new SqlCommand();
        public FRM_BACKUP()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog()==DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //هعمل متغير فية المسار وهدمجة مع الاسم المراد الحفظ النسخة الاحتياطية به مع التاريخ مع الوقت بس هيحصل خطا علشان اسم الملف ما ينفعش يكون فية رموز \ او : فهغيرهم
            string file = textBox1.Text + "\\Product_DB" + DateTime.Now.ToLongDateString().Replace('/','-') + "_" + DateTime.Now.ToLongTimeString().Replace(":","-");
            string order = "Backup database Product_DB to disk='" + file + ".bak'";//بدمج الامر بالمسار بالنوع 
            cmd = new SqlCommand(order, cn);//كان ممكن ما اكتبش المتغيرين اللى فوق دول واكتب كله هنا
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("تم عمل نسخة احتياطية", "انشاء نسخة احتياطية", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
