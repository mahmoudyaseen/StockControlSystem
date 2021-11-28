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
    public partial class FRM_MAIN : Form
    {
        //من اول هنا الفديو 11 تاثير فروم على فورم اخر  الفديو تقيل###
        //انا عاوز التعديلات اللى هعملها من الفورم بتاعت اللوج ان تحصل ف الفورم دى مش ف نسخة منها
        //فهعمل متفير ف الكلاس دة فيلد يعنى وهيكون ستاتك علشان اقدر استدعية من غير ما انسخ كائن من الكلاس 
        //ونوعة يكون نوع الكلاس فلما هستخدم الكائن دة اكنى بستخدم الكلاس مش نسخة منة 
        //يعنى لما استدعى الكائن دة هستدعية من الكلاس مباشره ونوعة هيكون نوع الكلاس وهديله قيمة الفورم الحالى فهيكون اكنى بستخدم الكلاس(الفورم الحالى) مش نسخة منة
        private static FRM_MAIN frm;//هساوية بالفورم الحالى ف المشيد علشان اول حاجة بتتنفذ
        //طيب دلوقتى لما اقفل الفورم المفروض انهى الكائن 
        //هنعمل الحدث لما الفورم تتقفل ننهى الكائن 
        //هنعمل الفانكشن المرتبطة بالحدث الهاندل 
        static void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }
        //هعمل الدالة جيت علشان اعرف اجيب القيم من المتغير فورم علشان نوعة بريفيت
        public static FRM_MAIN getmainform
        {
            get
            {
                //الاول هشوف لو الكائن مابيساويش ال نال
                if(frm==null)
                {
                    frm = new FRM_MAIN();//وهساوية بالكلاس
                    //هنربط الحدث بالفانكشن هنا علشان لما اليوزر بيستخدم الكائن دة بيديلة قيمة من هنا 
                    //فلازم اربط الحدث بالهاندل هنا علشان لو قفل الفورم ينتهى الكائن
                    frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
                    //FormClosed دة حدث بربطة بالفانكشن اللى انا عاملها بالديليجيت FormClosedEventHandler
                }
                return frm;
            }
        }
        //بص الكائن دة منسوخ من الكلاس وفى هفس الوقت  من مكونات الكلاس فلما اعدل على الكائن 
        //هكون بعتبر بعدل على الكلاس لان الكائن من مكونات الكلاس  
        //لحد هنا
        public FRM_MAIN()
        {
            InitializeComponent();
            //هساوى هنا الكائن بالفورم لو كان مهدوم علشان لو كان موجود ادى هو اصلا بيساوى الفورم
            if(frm==null)//الجملة دى تبع 11
                frm = this;//=  frm = new FRM_MAIN()
            //هنلغى تفعيل القوائم لحد اما اليوزر يسجل الدخول
            //وخلى الفورم مين هى اللى تظهر الاول من program.cs
            المنتجاتToolStripMenuItem.Enabled = false;
            العملاءToolStripMenuItem.Enabled = false;
            المستخدمونToolStripMenuItem.Enabled = false;
            انشاءنسخةاحتياطيةToolStripMenuItem.Enabled = false;
            استرجاعنسخةاحتياطيةToolStripMenuItem.Enabled = false;
        }

        private void تسجيلالدخولToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_LOGIN frm = new FRM_LOGIN();
            frm.ShowDialog();//بتخلينى ما اعرفش اتعامل مع النافذة الرئيسية للبرنامج غير لما تتقفل الفورم دى
            //show اقدر اتعامل مع النافذة الخارجية
        }

        private void اضافةمنتججديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_ADD_DRODUCT fap = new FRM_ADD_DRODUCT();
            fap.ShowDialog();
        }

        private void ادارةالمنتجاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_PRODUCTS fm = new FRM_PRODUCTS();
            fm.ShowDialog();
        }

        private void ادارةالاصنافToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_CATEGORIES frm = new FRM_CATEGORIES();
            frm.ShowDialog();
        }

        private void ادارةالعملاءToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_CUSTOMERS frm = new FRM_CUSTOMERS();
            frm.ShowDialog();
        }

        private void اضافةبيعجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_ORDERS frm = new FRM_ORDERS();
            frm.ShowDialog();
        }

        private void ادارةالمبيعاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_ORDER_LIST frm = new FRM_ORDER_LIST();
            frm.ShowDialog();
        }

        private void اضافةمستخدمجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_ADD_USER frm = new FRM_ADD_USER();
            frm.ShowDialog();
        }

        private void ادارةالمستخدمينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_USER_LIST frm = new FRM_USER_LIST();
            frm.ShowDialog();
        }

        private void انشاءنسخةاحتياطيةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_BACKUP frm = new FRM_BACKUP();
            frm.ShowDialog();
        }

        private void استرجاعنسخةاحتياطيةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_RESTORE_BACKUP frm = new FRM_RESTORE_BACKUP();
            frm.ShowDialog();
        }

        private void اعداداتالاتصالبالسيرفرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_CONFIG frm = new FRM_CONFIG();
            frm.ShowDialog();
        }
    }
}
