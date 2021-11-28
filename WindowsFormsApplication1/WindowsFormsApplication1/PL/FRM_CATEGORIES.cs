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
using CrystalDecisions.CrystalReports;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
namespace WindowsFormsApplication1.PL
{
    public partial class FRM_CATEGORIES : Form
    {
        SqlConnection sqlcn=new SqlConnection(@"Server=.;DataBase=Product_DB;Integrated Security=True");
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        BindingManagerBase bmb;//بيتحكم ف الكائنات اللى مربوطة كلها بنفس المصدر وبتستخدم كمؤشر للمصدر دة
        //وبيعمل نفس اللى بيعملة بس باسلوب مختلف الكارنسى مانجر بيتعمال مع الداتا سورس اكنة ليست CurrencyManagerيشبة 
        SqlCommandBuilder cmdb;//بتعمل جدول من الاوامر اللى بتقير ف الداتا تيبول علشان تتطبق ف الداتا بيز عن طريق الامر ابديت
        public FRM_CATEGORIES()
        {
            InitializeComponent();
            //الداتا ادابتر تتكفل بفتح و غلق الاتصال وتنفذ الكود ف سطر التعريف كلهم ف نفس الطر يعنى وهو السطر الجى
            da = new SqlDataAdapter("select ID_CAT as 'رقم النوع',Descripyion_CAT as 'النوع' from CATEGORES",sqlcn);
            da.Fill(dt);
            dataGridViewcat.DataSource = dt; //كدة انا ربط الداتا تيبول بالداتا جريد فيو 
            //الداتا بايدنج تستخدم لربط ادوات على الفورم ببيانات ف قاعدة البيانات
            txtid.DataBindings.Add("text", dt, "رقم النوع");//كدة انا ربط الداتا تيبول بالتيكست بوكس
            //وانا كنت رابط الداتا جريد فيو بالداتا تيبول يعنى كدة التيكست بوكس مربوط بالداتا جريد فيو
            //يعنى لما اختار صف ف الداتا جريد فيو هتظهربياناتة ف التيكست بوكس
            //خلى بالك انا باخد البيانات من الداتا تيبول وانا مغير اسماء الاعمدة ف الداتا تيبول فلازم اكتب الاسم الجديد
            txtdes.DataBindings.Add("text", dt, "النوع");
            bmb = BindingContext[dt];//كدة انا هتحكم ف الكائنات اللى مربوطة بالداتا تيبول بالداتا بايندنج
            //هيشتغل كمؤشر للداتا تيبول وبيظهر البيانات ف الادوات المربوطة بية 
            //ولو اخترت مثلا صف ف الداتا جريد فيو الكارنسى مانجر هيروح يشاور على الصف دة ف الداتا تيبول
            /*بما ان الداتا تيبول مربوط بالداتا جريد فيو 
             * و التيكست بوكس مربوط بالداتا تيبول 
             * والبايندنج مانجر بيز مربوطة بالداتا تيبو 
             * فالداتا جريد فيو مربوط بالتيكست بوكس بالبايندنج مانجر بالداتا تيبول
             * فاللى هيحصل ف واحدة هيظهر تاثيؤها على الباقى*/
            label3.Text = (bmb.Position + 1) + "/" + bmb.Count;
        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void butnclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void butnfirst_Click(object sender, EventArgs e)
        {
            bmb.Position = 0;
            label3.Text = (bmb.Position + 1) + "/" + bmb.Count;
        }

        private void butnpriv_Click(object sender, EventArgs e)
        {
            bmb.Position -= 1;
            label3.Text = (bmb.Position + 1) + "/" + bmb.Count;
        }

        private void butnnext_Click(object sender, EventArgs e)
        {
            bmb.Position += 1;
            label3.Text = (bmb.Position + 1) + "/" + bmb.Count;
        }

        private void butnlast_Click(object sender, EventArgs e)
        {
            bmb.Position = bmb.Count;
            label3.Text = (bmb.Position + 1) + "/" + bmb.Count;
        }
        /*بص انا رابط الداتا تيبول و التيكست بوكس و الداتا جريد فيو والداتا بايدندنج مانجر
         * فاى حاجة هتحصل ف واحدة هتحصل ف الباقى 
         * فلو غيرت الاسم ف التيكست بوكس هيتغير فالداتا تيبول والداتا جريد فيو 
         * SqlCommandBuilderبس مش هيتغي ف الداتا بيز فلازم اطبق التغير ف الداتا بيز عن طريق ال*/
        private void butnnew_Click(object sender, EventArgs e)
        {
            bmb.AddNew();
            //بتضيف صف جديد ف اخر الداتا تيبول وبتشاور عليه فيحصل التاثير ف الداتا جريد فيو والتيكست بوكس

            //هو لو فضل يدوس كدة على جديد هيفضل يعمل سطر جديد فانا المفروض الغى الزرار جديد لحد ما يدود ادد
            butnnew.Enabled = false;
            butnadd.Enabled = true;
            txtid.Text =Convert.ToString( bmb.Count);
            //طريقة تانية عقيمة 
            //int id = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][0]) + 1;
            //txtid.Text = id.ToString();
        }

        private void butnadd_Click(object sender, EventArgs e)
        {
            //  هو اكيد كدة خلاص خلص كتابة والتعديل حصل ف الجداول فهنهى العملية الحالية علشان يتحط ف السكل كوماند بلدر وهطبق ف الداتا بيز
            bmb.EndCurrentEdit();
            //هو كدة التحديث حصل ف الجداول وكل حاجة ناقص بس الداتا بيز
            cmdb = new SqlCommandBuilder(da);//بياخد داتا ادابتر
            //فهيعمل جدول وفية الاوامر اللى حصلت او العمليات اللى حصلت ف الداتا تيبول

            da.Update(dt);//دة بيحدث البيانات ف الداتا بيز 
                          //سواء كان ابديت او حذف از اضافة حصلت ف الداتا تيبول وبيحدث البيانات ف الداتا بيز

            /* بعد كل عملية علشان يعمل جدول ويخزن العمليات فية ويبعتها للداتا ادابتر SqlCommandBuilder بكتب
             علشان كدة لازم انهر العملية قبل ما اكتب سكل كوماند بيلدر علشان هو بياخد العمليات المنتهية
             وبعدين بكتب الابديت ودة بينفذ العمليات ف الداتا بيز اللى ف جدول الاوامر سواء اضافة او تحديث او حذف
             علشان كدة الامرين دول بيتكتبوا مع بعض علشان يحدث الداتا بيز*/
            //من الاخر كدة السكل كوماند بيلدر بديلة الاوامر و الابديت بينفذها ف الداتا بيز

            butnadd.Enabled = false;
            butnnew.Enabled = true;
            label3.Text = (bmb.Position + 1) + "/" + bmb.Count;
            MessageBox.Show("تمت عملية الاضافة", "الاضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void butnremove_Click(object sender, EventArgs e)
        {
            //هشيل السطر 
            bmb.RemoveAt(bmb.Position);
            //هنهى العملية علشان تتحط ف السكل كومند بيلدر
            bmb.EndCurrentEdit();
            cmdb = new SqlCommandBuilder(da);
            da.Update(dt);
            label3.Text = (bmb.Position + 1) + "/" + bmb.Count;
            MessageBox.Show("تمت عملية الحذف", "الحذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //خلى بالك انا عامل الرقم النوع بيزيد لوحدة بمقدار واحد ف الداتا بيز
            //فلما احذف مش هيتاثر بالحذف هيزيد وكان الحذف ماحصلش فعلشان كدة الافضل اننا نعمل 
            //عمود تانى لترتيب الانواع عند اليوزر واخلية ما يزدش لوحدة واخلى العمود اللى بيزيد دة ليا علشان اتعامل بية ف الجداول التانية
            //بس مش مشكله انا هلغى الزيادة ف الصف بتاع رقم النوع ف الداتا بيز
        }

        private void butnupdate_Click(object sender, EventArgs e)
        {
            //لو كتبت ف التيكست بوكس فيتكتب ف الداتا تيبول فتعتبر عملية 
            bmb.EndCurrentEdit();//ننهى العمليات اللى حصلت ف الداتا تيبول عن طريق التيكست بوكس
            cmdb = new SqlCommandBuilder(da);
            da.Update(dt);
            label3.Text = (bmb.Position + 1) + "/" + bmb.Count;//مش محتاج السطر دة
            MessageBox.Show("تمت عملية التعديل", "التعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void butnprintall_Click(object sender, EventArgs e)
        {
            //الريبورت لما يتحط جواه حاجة ما بتفضاش غير ب ريفرش حتى لو قفلت البرنامج وفتحتة
            RPT.PRT_ALL_CATEGORIES report = new RPT.PRT_ALL_CATEGORIES();
            RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
            //لو ضيفت نوع جديد مش هيبان لازم اعمل ريفرش للكريستال ريبورت لانها لما بتتملى ما بتفضاش بتفضل مملية بالبيانات القديمة حتى بعد غلط البرنامج
            report.Refresh();
            frm.crystalReportViewer1.ReportSource = report;
            frm.ShowDialog();
        }

        private void butnprintone_Click(object sender, EventArgs e)
        {
            //الريبورت لما يتحط جواه حاجة ما بتفضاش غير ب ريفرش حتى لو قفلت البرنامج وفتحتة
            RPT.PRT_ONE_CAT_WITH_PROD report = new RPT.PRT_ONE_CAT_WITH_PROD();
            RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
            report.Refresh();//لازم قبل ما اديلة الباراميتر علشان لو عملت ريفرش بعد ما اديتلة الباراميتر هيرجع الريبورت جديد وهيطلب الباراميتر تانى
            report.SetParameterValue("@ID",Convert.ToInt32(txtid.Text));
            frm.crystalReportViewer1.ReportSource = report;
            frm.ShowDialog();
        }

        private void FRM_CATEGORIES_Load(object sender, EventArgs e)
        {

        }

        private void butnalltopdf_Click(object sender, EventArgs e)
        {
            RPT.PRT_ALL_CATEGORIES report = new RPT.PRT_ALL_CATEGORIES();
            report.Refresh();
            ExportOptions export = new ExportOptions();
            DiskFileDestinationOptions dfoption = new DiskFileDestinationOptions();
            PdfFormatOptions pdfoption = new PdfFormatOptions();
            export = report.ExportOptions;
            SaveFileDialog save = new SaveFileDialog();
            if (save.ShowDialog() == DialogResult.OK)
            {
                dfoption.DiskFileName = save.FileName + ".pdf";
            }
            export.ExportDestinationOptions = dfoption;
            export.ExportDestinationType = ExportDestinationType.DiskFile;
            export.ExportFormatOptions = pdfoption;
            export.ExportFormatType = ExportFormatType.PortableDocFormat;
            report.Export();
            MessageBox.Show("تم حفظ الانواع ", "حفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void butncatwithproducts_Click(object sender, EventArgs e)
        {
            RPT.PRT_ONE_CAT_WITH_PROD report = new RPT.PRT_ONE_CAT_WITH_PROD();
            report.Refresh();
            report.SetParameterValue("@ID", Convert.ToInt32(txtid.Text));
            ExportOptions export = new ExportOptions();
            DiskFileDestinationOptions dfoption = new DiskFileDestinationOptions();
            PdfFormatOptions pdfoption = new PdfFormatOptions();
            export = report.ExportOptions;
            SaveFileDialog save = new SaveFileDialog();
            if(save.ShowDialog()==DialogResult.OK)
            {
                dfoption.DiskFileName = save.FileName + ".pdf";
            }
            export.ExportDestinationOptions = dfoption;
            export.ExportDestinationType = ExportDestinationType.DiskFile;
            export.ExportFormatOptions = pdfoption;
            export.ExportFormatType = ExportFormatType.PortableDocFormat;
            report.Export();
            MessageBox.Show("تم الحفظ ", "الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
