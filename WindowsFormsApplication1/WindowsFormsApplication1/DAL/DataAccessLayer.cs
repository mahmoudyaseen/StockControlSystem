using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;             //
using System.Data.SqlClient;            //
namespace WindowsFormsApplication1.DAL
{
    class DataAccessLayer
    {
        SqlConnection sqlconnection;
        //constractor المشيد انا اللى عاملة 
        public DataAccessLayer()
        {
            if (Properties.Settings.Default.mode == "Windows")
            {
                sqlconnection = new SqlConnection(@"Server=" + Properties.Settings.Default.server + ";DataBase=" + Properties.Settings.Default.database + ";Integrated Security=True");
            }
            else
            {
                sqlconnection = new SqlConnection(@"Server=" + Properties.Settings.Default.server + ";DataBase=" + Properties.Settings.Default.database + ";Integrated Security=false; user ID="+Properties.Settings.Default.id+"; password="+Properties.Settings.Default.password+"");
                //مش عارف لية حطينا ف الاخر""
            }
        }
        //method to open connection
        public void openconnection()
        {
            if(sqlconnection.State!=ConnectionState.Open)
            {
                sqlconnection.Open();
            }
        }
        //method to ckose connection
        public void closeconnection()
        {
            if(sqlconnection.State==ConnectionState.Open)
            {
                sqlconnection.Close();
            }
        }
        //method to read data
        //نوع الفانكشن داتا تيبول علشان هرجع جداول 
        //الفانكشن هتاخد 2 باراميتر 
        //الاول اسم الاجراء المجزن 
        //التانى ليست من الباراميترات الخاصة بالاجراء المخزن عملناها ليت علشان 
        //الاجراء المخزن ممكن يكون بيستقبل باراميتر واحد او مجموعة او لايستقبل باراميترات
        public DataTable selectdata(string Stored_Procedure, SqlParameter[] param)
        {
            //الاجراء المجزن يستلزم سكل كوماند
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = Stored_Procedure;
            sqlcmd.Connection = sqlconnection;
            //هنضيف لباراميترات 
            if (param !=null)//هنتاكد ان الليست فيها باراميترات علشان ممكن يكون الاجراء المجزن ما بياخدش باراميترات وانا باعت الليست فاضية
            {
                for (int i = 0; i < param.Length;i++ )
                {
                    sqlcmd.Parameters.Add(param[i]);//كان ممكن استغنى عن اللوب واكتب ادرينج
                }
            }
            //هنحط الناتج ف داتا تيبول يبقى لازم داتا ادابتر
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);//الداتا ادابتر يتكفل بفتح واغلاق الاتصال
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        //method to add,remove,update data from database
        public void Executecommand (string Stored_Procedure,SqlParameter []param)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = Stored_Procedure;
            sqlcmd.Connection = sqlconnection;
            if (param!=null)
            {
                sqlcmd.Parameters.AddRange(param);
            }
            sqlcmd.ExecuteNonQuery();//to add,remove,update
        }
    }
}
