using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;           //

namespace WindowsFormsApplication1.PL
{
    public partial class FRM_ADD_DRODUCT : Form
    {
        public string state = "add";
        BL.CLS_PRODUCT PRD = new BL.CLS_PRODUCT();
        public FRM_ADD_DRODUCT()
        {
            InitializeComponent();
            combocategories.DataSource = PRD.Select_Category(); ;
            combocategories.DisplayMember = "Descripyion_CAT";
            combocategories.ValueMember = "ID_CAT";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "ملف الصورة |*.PNG; *.JPG; *.GIF; *BMP";
            if(ofd.ShowDialog()==DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (state == "add")
            {
                MemoryStream ms = new MemoryStream();//تخزين البيانات على الميمورى

                //اول باراميتر بياخذ اسم الموميرى استريم المكان اللى هيتخزن فية الصورة 
                //تانى باراميتر نوع التخزين
                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                byte[] picturebyte = ms.ToArray();//بحول بيانات الصورة لمصفوفة تانئية واخزنها ف الاراى اللى نوعة بايت
                                                  //combocategories.SelectedValue بيرجع ال primary key للعنصر المحتار
                                                  //combocategories.Selectedtext بيعرض العنصر المحتار
                PRD.add_product(Convert.ToInt32(combocategories.SelectedValue), txtref.Text, txtdes.Text,
                                    Convert.ToInt32(txtquant.Text), txtprice.Text, picturebyte);
                MessageBox.Show("تمت الاضافة بنجاح", "اضافة منتج", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                byte[] picturebyte = ms.ToArray();
                PRD.update_product(Convert.ToInt32(combocategories.SelectedValue), txtref.Text, txtdes.Text,
                                    Convert.ToInt32(txtquant.Text), txtprice.Text, picturebyte);
                MessageBox.Show("تم التعديل بنجاح", "تعديل منتج", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            FRM_PRODUCTS.get_form_details.dataGridView1.DataSource = PRD.getallproducts();
            //ميزة دى عند كل ضغطة اضافة او تحديث يتحدث الداتا جريد فيو مش لازم اقفل نافذة الاضافة او التحديث
        }

        private void txtref_Validated(object sender, EventArgs e)
        {
            //احنا استخدمنا الفورم دى ف التعديل فكدة مش هيخلينى امشى الا لما اعدل على اصدار المنتج
            //والمفروض اصدار المنتح يبقى ثابت
            //فهنعمل متغير قيمتة عند الاضافة تختلف عن قيمتة عند التحديث علشان اعرف اخلى امتة اليوزر يغير الاصدار او لا
            if (state == "add")
            {
                DataTable dt = new DataTable();
                dt = PRD.verifyproductid(txtref.Text);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("هذا الاصدار موجود مسبقا", "اصدار المنتج", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtref.Focus();//يحط الموشر على اسم الاصدار علشان كل لما يمشى تانى يطلعلة الرسالة 
                                   //فمش هيعرف يمشى الا لما يغير الاصدار
                    txtref.SelectionStart = 0;//يحدد النص المكتوب من اول عنصر
                    txtref.SelectionLength = txtref.TextLength;//هيحدد لحد طول النص كامل
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
