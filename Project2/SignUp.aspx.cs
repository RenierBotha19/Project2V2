using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Xml;

namespace Project2
{
    public partial class SignUp : System.Web.UI.Page
    {
        public SqlConnection con;
        public SqlCommand com;
        public SqlDataAdapter adapt;
        public DataTable dt;
        public SqlDataReader datRead;

        private string encrypt(string str)
        {
            string _result = string.Empty;
            char[] temp = str.ToCharArray();
            foreach (var _singleChar in temp)
            {
                var i = (int)_singleChar;
                i = i - 2;
                _result += (char)i;
            }
            return _result;
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "";
            string name = txtName.Text;
            string surname = txtSurname.Text;
            string email = txtEmail.Text;
            string cell = txtCell.Text;
            string pw = txtCon.Text;
            string ident = txtID.Text;
            int id = 0;
            int tesv = 0;
            bool validNum = false;

            string myState = "SELECT Count(*) FROM Users WHERE Name = '" + name + "'and Surname = '" + surname + "'or Email = '" + email + "'or CellNr = '" + cell + "'or Ident ='" + ident + "'";
            string myPW = "SELECT * FROM Users";
            string insert = "INSERT INTO Users VALUES (@UserId,@Name,@Surname,@Email,@Password,@CellNr,@Ident)";

            con = new SqlConnection(Session["MyDB"].ToString());
            con.Open();
            adapt = new SqlDataAdapter(myState, con);
            dt = new DataTable();
            adapt.Fill(dt);
            con.Close();

            if (dt.Rows[0][0].ToString() == "1") // Validates if the date input already exists inside the database
            {
                lblDisplay.ForeColor = System.Drawing.Color.Red;
                lblDisplay.Text = "User already exists";

                txtName.Text = "";
                txtSurname.Text = "";
                txtEmail.Text = "";
                txtCell.Text = "";
                txtPassword.Text = "";
                txtCon.Text = "";
                txtID.Text = "";
            }
            else
            {
                if (pw.Length < 8) // Validates the length of the password
                {
                    lblDisplay.ForeColor = System.Drawing.Color.Red;
                    lblDisplay.Text = "Password to short";
                    txtPassword.Text = "";
                    txtCon.Text = "";
                }
                else
                {
                    if (int.TryParse(cell, out tesv) == false)
                    {
                        lblDisplay.ForeColor = System.Drawing.Color.Red;
                        lblDisplay.Text = "Please enter a valid cellphone number";
                        txtCell.Text = "";
                    }
                    else
                    {
                        Random rand = new Random();
                        con.Open();
                        com = new SqlCommand(myPW, con);
                        datRead = com.ExecuteReader();
                        id = rand.Next(0, 1001);

                        do
                        {
                            while (datRead.Read())
                            {
                                if (id == (int)datRead.GetValue(0))
                                {
                                    id = rand.Next(0, 1001);
                                    break;
                                }
                                else
                                    validNum = true;
                            }
                        } while (validNum == false);
                        con.Close();


                        string ePW = encrypt(pw);
                        con.Open();
                        com = new SqlCommand(insert, con);
                        com.Parameters.AddWithValue("@UserId", id);
                        com.Parameters.AddWithValue("@Name", name);
                        com.Parameters.AddWithValue("@Surname", surname);
                        com.Parameters.AddWithValue("@Email", email);
                        com.Parameters.AddWithValue("@Password", ePW);
                        com.Parameters.AddWithValue("@CellNr", cell);
                        com.Parameters.AddWithValue("@Ident", ident);
                        com.ExecuteNonQuery();
                        con.Close(); // The user gets added into the database

                        lblDisplay.ForeColor = System.Drawing.Color.Blue;
                        Session["UserID"] = id.ToString();
                        lblDisplay.Text = "Welcome, " + name + " " + surname;
                        HyperLink1.Visible = true;
                        HyperLink1.Enabled = true;
                        btnRegister.Visible = false;
                    }
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}