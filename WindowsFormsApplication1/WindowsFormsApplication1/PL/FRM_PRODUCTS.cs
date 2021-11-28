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
using CrystalDecisions.CrystalReports;  //هحتاجهم علشان ملف الاكسل
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
namespace WindowsFormsApplication1.PL
{
    public partial class FRM_PRODUCTS : Form
    {
        //من هنا -----
        //هعمل زى ما عملت ف الفورم الرئيسية
        //لو عاوز اعدل على حاجة هنا من اى فورم تانى بعمل فورم واحد بس ف البرنامج كله من دة
        //علشان لما اعدل علية اعدل على الفورم الاصلى مش نسخة منة 
        private static FRM_PRODUCTS frm;
        static void frm_formclosed(object sender,FormClosedEventArgs e)
        {
            frm = null;
        }
        public static FRM_PRODUCTS get_form_details
        {
            get
            {
                if (frm == null)
                {
                    frm = new FRM_PRODUCTS();
                    frm.FormClosed += new FormClosedEventHandler(frm_formclosed);
                }
                return frm;
            }
        }
        //لهنا
        BL.CLS_PRODUCT prd = new BL.CLS_PRODUCT();
        public FRM_PRODUCTS()
        {
            InitializeComponent();
            if (frm == null)
                frm = this;//تبع هنا
            dataGridView1.DataSource = prd.getallproducts();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            product_image photo = new product_image();
            byte[] image = (byte[])prd.grt_image_product(dataGridView1.CurrentRow.Cells[0].Value.ToString()).Rows[0][0];
            MemoryStream ms = new MemoryStream(image);
            photo.pictureBox1.Image = Image.FromStream(ms);
            photo.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource= prd.searchproduct(txtsearch.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FRM_ADD_DRODUCT frm = new FRM_ADD_DRODUCT();
            frm.ShowDialog();
            //لو ضاف منتج جديد من النافذة دى هيظهر المنتج اول ما يتم البحث لكن لن يظهر مباشرة ف الداتا دجريد فيو
            //انا عاوزة اول لما يضيف عنصر من النافذة دى يظهر قدامة ف الجدول فهضيف تعبئة الجدول من جديد
            //dataGridView1.DataSource = prd.getallproducts();//عيب دى انها بتحصل بعد ما اقفل الفورم بتاع الاضافة او التعديل
            //ممكن اقفل النافذة ادارة المنتجات اول لما يفتح نافذة الاضافة وبالشكل دة لما يفتح تانى هيلاقى كل العناصر
            //دى هتظهر التعديل اول اما ادوس زر الاضافة او التعديل
            //بس انا هعمل الطريقة التانية اللى هى هتعامل مع الفورم كانة كائن واحد ف البرنامج كلة وهحدث الداتا جريد فيو ف فورم الاضافة
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("هل انت تريد حذف المنتج نهائيا","عملية الحذف",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                prd.deleteproduct(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                MessageBox.Show("تمت عملية الحذف بنجاح", "عملية الحذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //علشان يظهر التحديث ف الجدول وقتى
                dataGridView1.DataSource= prd.getallproducts();
            }
            else
            {
                MessageBox.Show("تم الغاء الحذف", "عملية الحذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //مش لازم اعمل فورم جديد ممكن اجيب الفورم بتاع الاضافة واعدل علية بس هخلى الحاجات اللى هعدل عليها بابلك مش بريفيت
            FRM_ADD_DRODUCT frm = new FRM_ADD_DRODUCT();
            frm.txtref.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            frm.txtdes.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            frm.txtquant.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            frm.txtprice.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            frm.combocategories.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            frm.Text = "تعديل منتج: " + frm.txtref.Text;
            frm.button2.Text = "تعديل";//هعدل اسم الزرار ل تعديل بدل اضافة
            //هغير هنا قيمة ال state علشان اخلى اليوزر يدخل نفس الاصدار عادى
            frm.state = "update";
            //لو عاوز ممكن اخلية ما يعيرش رقم الاصدار بس افرض هو غلط ف اسم الاصدار شوف المشترى عاوز اية 
            frm.txtref.ReadOnly = true;
            //عاوز اجيب الصورة من الداتا بيز 
            //اولا ببعت اسم اصدار المنتج والفانكشن بترجعلى جدول مافيعوش غير صورة واحدة فبححدها هتكون ف السطر الاول ف العمود الاول
            //وهحول الصورة ليلست من البايتات
            byte[] image = (byte[])prd.grt_image_product(dataGridView1.CurrentRow.Cells[0].Value.ToString()).Rows[0][0];
            MemoryStream ms = new MemoryStream(image);//هخلى الميمورى استريم قالب للليست جوة المومرى
            frm.pictureBox1.Image = Image.FromStream(ms);
            frm.ShowDialog();
            //dataGridView1.DataSource = prd.getallproducts();//عيب دى انها بتحصل بعد ما اقفل الفورم بتاع الاضافة او التعديل
            //دى هتظهر التعديل اول اما ادوس زر الاضافة او التعديل
            //بس انا هعمل الطريقة التانية اللى هى هتعامل مع الفورم كانة كائن واحد ف البرنامج كلة وهحدث الداتا جريد فيو ف فورم الاضافة
        }
        //الريبورت لما يتحط جواه حاجة ما بتفضاش غير ب ريفرش حتى لو قفلت البرنامج وفتحتة
        private void button5_Click(object sender, EventArgs e)
        {
            //بنعمل كائن من الريبورت 
            RPT.RPT_PRD_single report = new RPT.RPT_PRD_single();
            //بندى الريبورت قيمة الباراميتر و اسم الباراميتر اللى رايحلة 
            //لان مصدر الكريستال ريبورت هو اجراء مخزن بياخد باراميتر واحد
            report.Refresh();//علشان لو حصل تعديل يتطبق 
            report.SetParameterValue("@ID", dataGridView1.CurrentRow.Cells[0].Value.ToString());
            //هنعرف كائن من الفورم اللى بيها كريستال ريبورت 
            RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
            //هنربط الكريستال ريبورت بالفورم اللى مجهز يتعرض جواه كريستال ريبورت
            //لازن نخلى الكريستال ريبورت اللى ف الفورة بابلك مش بريفيت علشان اتحكم فيها من هنا
            frm.crystalReportViewer1.ReportSource = report;
            frm.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RPT.PRT_ALL_PRODUCTS report = new RPT.PRT_ALL_PRODUCTS();
            //انا واخد مصدرة من جدول يعنى مافيش باراميترات
            RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();//ممكن اعمل اكتر من فورم بس واحد كفاية واطبع علية اكتر من ريبورت
            report.Refresh();//علشان لو حصل تعديل يتطبق 
            frm.crystalReportViewer1.ReportSource = report;
            frm.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //اولا هجيب مجالات الاسماء اللى هستخدمها 

            //اولا هحدد الريبورت اللى هحطة ف ملف الايكسل 
            RPT.PRT_ALL_PRODUCTS report = new RPT.PRT_ALL_PRODUCTS();
            report.Refresh();//علشان لو حصل تعديل يتطبق 
            //هعرف كائن من الكلاس المسأول عن عملية اعدادات اخراج الملفات 
            ExportOptions export = new ExportOptions();

            //هعرف كائن من الكلاس المسؤول عن حفظ مسار الاخراج و نوع الملف المخرج
            //بكتب نوع الملف المخرج هنا علشان اعرف الويندوز بس ان نوعة اكسل
            DiskFileDestinationOptions edoption = new DiskFileDestinationOptions();

            // هعمل كائن من اعدادات ملف اكسل
            ExcelFormatOptions exceloption = new ExcelFormatOptions();
            //ممكن اخلية ورد او اكسل او بى دى اف او اى نوع
            //PdfFormatOptions pdf = new PdfFormatOptions();

            //هقول اعدادات الاخراج الخاصة بالكائن اكسبورت = اعدادات الاخراج الخاصة بالريبورت
            //هربط الاتنين ببعض يعنى
            export = report.ExportOptions;

            //هديلة المسار  ف الكائن اللى بياخد المسار واسم النوع
            //edoption.DiskFileName = @"E:\excel.xls";
            //ممكن اخد المسار من المستخدم 
            SaveFileDialog save = new SaveFileDialog();
            if (save.ShowDialog() == DialogResult.OK)
            {
                edoption.DiskFileName = save.FileName + ".xls";
                //edoption.DiskFileName = save.FileName + ".pdf";//ممكن اخلية ورد او اكسل او بى دى اف او اى نوع
            }

            //هجهز اعدادات الاخراج
            //هربط بقا اعدادات الاخراج بمسار الاخراج
            export.ExportDestinationOptions = edoption;

            //هربط اعدادات الاخراج بنوع مسار الاخراج
            export.ExportDestinationType = ExportDestinationType.DiskFile;//يعنى موجد ف ملف انا مديلة مسار ملف يعنى

            //هربط اعدادات الاخراج بالنوع المراد اخراج الملف بة
            export.ExportFormatType = ExportFormatType.Excel;
            //export.ExportFormatType = ExportFormatType.PortableDocFormat;//لل pdf

            //هربط اعدادات الاخراج باعدادات ملف اكسل
            export.ExportFormatOptions = exceloption;
            //export.ExportFormatOptions = pdf;//ممكن اخلية ورد او اكسل او بى دى اف او اى نوع

            //واخيرا هنفذ الاخراج 
            report.Export();
            MessageBox.Show("save done", "save", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
