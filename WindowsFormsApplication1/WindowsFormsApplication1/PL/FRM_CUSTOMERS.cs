using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace WindowsFormsApplication1.PL
{
    public partial class FRM_CUSTOMERS : Form
    {
        BL.CLS_CUSTOERS cust = new BL.CLS_CUSTOERS();
        int ID=0;//هحط فية الاى دى للعنصر اللى هيدوس علية دابل كليك علشان 
        //لو بعت للفانكشن الاى ددى للعنصر الحالى و
        //لو داس كلك واحد على عنصر تانى هيعدل على العنصر الجديد مش اللى داس علية دابل كليك
        int position;//الخاص بازرار التنقل
        public FRM_CUSTOMERS()
        {
            InitializeComponent();
            dataGridView1.DataSource = cust.get_all_custoners();
            //هخفى الصور والاى دى من الداتا جريد فيو
            dataGridView1.Columns[0].Visible=false;
            dataGridView1.Columns[5].Visible = false;
        }

        private void FRM_CUSTOMERS_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //افرض اليوزر مادخلش صورة فيحصل خطا فهعدل شوية ف الاجراء المخزن والفاكشن ف الكلاس وهنا
            byte[] img;
            if (pictureBox1.Image == null)
            {
                img = new byte[0];//لازم اديلة اى قيمة علشان ما يحصلش خطا ومش هتفرق لان هيروح مش هيلاقى مكان يتحط فية القيمة دى ف الاجراء المخزن
                cust.add_customer(txtfirstname.Text, txtlastname.Text, txttel.Text, txtemail.Text, img, "without image");
                MessageBox.Show("تم الاضافة بنجاح", "الاضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = cust.get_all_custoners();
            }
            else
            {
                try
                {
                    MemoryStream ms = new MemoryStream();
                    pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                    img = ms.ToArray();//كان ممكن اكتب التعريف دة فوق وكدة كدة ف حالة مفيش صورة مش هيلاقى متغير ف الاجراء المجزن يتحط فية القيمة دى فهتكون فاضية
                    cust.add_customer(txtfirstname.Text, txtlastname.Text, txttel.Text, txtemail.Text, img, "with image");
                    MessageBox.Show("تم الاضافة بنجاح", "الاضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = cust.get_all_custoners();
                }
                catch
                {
                    MessageBox.Show("حدث خطا اثناء الاضافة", "الاضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            butnadd.Enabled = false;
            button5.Enabled = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //لما يدوس على البيكتشر بوكس
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "enter image |*.PNG;*.JPG;*.GIF;*.BMP";
            if(open.ShowDialog()==DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(open.FileName);
            }
        }

        private void txtfirstname_KeyDown(object sender, KeyEventArgs e)
        {
            //حدث بيحصل لما ادوس على زرار
            if(e.KeyCode==Keys.Enter)
            {
                txtlastname.Focus();
            }
        }

        private void txtlastname_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                txttel.Focus();
            }
        }

        private void txttel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtemail.Focus();
            }
        }

        private void txtemail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                butnadd.Focus();
            }
        }
        void cleartextbox()
        {
            txtemail.Clear();
            txtfirstname.Clear();
            txtlastname.Clear();
            txttel.Clear();
            pictureBox1.Image = null;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            cleartextbox();
            butnadd.Enabled = true;
            button5.Enabled = false;//هلغى زرار جديد 
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            //افرض اليوزر عاوز يعرض بيانات عميل لية صورة هيحصل خطا فلازم اعمل تراى كاتش
            try
            {
                pictureBox1.Image = null;
                //حطيتها علشان لو مافيش صورة ف العنصر اللى انا هختارة وانا كنت مختار عنصر فية صورة قبل دة فهتفضل الصورة مكانها فلازم افضيها 
                //علشان مفيش صورة تيجى تاخد مكانها وكان ممكن اكتب السطر دة ف الكاتش بس افرض حصل خطا غير الصورة هيشيل الصورة وممكن يكون للعنصر صورة 
                //خطا غيرالصورة مثلا يكون مدخل قيمة غير مسموح بيها
                txtfirstname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();//ممكن اكتب اسم العمود بدل رقمة
                txtlastname.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txttel.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txtemail.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                byte[] image = (byte[])dataGridView1.CurrentRow.Cells[5].Value;
                MemoryStream ms = new MemoryStream(image);
                pictureBox1.Image = Image.FromStream(ms);
            }
            catch
            {
                return;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //طيب افرض هو عدل قبل ما يختار عميل فيحصل ايرور لان مافيش عميل اصلا وهيفضل الاى دى ب 0
            if (ID == 0)
            {
                MessageBox.Show("يجب استخدام الجدول او ازرار التنقل لاختيار عميل اولا ", "تعديل", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //افرض اليوزر مادخلش صورة فيحصل خطا فهعدل شوية ف الاجراء المخزن والفاكشن ف الكلاس وهنا
            byte[] img;
            if (pictureBox1.Image == null)
            {
                img = new byte[0];//لازم اديلة اى قيمة علشان ما يحصلش خطا ومش هتفرق لان هيروح مش هيلاقى مكان يتحط فية القيمة دى ف الاجراء المخزن
                cust.edit_customer(txtfirstname.Text, txtlastname.Text, txttel.Text, txtemail.Text, img, "without image", ID);
                MessageBox.Show("تم التعديل بنجاح", "التعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = cust.get_all_custoners();
            }
            else
            {
                try
                {
                    MemoryStream ms = new MemoryStream();
                    pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                    img = ms.ToArray();//كان ممكن اكتب التعريف دة فوق وكدة كدة ف حالة مفيش صورة مش هيلاقى متغير ف الاجراء المجزن يتحط فية القيمة دى فهتكون فاضية
                    cust.edit_customer(txtfirstname.Text, txtlastname.Text, txttel.Text, txtemail.Text, img, "with image", ID);
                    MessageBox.Show("تم التعديل بنجاح", "التعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = cust.get_all_custoners();
                }
                catch
                {
                    MessageBox.Show("حدث خطا اثناء التعديل", "التعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //طيب افرض هو حذف قبل ما يختار عميل فيحصل ايرور لان مافيش عميل اصلا وهيفضل الاى دى ب 0
            if(ID==0)
            {
                MessageBox.Show("يجب استخدام الجدول او ازرار التنقل لاختيار عميل اولا ", "حذف", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("هل انت متاكد من حذف هذا العميل ", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cust.delete_customer(ID);
                MessageBox.Show("تم الحذف ", "حذف", MessageBoxButtons.OK, MessageBoxIcon.Question);
                dataGridView1.DataSource = cust.get_all_custoners();
                cleartextbox();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource= cust.search_customer(txtsearch.Text);
        }

        private void txtsearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //لما يدوس اليوزر على انتر يبحث
                //ممكن اكتبلة الكود اللى ف الزرار بتاع البحث او استدعى الفانكشن اللى بتحصل لما ادوس علية
                button10_Click(sender, e);
            }
        }
        void move(int index)
        {
            try//علشان لو مافيش صورة ما يحصلش خطا
            {
                pictureBox1.Image = null;//علشان لو مافيش صورة ف عميل وانا كنت مختار قبلة عميل فية صورة 
                //للتسهيل ممكن اكتب كدة
                DataRowCollection row = cust.get_all_custoners().Rows;//واشيل الداتا تيبول والتيكست بوكس هتصغر
                DataTable dt = new DataTable();
                dt = cust.get_all_custoners();
                //طيب لو انا بتنقل بالزراير واليوزر عدل على موظق او حذفة مش هيحصل 
                //لان التعديل بيعتمد على ال ID فلازم ادى قيمة لل ID
                ID =Convert.ToInt32(dt.Rows[index][0]);
                txtfirstname.Text = dt.Rows[index][1].ToString();
                //txtfirstname.Text = row[index][1].ToString();
                txtlastname.Text = dt.Rows[index][2].ToString();
                txttel.Text = dt.Rows[index][3].ToString();
                txtemail.Text = dt.Rows[index][4].ToString();
                byte[] img = (byte[])dt.Rows[index][5];
                MemoryStream ms = new MemoryStream(img);
                pictureBox1.Image = Image.FromStream(ms);
            }
            catch
            {
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            position = 0;
            move(position);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            position = dataGridView1.Rows.Count-1;
            move(position);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(position==0)
            {
                MessageBox.Show("هذا هو اول عنصر", "التنقل بين العناصر", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            position -= 1;
            move(position);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (position == dataGridView1.Rows.Count - 1)
            {
                MessageBox.Show("هذا هو اخر عنصر", "التنقل بين العناصر", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            position += 1;
            move(position);
        }
    }
}
