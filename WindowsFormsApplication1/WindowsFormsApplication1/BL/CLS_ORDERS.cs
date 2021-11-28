using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace WindowsFormsApplication1.BL
{
    class CLS_ORDERS
    {
        public DataTable get_the_next_order_id()
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            dt=dal.selectdata("get_the_next_order_id", null);
            return dt;
        }
        public void add_order(int ID_Order,DateTime Date_Order,int Customer_ID,string description_order,string salesman)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.openconnection();
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@ID_Order", SqlDbType.Int);
            param[0].Value = ID_Order;
            param[1] = new SqlParameter("@Date_Order", SqlDbType.DateTime);
            param[1].Value = Date_Order;
            param[2] = new SqlParameter("@Customer_ID", SqlDbType.Int);
            param[2].Value = Customer_ID;
            param[3] = new SqlParameter("@description_order", SqlDbType.VarChar,250);
            param[3].Value = description_order;
            param[4] = new SqlParameter("@salesman", SqlDbType.VarChar,75);
            param[4].Value = salesman;
            dal.Executecommand("add_order", param);
            dal.closeconnection();
        }
        public void add_order_details(string ID_Product, int ID_Order, int QTE, string price, double discount, string amount, string total_amount)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.openconnection();
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@ID_Product", SqlDbType.VarChar,30);
            param[0].Value = ID_Product;
            param[1] = new SqlParameter("@ID_Order", SqlDbType.Int);
            param[1].Value = ID_Order;
            param[2] = new SqlParameter("@QTE", SqlDbType.Int);
            param[2].Value = QTE;
            param[3] = new SqlParameter("@price", SqlDbType.VarChar, 50);
            param[3].Value = price;
            param[4] = new SqlParameter("@discount", SqlDbType.Float);
            param[4].Value = discount;
            param[5] = new SqlParameter("@amount", SqlDbType.VarChar, 50);
            param[5].Value = amount;
            param[6] = new SqlParameter("@total_amount", SqlDbType.VarChar, 50);
            param[6].Value = total_amount;
            dal.Executecommand("add_order_details", param);
            dal.closeconnection();
        }
        public DataTable verify_qut (string ID_Product,int Qte_In_Stock)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@ID_Product", SqlDbType.VarChar, 30);
            param[0].Value = ID_Product;
            param[1] = new SqlParameter("@Qte_In_Stock", SqlDbType.Int);
            param[1].Value = Qte_In_Stock;
            return(dal.selectdata("verify_qut", param));
        }
        public DataTable get_the_order_id_to_print()
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            return (dal.selectdata("get_the_order_id_to print", null));
        }
        public DataTable get_order_details(int ID_order)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID_order", SqlDbType.VarChar, 30);
            param[0].Value = ID_order;
            return (dal.selectdata("get_order_details", param));
        }
        public DataTable get_orders(string search)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@search", SqlDbType.VarChar, 30);
            param[0].Value = search;
            return (dal.selectdata("get_orders", param));
        }
    }
}
