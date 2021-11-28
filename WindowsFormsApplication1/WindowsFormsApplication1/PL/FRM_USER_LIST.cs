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
    public partial class FRM_USER_LIST : Form
    {
        BL.CLS_LOGIN user = new BL.CLS_LOGIN();
        public FRM_USER_LIST()
        {
            InitializeComponent();
            dataGridView1.DataSource= user.get_users("");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = user.get_users(txtsearch.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FRM_ADD_USER frm = new FRM_ADD_USER();
            frm.butusernew.Text = "اضافة مستخدم";
            frm.ShowDialog();
            dataGridView1.DataSource = user.get_users("");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FRM_ADD_USER frm = new FRM_ADD_USER();
            frm.butusernew.Text = "تعديل مستخدم";
            frm.txtid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            frm.txtid.Enabled = false;
            frm.txtfullname.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            frm.txtpasw.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            frm.txtconpasw.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            frm.comboBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            frm.ShowDialog();
            dataGridView1.DataSource = user.get_users("");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل انت متاكد من حذف المستخدم الحالى", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                user.delete_users(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                dataGridView1.DataSource = user.get_users("");
                MessageBox.Show("تم حذف المستخدم الحالى", "حذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                return;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
