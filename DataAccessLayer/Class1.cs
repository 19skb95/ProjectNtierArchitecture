using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataAccessClass
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommandBuilder l;
        DataSet ds = new DataSet();
        int id;

        void FillDataSet()
        {
            con = GetConnection();
            da = new SqlDataAdapter("select * from tbl_ddressBook", con);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            l = new SqlCommandBuilder(da);
            da.Fill(ds);
        }
        public int Bindid()
        {
            using (con = GetConnection())
            {
                using (SqlCommand com = new SqlCommand("SELECT TOP 1 address_id FROM tbl_ddressBook ORDER BY firstName DESC ", con))
                {
                    con.Open();
                    id = (int)com.ExecuteScalar();
                    con.Close();

                }

                return id;
            }
        }
        SqlConnection GetConnection()
        {
            return (new SqlConnection(@"data source = DESKTOP-3LP5LOL\SQLEXPRESS; initial catalog = AddressBook_db; Integrated security = true;"));
        }
        //Return List
        public DataTable AddressBookList()
        {
            FillDataSet();

            DataTable dt = ds.Tables[0];
            return dt;
        }
        //insert
        public void Insert(BusinessEntityLayer.BusinessEntityClass obj)
        {
            FillDataSet();
            DataRow dr = ds.Tables[0].NewRow();

            dr["firstName"] = obj.firstName;
            dr["lastname"] = obj.lastname;
            dr["email"] = obj.email;

            dr["phone"] = obj.phone;

            ds.Tables[0].Rows.Add(dr);
            da.Update(ds);
        }

        //Update

        public void Update(BusinessEntityLayer.BusinessEntityClass obj)
        {
            FillDataSet();

            DataRow dr = ds.Tables[0].Rows.Find(obj.id);
            dr["firstName"] = obj.firstName;
            dr["lastname"] = obj.lastname;
            dr["email"] = obj.email;

            dr["phone"] = obj.phone;
            da.Update(ds);
        }
        //Delete

        public void Delete(int id)
        {
            FillDataSet();
            ds.Tables[0].Rows.Find(id).Delete();
            da.Update(ds);
        }
        //findName
        public DataRow FindName(string Name)
        {
            con = GetConnection();
            da = new SqlDataAdapter("select * from tbl_ddressBook", con);

            l = new SqlCommandBuilder(da);
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            DataTable tbl = dt;

            tbl.PrimaryKey = new DataColumn[] { tbl.Columns["lastname".ToLower()] };
            DataRow currentRow = tbl.Rows.Find(Name);
            ///if (currentRow != null)
            //{
            //    TxtId.Text = currentRow["address_id"].ToString();
            //    txtfn.Text = currentRow["firstName"].ToString();
            //    txtln.Text = currentRow["lastname"].ToString();
            //    emtxt.Text = currentRow["email"].ToString();
            //    txtph.Text = currentRow["phone"].ToString();

            //}

            return currentRow;
       

        }


    }
}
