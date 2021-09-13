using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhoneBook2
{
    public partial class phonebook : System.Web.UI.Page
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-4UI6O37\SQL2014EXPRESS;Initial Catalog=PhoneBook2;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btn_delete.Enabled = false;
                FillGridView();
            }
        }

        protected void btn_clear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        public void Clear()
        {
            hfp_id.Value = "";
            text_p_number.Text = text_p_name.Text = text_p_gmail.Text = text_p_address.Text = "";
            lblSuccessMessage.Text = lblErrorMessage.Text = "";
            btn_save.Text = "Save";
            btn_delete.Enabled = false;
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlCommand sqlCmd = new SqlCommand("contactCreateOrUpdate", sqlcon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@p_id", (hfp_id.Value == "" ? 0 : Convert.ToInt32(hfp_id.Value)));
            sqlCmd.Parameters.AddWithValue("@p_number", text_p_number.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@p_name", text_p_name.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@p_gmail", text_p_gmail.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@p_address", text_p_address.Text.Trim());
            sqlCmd.ExecuteNonQuery();
            sqlcon.Close();
            string p_id = hfp_id.Value;
            Clear();
            if (p_id == "")
                lblSuccessMessage.Text = "Saved Successfully";
            else
                lblErrorMessage.Text = "Updated Sucessfully";
            FillGridView();
        }


        void FillGridView()
        {
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("contactViewAll", sqlcon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlcon.Close();
            gv_contact.DataSource = dtbl;
            gv_contact.DataBind();
        }

        protected void lnk_Onclick(object sender, EventArgs e)
        {
            int p_id = Convert.ToInt32((sender as LinkButton).CommandArgument);
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("contactViewByID", sqlcon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@p_id", p_id);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlcon.Close();
            hfp_id.Value = p_id.ToString();
            text_p_number.Text = dtbl.Rows[0]["p_number"].ToString();
            text_p_name.Text = dtbl.Rows[0]["p_name"].ToString();
            text_p_gmail.Text = dtbl.Rows[0]["p_gmail"].ToString();
            text_p_address.Text = dtbl.Rows[0]["p_address"].ToString();
            btn_save.Text = "Update";
            btn_delete.Enabled = true;

        }

        protected void btn_delete_Click(object sender, EventArgs e)
        {
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlCommand sqlCmd = new SqlCommand("contactDeleteByID", sqlcon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@p_id", Convert.ToInt32(hfp_id.Value));
            sqlCmd.ExecuteNonQuery();
            sqlcon.Close();
            FillGridView();
            lblSuccessMessage.Text = "Deleted Successfully";
        }

        protected void btn_delete_Click_all(object sender, EventArgs e)
        {
            

            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlCommand sqlCmd = new SqlCommand("contactDeleteAllData", sqlcon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
    
            sqlCmd.ExecuteNonQuery();
            sqlcon.Close();
            FillGridView();
            lblSuccessMessage.Text = "Deleted Successfully";

        }
    }
    }