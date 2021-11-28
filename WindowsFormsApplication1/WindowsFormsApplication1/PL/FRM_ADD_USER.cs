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
    public partial class FRM_ADD_USER : Form
    {
        public FRM_ADD_USER()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(txtid.Text==string.Empty || txtfullname.Text == string.Empty || txtpasw.Text == string.Empty 
                || txtconpasw.Text == string.Empty || comboBox1.Text == string.Empty)
            {
                MessageBox.Show("يرجى ملا البيانات كاملة", "الاضافة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtconpasw.Text != txtpasw.Text)
            {//كتبتها هنا كمان علشان لو مغيرش كلمة المرور مايعرفش يضيف بردو
                MessageBox.Show("كلمات المرور غير متطابقة", "الاضافة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            BL.CLS_LOGIN login = new BL.CLS_LOGIN();
            if (butusernew.Text == "اضافة مستخدم")
            {
                //لازم اتاكد ان ال id مش موجود قبل كدة
                if(login.verify_user_ID(txtid.Text).Rows.Count >0)
                {
                    MessageBox.Show("هذا الاسم موجود مسبقا يرجى تغير الاسم الاول ", "الاضافة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtid.Focus();
                    txtid.SelectionStart=0;
                    txtid.SelectionLength = txtid.TextLength;
                    return;
                }
                login.add_user(txtid.Text, txtpasw.Text, comboBox1.Text, txtfullname.Text);
                MessageBox.Show("تم الاضافة ", "الاضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(butusernew.Text == "تعديل مستخدم")
            {
                login.update_users(txtid.Text, txtpasw.Text, comboBox1.Text, txtfullname.Text);
                MessageBox.Show("تم التعديل ", "التعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtconpasw_Validated(object sender, EventArgs e)
        {
            //الحدث دة بيحصل لما بيكب ف التيكست بوكس ويمشى اول لما يدوس على اى حاجة تانى
            if(txtconpasw.Text!=txtpasw.Text)
            {
                MessageBox.Show("كلمات المرور غير متطابقة", "الاضافة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //ماينفعش اعمل زى ما عملت قبل كدة انى احدد التيكست اللى ف التيكست بوكسلما يدخل باس غلط 
                //علشان افرض هو غلط وهو بيدخل الباس الاصلى فلازم يكتب الباس الاصلى اللى هو غلط فية علشان يخرج 
            }
        }
    }
}
