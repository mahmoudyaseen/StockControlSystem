using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace WindowsFormsApplication1.BL
{
    class CLS_CUSTOERS
    {
        public void add_customer(string first_name,string last_name,string tel,string email,byte[]image_customer,string found)
        {
            DAL.DataAccessLayer cust = new DAL.DataAccessLayer();
            cust.openconnection();
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@first_name", SqlDbType.VarChar, 25);
            param[0].Value = first_name;
            param[1] = new SqlParameter("@last_name", SqlDbType.VarChar, 25);
            param[1].Value = last_name;
            param[2] = new SqlParameter("@tel", SqlDbType.NChar, 15);
            param[2].Value = tel;
            param[3] = new SqlParameter("@email", SqlDbType.VarChar, 25);
            param[3].Value = email;
            param[4] = new SqlParameter("@image_customer", SqlDbType.Image);
            param[4].Value = image_customer;
            param[5] = new SqlParameter("@found", SqlDbType.VarChar,50);
            param[5].Value = found;
            cust.Executecommand("add_customer", param);
            cust.closeconnection();
        }
        public DataTable get_all_custoners()
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            dt=dal.selectdata("get_all_custoners", null);
            return dt;
        }
        public void edit_customer(string first_name, string last_name, string tel, string email, byte[] image_customer, string found,int ID)
        {
            DAL.DataAccessLayer cust = new DAL.DataAccessLayer();
            cust.openconnection();
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@first_name", SqlDbType.VarChar, 25);
            param[0].Value = first_name;
            param[1] = new SqlParameter("@last_name", SqlDbType.VarChar, 25);
            param[1].Value = last_name;
            param[2] = new SqlParameter("@tel", SqlDbType.NChar, 15);
            param[2].Value = tel;
            param[3] = new SqlParameter("@email", SqlDbType.VarChar, 25);
            param[3].Value = email;
            param[4] = new SqlParameter("@image_customer", SqlDbType.Image);
            param[4].Value = image_customer;
            param[5] = new SqlParameter("@found", SqlDbType.VarChar, 50);
            param[5].Value = found;
            param[6] = new SqlParameter("@ID", SqlDbType.Int);
            param[6].Value = ID;
            cust.Executecommand("edit_customer", param);
            cust.closeconnection();
        }
        public void delete_customer(int ID)
        {
            DAL.DataAccessLayer cust = new DAL.DataAccessLayer();
            cust.openconnection();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.Int);
            param[0].Value = ID;
            cust.Executecommand("delete_customer", param);
            cust.closeconnection();
        }
        public DataTable search_customer(string search_word)
        {
            DAL.DataAccessLayer cust = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@search_word", SqlDbType.VarChar, 50);
            param[0].Value = search_word;
            dt= cust.selectdata("search_customer",param);
            return dt;
        }
    }
}
