using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;             //
using System.Data.SqlClient;            //

namespace WindowsFormsApplication1.BL
{
    class CLS_LOGIN
    {
        public DataTable LOGIN (string ID,string PWD)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] Param = new SqlParameter[2];

            Param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            Param[0].Value = ID;

            Param[1] = new SqlParameter("@PWD", SqlDbType.VarChar, 50);
            Param[1].Value = PWD;
            //الداتا ادابتر يتكفل بفتح واغلاق الاتصال
            DataTable dt = new DataTable();
            dt=DAL.selectdata("SP_LOGIN", Param);
            return dt;
        }
        public void add_user(string ID, string PWD, string UserType,string fullname)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.openconnection();
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            param[0].Value = ID;

            param[1] = new SqlParameter("@PWD", SqlDbType.VarChar, 50);
            param[1].Value = PWD;

            param[2] = new SqlParameter("@UserType", SqlDbType.VarChar, 50);
            param[2].Value = UserType;

            param[3] = new SqlParameter("@fullname", SqlDbType.VarChar, 50);
            param[3].Value = fullname;

            DAL.Executecommand("add_user", param);
            DAL.closeconnection();
        }
        public DataTable get_users(string search)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@search", SqlDbType.VarChar, 50);
            param[0].Value = search;
            dt = DAL.selectdata("get_users", param);
            return dt;
        }
        public void update_users(string ID, string PWD, string UserType, string fullname)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.openconnection();
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            param[0].Value = ID;

            param[1] = new SqlParameter("@PWD", SqlDbType.VarChar, 50);
            param[1].Value = PWD;

            param[2] = new SqlParameter("@UserType", SqlDbType.VarChar, 50);
            param[2].Value = UserType;

            param[3] = new SqlParameter("@fullname", SqlDbType.VarChar, 50);
            param[3].Value = fullname;

            DAL.Executecommand("update_users", param);
            DAL.closeconnection();
        }
        public void delete_users(string ID)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.openconnection();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            param[0].Value = ID;
            DAL.Executecommand("delete_users", param);
            DAL.closeconnection();
        }
        public DataTable verify_user_ID(string ID)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            param[0].Value = ID;
            dt = DAL.selectdata("verify_user_ID", param);
            return dt;
        }

    }
}
