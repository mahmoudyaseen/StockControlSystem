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
    public partial class FRM_ORDERS : Form
    {
        BL.CLS_ORDERS order = new BL.CLS_ORDERS();
        //هنملى الداتا جريد فيو الخاصة بالمنتجات عن طريق داتا تيبول احنا هنعملة
        //هنعمل فانكشن ونستدعيها احسن
        DataTable dt = new DataTable();
        void create_datatable()
        {
            dt.Columns.Add("رقم المنتج");
            dt.Columns.Add("اسم المنتج");
            dt.Columns.Add("تمن المنتج");
            dt.Columns.Add("الكميه");
            dt.Columns.Add("المبلغ");
            dt.Columns.Add("نسبة الخصم(%)");
            dt.Columns.Add("المبلغ الاجمالى");

            dataGridView1.DataSource = dt;
            //هعمل زرار لما اليوزر يدوس علية يعرض كل المنتجات هو يختار منها لو هو مش حافظ رقم المنتج
            /*
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            //فية تيكست بوكس واتشك بوكس  واغلب الادوات

            btn.HeaderText = "اختيار منتج";//اسم العمود
            btn.Text = "البحث";//الاسم اللى موجود على الزرار بس مش هيظهر الا لما نفعل خاصية النص
            btn.UseColumnTextForButtonValue = true;//بس الاسم مش هيظهر الا لما اكتب ف الصف بتاع الزرار ف الداتا جريد فيو
            //dataGridView1.Columns.Add(btn);//كدة الزرار هيتضاف ف الاخر فلازم اكتبة الاول قبل العواميد دى 
            //او اكتب الفانكشن دى
            dataGridView1.Columns.Insert(0, btn);//بحدد مكانة والزرار
            بس الطريقة دى مش حلوة علشان لو عاوز ابيع منتجات كتير هتوة ومتعبة لليوزر
            وكنت هخلى اليوزر يكتب رقم المنتج وانا اكتبلة ف الخانة الاسم والسعر وهو يكتب عدد المنجات
            فلو كتير اليوزر هيتوه
            فالافضل انى احط تيكست بوكس فوق الداتا جريد فيو يدخل فية اليوزر المعلومات والداتا جريد فيو 
            يستخدم بس لعرض معلومات المنتجات اللى هيشتريها الزبون
            */
        }
        //عاوزين ننسق الداتا جريد فيو علشان يكون عرض الاعمدة يساوى عرض التيكست بوكس اللى فوقها
        void resize_datagridview()
        {
            //لازم الغى خاصية autosize   يعنى اخليها none بدل fill علشان ما يحصلش خطا
            //المفروض كنت اخد حجم كل ليبول من الخائص واكتبها بس انا عملت طريقة احسن وانى اخد حجم الليبول بالكود
            //المؤشر اللى ف اول الصف دة اللى بيسمح بتحديد الصف كامل او نقلة من مكان لمكان اسمة RowHeaders
            dataGridView1.RowHeadersWidth = label11.Size.Width;//dataGridView1.RowHeadersWidth = 71;
            dataGridView1.Columns[0].Width = label12.Size.Width;
            dataGridView1.Columns[1].Width = label13.Size.Width;
            dataGridView1.Columns[2].Width = label14.Size.Width;
            dataGridView1.Columns[3].Width = label15.Size.Width;
            dataGridView1.Columns[4].Width = label16.Size.Width;
            dataGridView1.Columns[5].Width = label17.Size.Width;
            dataGridView1.Columns[6].Width = label18.Size.Width;
        }
        public FRM_ORDERS()
        {
            InitializeComponent();
            create_datatable();//استدعينا الفانكشن اللى هتملى الداتا جريد فيو
            resize_datagridview();//لازم الغى خاصية autosize   يعنى اخليها none بدل fill علشان ما يحصلش خطا
            txtsalseman.Text = Program.salesnam;//اسم المستخدم
        }

        private void butnnew_Click(object sender, EventArgs e)
        {
            txtorderid.Text = order.get_the_next_order_id().Rows[0][0].ToString();
            butnnew.Enabled = false;
            butnadd.Enabled = true;
        }

        private void butnbrowse_Click(object sender, EventArgs e)
        {
            FRM_CUSTOMERS_LIST cust_list = new FRM_CUSTOMERS_LIST();
            cust_list.ShowDialog();//لما يدوس دابل كلك هيتقفل الفورم دة علشان انا قايلة كدة ف الحدق دابل كلك ف الداتا جريد فيو اللى هناك
            //الاحسن انى اغير القيم من هنا علشان لو هغيرها من هناك كان لازم اعمل الفورم دى
            //كفورم واحده للبرنامج كلة علشان بعدل على فورن من فورم تانية
            txtcustid.Text = cust_list.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtcustfname.Text = cust_list.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtcustlname.Text = cust_list.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtcusttel.Text = cust_list.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtcustemail.Text = cust_list.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            if(cust_list.dataGridView1.CurrentRow.Cells[5].Value is DBNull)
            {//ف الداتا جريد فيو لازم نكتب  is DBNull مش ==null 
                pictureBox1.Image = null;
                return;//هيخرج مش هينفذ باقى الكود
            }
            byte[] img = (byte[])(cust_list.dataGridView1.CurrentRow.Cells[5].Value);
            MemoryStream ms = new MemoryStream(img);
            pictureBox1.Image = Image.FromStream(ms);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //افرض انا كنت كاتب كمية وسعر وماضيفتش السطر وهفكنى من المنتج دة وهضيف منتج تانى 
            //فلازم افضى التيكست بوكس علشان لو انا كنت كاتب اسعار ما تبقال مكتوبة ف المنتج التانى
            clear();
            FRM_PRODUCTS_LIST frm = new FRM_PRODUCTS_LIST();
            frm.ShowDialog();
            txtprocid.Text = frm.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtprocname.Text = frm.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtprocprice.Text = frm.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            //هنخلية مستعد يكتب الكمية على طول 
            txtprocqty.Focus();
        }

        private void txtprocqty_KeyPress(object sender, KeyPressEventArgs e)
        {
            //هنمنع النصوص هنسمج بس بالارقام و الزرار اللى بيمسح الباك سبيس ورمزة ف الاسكى 8
            if(!char.IsDigit(e.KeyChar)&& e.KeyChar!=8 )
            {
                //e.KeyChar معناه النص اللى هيدخل بالكيبورد للايفنت
                //!char.IsDigit(e.KeyChar) الحرف اللى داخل فe.KeyChar مش ديجت امنع الدخول بكود الشرط
                // e.KeyChar!=8 لو مش باك سبيس امنع بردو
                e.Handled = true;//تمنع الحرف
            }
        }

        private void txtprocprice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar)&&e.KeyChar!=8&&e.KeyChar!=Convert.ToChar(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator))
            {
                //System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator بتسمح بالعلامة العشرية بس بتشوفها فالنظام الاول هى . ولا ,وبتسمح بيها
                //كان ممكن اكتب using System.Globalization; فوق 
                e.Handled = true;
            }
        }
        private void txtprocdiscound_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }


        //هنعمل فانكشن تحسب المبلغ ونستدعيها لما اليوزر يعمل كى اب ف التيكست بوكس واحد من الاتنين الكمية والثمن
        void amount()
        {
            //لو مافيش تيكست بوكس منهم فاضى هيحسب الكمية علشان لو فاضى وحسبنا هيحصل ايرور
            if (txtprocqty.Text != string.Empty && txtprocprice.Text != string.Empty)
                txtprocamount.Text = ((Convert.ToDouble(txtprocprice.Text)) * (Convert.ToInt32(txtprocqty.Text))).ToString();
            //طيب هو لو قعد يمسح ومابقاش فية ارقام هيفضل السعر بتاع الرقم القديم موجود فلازم اشيلة لما يمسح الرقم كامل من واحد من ال2 تيكست بوكس
            else 
                txtprocamount.Text = string.Empty;
                //txtproctotalamount.Text = string.Empty; مش لازم اكتب دى لان انا لو شيلت السعر هيتشال السعر الكلى من الفانكشن اللى بتحسب السعر الكلى
        }
        //ولما يشيل صباعة من الزرار بتاع النسبة او الكمية او السعر يحسب الكمية الكلية هعمل فانكشن واستدعيها
        void total_amount()
        {
            //لو فية تيكست بوكس من النسية او الثمن فاضى هيحصل ايرور فهعمل اف
            if (txtprocamount.Text != string.Empty && txtprocdiscound.Text != string.Empty)
            {
                double disc = Convert.ToDouble(txtprocdiscound.Text);//انا عملتها دابل مش انت علشان لما اقسمها على 100 ماترجعش0 ترجع الكسور 
                double amount = Convert.ToDouble(txtprocamount.Text);
                double total = amount - (amount * disc / 100);
                txtproctotalamount.Text = total.ToString();
            }
            //طيب هو لو قعد يمسح ومابقاش فية ارقام هيفضل السعر بتاع الرقم القديم موجود فلازم اشيلة لما يمسح الرقم كامل من واحد من ال3 تيكست بوكس
            //لان السعر معتمد على سعر المنتج والكمية
            else
                txtproctotalamount.Text = string.Empty;
        }
        private void txtprocprice_KeyUp(object sender, KeyEventArgs e)
        {
            amount();
            total_amount();
        }

        private void txtprocqty_KeyUp(object sender, KeyEventArgs e)
        {
            amount();
            total_amount();
        }
        //كان ممكن ما اكتبش الفانكشن اللى بتحسب المبلغ الكلى ف الكى اب للتمن او الكمية وكنت اكتبها مرة واحدة ف الحدث تيكست تشينج للamount
        //بس اكتبها ف الاتنين اسها هما كدة كدة الحدثين مستدعيين
        private void txtprocdiscound_KeyUp(object sender, KeyEventArgs e)
        {
            total_amount();
        }
        private void txtprocprice_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtprocprice.Text != string.Empty && e.KeyCode == Keys.Enter) //لو داس انتر وكان مكتوب حاجة ف السعر هيفوكس على الكمية
                txtprocqty.Focus();
        }

        private void txtprocqty_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtprocqty.Text != string.Empty && e.KeyCode == Keys.Enter)
                txtprocdiscound.Focus();
        }
        void clear()
        {
            txtprocid.Clear();
            txtprocname.Clear();
            txtprocprice.Clear();
            txtprocqty.Clear();
            txtprocamount.Clear();
            txtprocdiscound.Clear();
            txtproctotalamount.Clear();
        }
        private void txtprocdiscound_KeyDown(object sender, KeyEventArgs e)
        {
            //المفروض هنا لما ادوس انتر يضيف السطر ف الداتا جريد فيو وهنفضى التيكست بوكس و هنجمع المبالغ النهائية
            //طيب افرض هو داس انتر على التيكست بوكس بتاع النسبة المئوية وهو كاكتبش رقم ف السعر او الكمية او النسبة الماوية
            //فهو لو ماكتبش رقم ف اى تيكست بوكس هو المفروض يكتب فية مش هيحسب السعر النهائى فهيكون فاضى فانا ممكن اكتب الشرط بالنقطة دى
            //لو ما كتبتش الشرط دة txtproctotalamount.Text !=string.Empty كنت المفروض اتاكد عن ان فية ارقام ف السعر والكمية ونسبة التخفيض
            //فدة اسهل
            if (e.KeyCode == Keys.Enter && txtproctotalamount.Text !=string.Empty)
            {
                //هتاكد من الكمية المتاحة
                if(order.verify_qut(txtprocid.Text,Convert.ToInt32(txtprocqty.Text)).Rows.Count<1)
                {
                    MessageBox.Show("الكمية غير متوفرة", "اضافة منتج", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //المفروض لو السطر موجود ما يتضافش 
                for (int i = 0; i < dataGridView1.Rows.Count ; i++)//خلى بالك بقول المتغير اقل من عدد السطور مش عدد السطور ناقص واحد
                //ممكن تنفع عدد السطور -1 لو انا سامح ان اليوزر يضيف سطر من الداتا جريد فيو لان عدد السطور عيكون زيادة واحد عن اللى موجود علشان السطر الجديد اللى بيطون موجود على طول لو مفعل الخاصية دى
                {
                    if (txtprocid.Text == dataGridView1.Rows[i].Cells[0].Value.ToString())//لو الاى دى اللى مكتوب ف التيكست بوكس موجود ف الجدول اخرج من الحدث وماتضيفش السطر
                    {
                        MessageBox.Show("هذا المنتج مضاف من قبل", "اضافة منتج", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                //هنعمل داتا رو ونملاها ونضيفها للداتا جريد فيو
                DataRow r = dt.NewRow();//لازم اقولك الرو من انى جدول
                r[0] = txtprocid.Text;
                r[1] = txtprocname.Text;
                r[2] = txtprocprice.Text;
                r[3] = txtprocqty.Text;
                r[4] = txtprocamount.Text;
                r[5] = txtprocdiscound.Text;
                r[6] = txtproctotalamount.Text;
                dt.Rows.Add(r);
                dataGridView1.DataSource = dt; //هنحدث الجدول علشان يظهر التاثير وقتى
                clear();//هنفضى الخانات علشان منتج جديد
                butnbrowseprod.Focus();//علشان يكون جاهز لاضافة منتج تانى

                        //ممكن اعمل لوب يوصل لعدد الاسطر ف الداتا تيبول او الداتا جريد فيو واجمع القيم اللى ف العمود رقم 6 
                        //بس انا هستخدم link
                txtalltotalamounts.Text = (from DataGridViewRow row in dataGridView1.Rows
                                           where row.Cells[6].FormattedValue.ToString() != string.Empty //الشرط يعنى امشى لحد ماتلاقيش قيمة
                                           select Convert.ToDouble(row.Cells[6].FormattedValue.ToString())).Sum().ToString();
                //.sum() بترجع المجموع ممكن اكتب ماكس او منيمام او افاريدج فانكشن جاهزة يعنى
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            //كان ممكن اعدل على الداتا تيبول وانا معايا رقم العنصر هجيبة من dataGridView1.CurrentRow.Index واعمل ريفرش للداتا جريد فيو 

            //لما يدوس دابل كلك على منتج ف الداتا جريد فيو يجيب بياناتة ف التيكست بوكس علشان تتعدل
            txtprocid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtprocname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtprocprice.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtprocqty.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtprocamount.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtprocdiscound.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            //لما يدوس انتر هيتفعل الحدث كلك داون وهيتضاف بالتحديث
            //بس هيتاكد ان المنتج مش موجود قبل كدة فهيلاقية موجود فمش هيتضاف
            //فلازم اشيل السطر من الداتا جريد فيو قبل التعديل
            txtproctotalamount.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
            //فاكر الدرس بتاع الداتا بايدنج انا لما قولت ان الداتا تيبول مصدر للداتا جريد فيو فالاتنين كدة مرتبطين ببعض فلما بعدجل ف واحدة بعدل ف التانية
            //فية حاجة تانى لما بحذف المنتج سعره بيفضل موجود ف المجموع اللى تحت الجدول مابيتعدلش الا لما بضيف منتج 
            //فروح للحدث اللى بيحصل لما بشيل سطر من الداتا جريد قيو واحدث المجموع
            txtprocqty.Focus();
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            //فية حاجة تانى لما بحذف المنتج سعره بيفضل موجود ف المجموع اللى تحت الجدول مابيتعدلش الا لما بضيف منتج 
            //فروح للحدث اللى بيحصل لما بشيل سطر من الداتا جريد قيو واحدث المجموع
            txtalltotalamounts.Text = (from DataGridViewRow row in dataGridView1.Rows
                                       where row.Cells[6].FormattedValue.ToString() != string.Empty
                                       select Convert.ToDouble(row.Cells[6].FormattedValue.ToString())).Sum().ToString();
        }

        private void تعديلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1_DoubleClick(sender, e);
        }

        private void حذفالسطرالمحددToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
        }

        private void حذفالكلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dt.Clear();//بفضى المصدر 
            dataGridView1.Refresh();//علشان التاثير يظهر وقتى
            //طريقة تانى مش عارف مش شغالة لية
            //for (int i=0;i<dataGridView1.Rows.Count;++i)
            //    dataGridView1.Rows.RemoveAt(i);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Close();
        }
        //هفضى كل حاجة بعد اما يدوس اضافة 
        void clearall()
        {
            txtorderid.Clear();
            txtdes.Clear();
            dateTimePicker1.ResetText();
            txtcustfname.Clear();
            txtcustlname.Clear();
            txtcustid.Clear();
            txtcustemail.Clear();
            txtcustid.Clear();
            txtcusttel.Clear();
            pictureBox1.Image=null;
            dt.Clear();
            dataGridView1.Refresh();
            clear();
            txtalltotalamounts.Clear();
            butnadd.Enabled = false;
            butnnew.Enabled = true;
            butnprint.Enabled = true;
        }

        private void butnadd_Click(object sender, EventArgs e)
        {
            if(txtorderid.Text==string.Empty || txtcustid.Text == string.Empty || txtdes.Text == string.Empty || txtsalseman.Text == string.Empty || dataGridView1.Rows.Count < 1)
            {
                MessageBox.Show("يجب ملا البيانات اولا ", "الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //بيانات الفاتورة 
            order.add_order(Convert.ToInt32(txtorderid.Text), dateTimePicker1.Value, Convert.ToInt32(txtcustid.Text), txtdes.Text, txtsalseman.Text);
            //دلوقتى انا عاوز اجيب اسم البائع فهعمل متغير للبرنامج كامل ف الكلاس الاول هو program.cs وهحط فية اسم البائع اول لما يدخل ف الفورم لوج ان

            //تفاصيل كل منتج ف الفاتورة
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {//بضيف كل منتج اتباع ف الفاتورة ف سطر لوحدة ف الجدول تفاصيل الفاتورة
                order.add_order_details(dataGridView1.Rows[i].Cells[0].Value.ToString(),
                                        Convert.ToInt32(txtorderid.Text),
                                         Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value),
                                         dataGridView1.Rows[i].Cells[2].Value.ToString(),
                                         Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value),
                                         dataGridView1.Rows[i].Cells[4].Value.ToString(),
                                         dataGridView1.Rows[i].Cells[6].Value.ToString());
                //المفروض هناانقص الكمية اللى هبيعها من الكمية الكلية التنقيص ف الاجراء المخزن
            }
            MessageBox.Show("تم الحفظ بنجاح", "الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            clearall();
        }

        private void butnprint_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;//Cursor يعنى مؤشر الماوس و ويت كيرسور دى الدايرة اللى بتلف اللى بتدل ان فية حاجة بتحمل
            //هنطبع اخر فاتورة هنجيب رقم الفاتورة من اجراء مخزن
            int id = Convert.ToInt32(order.get_the_order_id_to_print().Rows[0][0]);
            RPT.RPT_ORDERS report = new RPT.RPT_ORDERS();//دى فيها كل المنتجات اللى اتباعت قبل كدة لانى ماحددتش شرط ف الاجراء المخزن
            RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
            report.SetDataSource(order.get_order_details(id));//هنا مش محتاج اعمل ريفرش للريبورت
            //هنا حطيت مصدر للبيانات اللى انا عاوزها ولازم يكون المصدر بيعرض كل اللى بيعرضة الريبورت وبنفس الاسم
            //لو ماحطيتش المصدر هيطبع اللى جوة الريبورت اصلا وهو كل المنتجات اللى متباعة قبل كدة 
            //كان ممكن اطبع من اجراء مخزن واحد زى ما كنت بعمل ف المنتجات 
            //بس بيحصل خطا فلازم اروح لل app.config وغير 
            //<startup>اشيل دى
            //واكتب <startup useLegacyV2RuntimeActivationPolicy="true"> 
            frm.crystalReportViewer1.ReportSource = report;
            frm.ShowDialog();
            Cursor = Cursors.Default;//نرجع الشكل الطبيعى للماوس
        }
    }
}
