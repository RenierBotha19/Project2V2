﻿using System;
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

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "";
            string name = txtName.Text;
            string surname = txtSurname.Text;
            string email = txtEmail.Text;
            string cell = txtCell.Text;
            string pw = txtCon.Text;
            int id = 0;
            int tesv = 0;
            bool validNum = false;

            string myState = "SELECT Count(*) FROM Users WHERE Name = '" + name + "'and Surname = '" + surname + "'and Email = '" + email + "'and CellNr = '" + cell + "'and ID ='" + ID + "'";
            string myPW = "SELECT * FROM Users";
            string insert = "INSERT INTO Users VALUES (@UserId,@Name,@Surname,@Email,@Password,@CellNr,@ID)";

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

                        con.Open();
                        com = new SqlCommand(insert, con);
                        com.Parameters.AddWithValue("@UserId", id);
                        com.Parameters.AddWithValue("@Name", name);
                        com.Parameters.AddWithValue("@Surname", surname);
                        com.Parameters.AddWithValue("@Email", email);
                        com.Parameters.AddWithValue("@Password", pw);
                        com.Parameters.AddWithValue("@CellNr", cell);
                        com.Parameters.AddWithValue("@ID", id);
                        com.ExecuteNonQuery();
                        con.Close(); // The user gets added into the database

                        lblDisplay.ForeColor = System.Drawing.Color.Blue;
                        Session["MyDB"] = id.ToString();
                        lblDisplay.Text = "Welcome " + name + " " + surname;
                        btnProceed.Enabled = true;
                    }
                }
            }
        }
    }
}