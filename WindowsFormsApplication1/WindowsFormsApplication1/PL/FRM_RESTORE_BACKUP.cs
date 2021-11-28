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
    public partial class FRM_RESTORE_BACKUP : Form
    {
        //بختار الداتا بيز الاساسية علشان ممكن تكون الداتا بيز اللى انا عاوز استرجعها محزوفة فيحصل غلط
        SqlConnection cn = new SqlConnection(@"server=.\sqlexpress;database=master;integrated security=true");
        SqlCommand cmd;
        public FRM_RESTORE_BACKUP()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //بيحصل غلط لما استعيد النسخة الاحتياطية لما تكون الداتا بيز مفتوحة فلازم اقفلها 
            //معلومة : ممكن اكتب اكتر من امر ف الكوماند وبفصل بنهم ب;والامر اللى بيقفل الاتصال هو
            string order = "alter database Product_DB set offline with rollback immediate;restore database product_DB from disk='" + textBox1.Text + "'";
            cmd = new SqlCommand(order,cn);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("تم استعادة البيانات", "استعادة البيانات", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
