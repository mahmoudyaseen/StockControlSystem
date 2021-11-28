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
    public partial class FRM_CUSTOMERS_LIST : Form
    {
        BL.CLS_CUSTOERS cust = new BL.CLS_CUSTOERS();
        public FRM_CUSTOMERS_LIST()
        {
            InitializeComponent();
            dataGridView1.DataSource = cust.get_all_custoners();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[5].Visible = false;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            Close();
            //لو هنا كنت حطيت قيم التيكست بوكس كان لازم اتعامل مع الفورم بتاع الطلبات 
            //كانه فورم واحد ف البروجكت كله 
            //علشان انا بعدل على فورم من فورم تانية 
        }
    }
}
