using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace WindowsFormsApplication1.BL
{
    class CLS_PRODUCT
    {
        public DataTable Select_Category()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            //مش لازم افتح الكونكشن الداتا ادابتر يتكفل بفتح واغلاق الاتصال
            dt = DAL.selectdata("GET_CATEGORIES", null);
            return dt;
        }
        //يمكن استخدام الصور عن طريق تخزين مسارها ف الداتا بيز 
        //ولكن الافضل تخزينها على شكل ثنائى فهكذا انت تخزن الصورة كاملة على الداتا بيز 
        public void add_product (int ID_CAT ,string ID_Product ,string  Lable ,
                                                    int Qte ,string Price ,byte[] image)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.openconnection();//لازم علشان مافيش داتا ادابتر
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@ID_CAT",SqlDbType.Int);
            param[0].Value = ID_CAT;

            param[1] = new SqlParameter("@ID_Product", SqlDbType.VarChar,30);
            param[1].Value = ID_Product;

            param[2] = new SqlParameter("@Lable", SqlDbType.VarChar,30);
            param[2].Value = Lable;

            param[3] = new SqlParameter("@Qte", SqlDbType.Int);
            param[3].Value = Qte;

            param[4] = new SqlParameter("@Price", SqlDbType.VarChar,50);
            param[4].Value = Price;

            param[5] = new SqlParameter("@Image", SqlDbType.Image);
            param[5].Value = image;
            DAL.Executecommand("add_product", param);
            DAL.closeconnection();
        }
        public DataTable verifyproductid(string ID)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID_Product", SqlDbType.VarChar, 50);
            param[0].Value = ID;
            dt=DAL.selectdata("verifyproductid", param);
            return dt;
        }
        public DataTable getallproducts()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            //شيلنا الصورة من الاجراء علشان مش هتظهر كاملة ف الداتا جريد فيو وهنظهرها لوحدها ف نافذة اخرى
            dt = DAL.selectdata("getallproducts", null);
            return dt;
        }
        public DataTable searchproduct(string search)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@search", SqlDbType.VarChar, 50);
            param[0].Value = search;
            dt = DAL.selectdata("searchproductid", param);
            return dt;
        }
        public void deleteproduct(string ID)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.openconnection();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            param[0].Value = ID;
            DAL.Executecommand("deleteproduct", param);
            DAL.closeconnection();
        }
        public DataTable grt_image_product(string search)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            param[0].Value = search;
            dt = DAL.selectdata("grt_image_product", param);
            return dt;
        }
        public void update_product(int ID_CAT, string ID_Product, string Lable,
                                                    int Qte, string Price, byte[] image)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.openconnection();//لازم علشان مافيش داتا ادابتر
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@ID_CAT", SqlDbType.Int);
            param[0].Value = ID_CAT;

            param[1] = new SqlParameter("@ID_Product", SqlDbType.VarChar, 30);
            param[1].Value = ID_Product;

            param[2] = new SqlParameter("@Lable", SqlDbType.VarChar, 30);
            param[2].Value = Lable;

            param[3] = new SqlParameter("@Qte", SqlDbType.Int);
            param[3].Value = Qte;

            param[4] = new SqlParameter("@Price", SqlDbType.VarChar, 50);
            param[4].Value = Price;

            param[5] = new SqlParameter("@Image", SqlDbType.Image);
            param[5].Value = image;
            DAL.Executecommand("update_product", param);
            DAL.closeconnection();
        }
    }
}
