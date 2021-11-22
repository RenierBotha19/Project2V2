using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Dynamic;

namespace Project2
{
    public partial class View : System.Web.UI.Page
    {
        public SqlConnection con;
        public SqlCommand com;
        public SqlDataAdapter adapt;
        public DataTable dt;
        public SqlDataReader datRead;
        public DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {
            int UserId = int.Parse(Session["UserID"].ToString());
            myGrid.PageIndex = 0;
            con = new SqlConnection(Session["MyDB"].ToString());
            con.Open();
            ds = new DataSet();
            adapt = new SqlDataAdapter();
            com = new SqlCommand("Select Pics.PicID, Pics.CapturedDate, Pics.CapturedBy, Pics.PicName, Shared.GeoLocation, Shared.Tags FROM Pics Inner JOIN Shared on Pics.PicID = Shared.PicID WHERE Pics.UserId = '" + UserId + "'", con);
            adapt.SelectCommand = com;
            adapt.Fill(ds);

            myGrid.DataSource = ds;
            myGrid.DataBind();
            con.Close();
        }

        protected void btnproceed_Click(object sender, EventArgs e)
        {
            string GeoLocation = txtLocation.Text;
            string Tags = txtTag.Text;
            int PicID = int.Parse(Session["PicID"].ToString());
            string upd = "Update Shared SET GeoLocation = @GeoLocation, Tags = @Tags Where PicID = @PicID";
            con.Open();
            com = new SqlCommand(upd, con);
            com.Parameters.AddWithValue("@GeoLocation", GeoLocation);
            com.Parameters.AddWithValue("@Tags", Tags);
            com.Parameters.AddWithValue("@PicID", PicID);
            com.ExecuteNonQuery();
            con.Close();

            lblDisplay.Text = "Update successful";

            int UserId = int.Parse(Session["UserID"].ToString());
            myGrid.PageIndex = 0;
            con = new SqlConnection(Session["MyDB"].ToString());
            con.Open();
            ds = new DataSet();
            adapt = new SqlDataAdapter();
            com = new SqlCommand("Select Pics.PicID, Pics.CapturedDate, Pics.CapturedBy, Pics.PicName, Shared.GeoLocation, Shared.Tags FROM Pics Inner JOIN Shared on Pics.PicID = Shared.PicID WHERE Pics.UserId = '" + UserId + "'", con);
            adapt.SelectCommand = com;
            adapt.Fill(ds);

            myGrid.DataSource = ds;
            myGrid.DataBind();
            con.Close();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string state;
            int PicId;
            if (txtID.Text != "0" || txtID.Text != null)
            {
                PicId = int.Parse(txtID.Text);
                state = "SELECT COUNT(*) FROM Pics WHERE PicID ='" + PicId + "'";

                con.Open();
                adapt = new SqlDataAdapter(state, con);
                dt = new DataTable();
                adapt.Fill(dt);

                if (dt.Rows[0][0].ToString() == "1") // If ID is valid 
                {
                    con.Close();

                    PicId = int.Parse(txtID.Text);
                    state = "SELECT COUNT(*) FROM Shared WHERE PicID ='" + PicId + "'";

                    con.Open();
                    adapt = new SqlDataAdapter(state, con);
                    dt = new DataTable();
                    adapt.Fill(dt);

                    if (dt.Rows[0][0].ToString() == "1") // If ID is valid 
                    {
                        con.Close();
                        con.Open();
                        state = "DELETE FROM Shared Where PicId = '" + txtID.Text + "' ";
                        com = new SqlCommand(state, con);
                        com.ExecuteNonQuery(); // ID has been deleted
                        con.Close();

                        con.Open();
                        state = "DELETE FROM Pics Where PicId = '" + txtID.Text + "' ";
                        com = new SqlCommand(state, con);
                        com.ExecuteNonQuery(); // ID has been deleted
                        con.Close();
                        lblDisplay.Text = "Picture Deleted";

                        int UserId = int.Parse(Session["UserID"].ToString());
                        myGrid.PageIndex = 0;
                        con = new SqlConnection(Session["MyDB"].ToString());
                        con.Open();
                        ds = new DataSet();
                        adapt = new SqlDataAdapter();
                        com = new SqlCommand("Select Pics.PicID, Pics.CapturedDate, Pics.CapturedBy, Pics.PicName, Shared.GeoLocation, Shared.Tags FROM Pics Inner JOIN Shared on Pics.PicID = Shared.PicID WHERE Pics.UserId = '" + UserId + "'", con);
                        adapt.SelectCommand = com;
                        adapt.Fill(ds);

                        myGrid.DataSource = ds;
                        myGrid.DataBind();
                        con.Close();
                    }
                    else
                    {
                        con.Close();
                        con.Open();
                        state = "DELETE FROM Pics Where PicId = '" + txtID.Text + "' ";
                        com = new SqlCommand(state, con);
                        com.ExecuteNonQuery(); // ID has been deleted
                        con.Close();
                        lblDisplay.Text = "Picture Deleted";

                        int UserId = int.Parse(Session["UserID"].ToString());
                        myGrid.PageIndex = 0;
                        con = new SqlConnection(Session["MyDB"].ToString());
                        con.Open();
                        ds = new DataSet();
                        adapt = new SqlDataAdapter();
                        com = new SqlCommand("Select Pics.PicID, Pics.CapturedDate, Pics.CapturedBy, Pics.PicName, Shared.GeoLocation, Shared.Tags FROM Pics Inner JOIN Shared on Pics.PicID = Shared.PicID WHERE Pics.UserId = '" + UserId + "'", con);
                        adapt.SelectCommand = com;
                        adapt.Fill(ds);

                        myGrid.DataSource = ds;
                        myGrid.DataBind();
                        con.Close();
                    }
                }
                else
                {
                    lblDisplay.Text = "Picture does not exist";
                }
                con.Close();
            }
            else
            {
                lblDisplay.Text = "Please enter a Valid PictureID";
            }
        }

        protected void btnSelect_Click1(object sender, EventArgs e)
        {
            string state;
            int PicId;
            if (txtID.Text != "0" || txtID.Text != null)
            {
                PicId = int.Parse(txtID.Text);
                state = "SELECT COUNT(*) FROM Pics WHERE PicID ='" + PicId + "'";

                con.Open();
                adapt = new SqlDataAdapter(state, con);
                dt = new DataTable();
                adapt.Fill(dt);

                if (dt.Rows[0][0].ToString() == "1") // If ID is valid 
                {
                    lblGeo.Visible = true;
                    lblTag.Visible = true;
                    txtLocation.Visible = true;
                    txtTag.Visible = true;
                    btnproceed.Visible = true;
                    Image1.Visible = true;
                    con.Close();

                    string Name;
                    con.Open();
                    com = new SqlCommand("SELECT PicName FROM Pics WHERE PicID ='" + PicId + "'", con);
                    SqlDataReader read = com.ExecuteReader();
                    read.Read();
                    Session["PicID"] = PicId;
                    Name = (read.GetString(0));
                    con.Close();

                    //Image1.ImageUrl = File.ReadAllText(Name);/////////////////////////////////////////////////////
                }
                else
                {
                    lblDisplay.Text = "Picture does not exist";
                }
                con.Close();
            }
            else
            {
                lblDisplay.Text = "Please enter a Valid PictureID";
            }
        }
    }
}