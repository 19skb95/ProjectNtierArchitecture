using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebClient
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        BusinessLogicLayer.BusinessLogicClass baObj = new BusinessLogicLayer.BusinessLogicClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtID.Text = (baObj.BindId()+1).ToString();

        }

        protected void btnInsrt_Click(object sender, EventArgs e)
        {
            BusinessEntityLayer.BusinessEntityClass obj = new BusinessEntityLayer.BusinessEntityClass();
            obj.firstName = txtFN.Text;
            obj.lastname = txtln.Text;
            obj.phone = txtPh.Text;
            obj.email = txtemail.Text;
            baObj.Insert(obj);
            Response.Write("Record Inserted.");
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView1.Rows[index];
            txtID.Text = row.Cells[0].Text;
            txtFN.Text = row.Cells[1].Text;
            txtln.Text = row.Cells[2].Text;
            txtemail.Text= row.Cells[3].Text.ToUpper();
            txtPh.Text = row.Cells[4].Text;
           
           

        }
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            BusinessEntityLayer.BusinessEntityClass obj = new BusinessEntityLayer.BusinessEntityClass();
            obj.id = Convert.ToInt32(txtID.Text);
            obj.firstName = txtFN.Text;
            obj.lastname = txtln.Text;
            obj.phone = txtPh.Text;
            obj.email = txtemail.Text;
            baObj.Update(obj);
            Response.Write("Record Updated.");
        }

        protected void BtnDlete_Click(object sender, EventArgs e)
        {
            baObj.Delete(Convert.ToInt32(txtID.Text));
            Response.Write("Record Deleted.");
        }

        protected void BindList_Click(object sender, EventArgs e)
        {
           GridView1.DataSource= baObj.GetList();
            GridView1.DataBind();
            GridView1.Visible = true;
        }

        protected void find_Click(object sender, EventArgs e)
        {
            DataRow currentRow = baObj.FindName(txtln.Text);
            txtID.Text = currentRow["address_id"].ToString();
            txtFN.Text = currentRow["firstName"].ToString();
            txtln.Text = currentRow["lastname"].ToString();
            txtemail.Text = currentRow["email"].ToString();
            txtPh.Text = currentRow["phone"].ToString();
        }
    }
}