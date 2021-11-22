using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Project2
{
    public partial class Main : System.Web.UI.Page
    {
        public SqlConnection conn;
        public SqlDataAdapter adapt;
        public DataTable dt;
        public SqlCommand com;

        protected void Page_Load(object sender, EventArgs e)
        {
            int UserId = int.Parse(Session["UserID"].ToString());
            string Name;

            conn = new SqlConnection(Session["MyDB"].ToString());
            conn.Open();
            com = new SqlCommand("SELECT Name, Surname FROM Users WHERE UserID='" + UserId + "'", conn);
            SqlDataReader read = com.ExecuteReader();
            read.Read();
            Name = (read.GetString(0)) + " " + (read.GetString(1));
            conn.Close();

            lblHeading.Text = Name + ", Please select where you would like to navigate";// Custom Heading

        }

        protected void radEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radEdit.Checked)
                Response.Redirect("EditDetails.aspx");
            else if (this.radUpload.Checked)
                Response.Redirect("Upload.aspx");
            else if (this.radView.Checked)
                Response.Redirect("View.aspx");
            else if (this.radShare.Checked)
                Response.Redirect("Shared.aspx");
            else if (this.radLogout.Checked)
                Response.Redirect("default.aspx");
        }
    }
}