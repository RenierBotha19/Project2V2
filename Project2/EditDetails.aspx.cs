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
    public partial class EditDetails : System.Web.UI.Page
    {
        public SqlConnection conn;
        public SqlCommand com;
        public DataSet ds;
        public SqlDataAdapter adapt;
        public SqlDataReader dataRead;
        public DataTable dt;
        public string state;

        private void Test(string myState, string sql, string details)
        {
            string thisCon = Session["MyDB"].ToString();
            int userid = int.Parse(Session["UserID"].ToString());

            conn = new SqlConnection(thisCon);
            conn.Open();
            adapt = new SqlDataAdapter(myState, conn);
            dt = new DataTable();
            adapt.Fill(dt);


            if (dt.Rows[0][0].ToString() == "1")
            {
                lblDisplay.ForeColor = System.Drawing.Color.Red;
                lblDisplay.Text = "Entered data already exists";
                txtEnter.Text = "";
                txtConf.Text = "";
            }
            else
            {
                com = new SqlCommand(sql, conn);
                com.Parameters.AddWithValue("@details", details);
                com.Parameters.AddWithValue("@userid", userid);
                com.ExecuteNonQuery();

                lblDisplay.ForeColor = System.Drawing.Color.Blue;
                lblDisplay.Text = "Successfully updated";
                txtEnter.Text = "";
                txtConf.Text = "";
                conn.Close();
            }
        }

        private void Selection(string text1, string text2)
        {
            lblEnter.Visible = true;
            lblEnter.Text = text1;
            lblConfirm.Visible = true;
            lblConfirm.Text = text2;
            txtEnter.Visible = true;
            txtConf.Visible = true;
            btnUpdate.Visible = true;
            lblDisplay.Visible = true;
            RequiredFieldValidator1.Visible = true;
            RequiredFieldValidator1.Enabled = true;
            CompareValidator1.Visible = true;
            CompareValidator1.Enabled = true;
            txtEnter.Text = "";
            txtConf.Text = "";
        }

        protected void radEmail_CheckedChanged(object sender, EventArgs e)
        {
            if(this.radEmail.Checked)
            {
                RegularExpressionValidator1.Visible = true;
                RegularExpressionValidator1.Enabled = true;
                txtEnter.TextMode = TextBoxMode.SingleLine;
                txtConf.TextMode = TextBoxMode.SingleLine;
                Selection("Please enter your new email", "Please confirm your new email");
            }
            else if (this.RadCell.Checked)
            {
                RegularExpressionValidator1.Visible = false;
                RegularExpressionValidator1.Enabled = false;
                txtEnter.TextMode = TextBoxMode.SingleLine;
                txtConf.TextMode = TextBoxMode.SingleLine;
                Selection("Please enter your new cellphone number", "Please confirm your new cellphone number");
            }
            else if (this.radPassword.Checked)
            {
                txtEnter.TextMode = TextBoxMode.Password;
                txtConf.TextMode = TextBoxMode.Password;
                RegularExpressionValidator1.Visible = false;
                RegularExpressionValidator1.Enabled = false;
                Selection("Please enter your new password", "Please confirm your new password");
            }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string details = txtConf.Text;

            if (radEmail.Checked)
            {
                Test("SELECT Count(*) FROM Users WHERE Email = '" + details + "'", "Update Users SET Email = @details WHERE UserID = @userid", details);
            }
            else if(RadCell.Checked)
            {
                int tesv;
                if (details.Length != 10)
                {
                    lblDisplay.ForeColor = System.Drawing.Color.Red;
                    lblDisplay.Text = "Incorrect length, please try again";
                    txtEnter.Text = "";
                    txtConf.Text = "";
                } else if (int.TryParse(details, out tesv) == false)
                {
                    lblDisplay.ForeColor = System.Drawing.Color.Red;
                    lblDisplay.Text = "Please enter a valid cellphone number";
                    txtEnter.Text = "";
                    txtConf.Text = "";
                }
                else
                {
                    Test("SELECT Count(*) FROM Users WHERE CellNr = '" + details + "'", "Update Users SET CellNr = @details WHERE UserID = @userid", details);
                }
            }
            else if(radPassword.Checked)
            {
                if (details.Length < 8)
                {
                    lblDisplay.ForeColor = System.Drawing.Color.Red;
                    lblDisplay.Text = "Password to short, please try again";
                    txtEnter.Text = "";
                    txtConf.Text = "";
                }
                else
                {
                    Test("SELECT Count(*) FROM Users WHERE Password = '" + details + "'", "Update Users SET Password = @details WHERE UserID = @userid", details);
                }
            }
        }
    }
}