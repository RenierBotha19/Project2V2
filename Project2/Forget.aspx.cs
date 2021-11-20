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
    public partial class Forget : System.Web.UI.Page
    {
        public SqlConnection con;
        public SqlCommand com;
        public DataSet ds;
        public SqlDataAdapter adapt;
        public DataTable dt;

        protected void btnRecover_Click(object sender, EventArgs e)
        {
            lblWrong.Text = "";

            string name = txtName.Text;
            string surname = txtSurname.Text;
            string email = txtEmail.Text;
            string cell = txtCell.Text;
            string ID = txtID.Text;

            string myState = "SELECT Count(*) FROM Users WHERE Name = '" + name + "'and Surname = '" + surname + "'and Email = '" + email + "'and CellNr = '" + cell + "'and ID ='" + ID + "'";
            string myState2 = "SELECT * FROM Users WHERE Name = '" + name + "'and Surname = '" + surname + "'and Email = '" + email + "'and CellNr = '" + cell + "'and ID ='" + ID + "'";

            con = new SqlConnection(Session["MyDB"].ToString());
            con.Open();
            adapt = new SqlDataAdapter(myState, con);
            dt = new DataTable();
            adapt.Fill(dt);
            con.Close();

            if (dt.Rows[0][0].ToString() == "1") // Validates if the input is correct
            {
                con = new SqlConnection(Session["MyDB"].ToString());
                con.Open();
                com = new SqlCommand(myState2, con);
                SqlDataReader read = com.ExecuteReader();
                read.Read();
                lblWrong.ForeColor = System.Drawing.Color.Blue;
                lblWrong.Text = name + ", your password is: " + read.GetString(4); // if the input is correct it will show the user password
                con.Close();
            }
            else
            {
                lblWrong.Text = "Try again/User not found"; // If the input is wrog this message will be displayed
            }

        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }
    }
}