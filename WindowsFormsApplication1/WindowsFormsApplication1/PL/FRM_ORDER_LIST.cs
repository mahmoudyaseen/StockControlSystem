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
    public partial class FRM_ORDER_LIST : Form
    {
        BL.CLS_ORDERS order = new BL.CLS_ORDERS();
        public FRM_ORDER_LIST()
        {
            InitializeComponent();
            dataGridView1.DataSource = order.get_orders("");//لما تكتب فاضى هيجيب كل البيانات جرب ف السيرفر وشوف
        }

        private void FRM_ORDER_LIST_Load(object sender, EventArgs e)
        {

        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = order.get_orders(txtsearch.Text);
            }
            catch
            {
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //شوف الشرح فطباعة اخر فاتورة ف المبيعات
            Cursor = Cursors.WaitCursor;
            int id = Convert.ToInt32(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
            RPT.RPT_ORDERS report = new RPT.RPT_ORDERS();
            RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
            report.SetDataSource(order.get_order_details(id));
            frm.crystalReportViewer1.ReportSource = report;
            frm.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
