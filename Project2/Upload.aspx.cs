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
    public partial class Upload : System.Web.UI.Page
    {
        public SqlConnection con;
        public SqlCommand com;
        public SqlDataAdapter adapt;
        public DataTable dt;
        public SqlDataReader datRead;
        public DataSet ds;
        public int id = 0;

        protected void Button1_Click(object sender, EventArgs e)
        {
            bool validNum = false;
            string myPW = "SELECT * FROM Pics";
            string insert = "INSERT INTO Pics VALUES (@PicID,@UserID,@CapturedDate,@CapturedBy,@PicName)";
            int UserId = int.Parse(Session["UserID"].ToString());
            string Name;
            string PicName;
            con = new SqlConnection(Session["MyDB"].ToString());
            con.Open();
            com = new SqlCommand("SELECT Name, Surname FROM Users WHERE UserID='" + UserId + "'", con);
            SqlDataReader read = com.ExecuteReader();
            read.Read();
            Name = (read.GetString(0)) + " " + (read.GetString(1));
            con.Close();
            Session["Rows"] = 0;

            if (FileUpload1.HasFile)
            {

                string ext = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
                string PhysicalPath = Server.MapPath("~/Data/");
                if (!Directory.Exists(PhysicalPath)) ;
                Directory.CreateDirectory(PhysicalPath);
                if (ext == ".bmp" || ext == ".ico" || ext == ".jpeg" || ext == ".jpg" || ext == ".gif" || ext == ".tiff" || ext == ".png")
                {
                    PicName = FileUpload1.FileName;
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
                    com.Parameters.AddWithValue("@PicID", id);
                    com.Parameters.AddWithValue("@UserID", UserId);
                    com.Parameters.AddWithValue("@CapturedDate", DateTime.Today.ToShortDateString());
                    com.Parameters.AddWithValue("@CapturedBy", Name);
                    com.Parameters.AddWithValue("@PicName", PicName);
                    com.ExecuteNonQuery();
                    con.Close();
                    Session["PicID"] = id;
                    foreach (HttpPostedFile file in FileUpload1.PostedFiles)
                    {
                        file.SaveAs(PhysicalPath + file.FileName);
                    }
                    lblDisplay.Text = "File uploaded successfully";
                    BtnUplaod.Enabled = false;
                    HyperLink1.Enabled = false;
                    radPvt.Visible = true;
                    radShare.Visible = true;
                }
                else
                {
                    lblDisplay.Text = "Format not supported";
                }
            }
            else
            {
                lblDisplay.Text = "Please upload a file";
            }
        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radShare.Checked)
            {
                lblGeo.Visible = true;
                lblTag.Visible = true;
                txtLocation.Visible = true;
                txtTag.Visible = true;
                myGrid.Visible = true;
                btnShare.Visible = true;
                int UserId = int.Parse(Session["UserID"].ToString());

                myGrid.Visible = false;
                myGrid.PageIndex = 0;
                con = new SqlConnection(Session["MyDB"].ToString());
                con.Open();
                ds = new DataSet();
                adapt = new SqlDataAdapter();
                com = new SqlCommand("Select Name, Surname, Email FROM Users Where NOT UserID = '" + UserId + "'", con);
                adapt.SelectCommand = com;
                adapt.Fill(ds);

                myGrid.DataSource = ds;
                myGrid.DataBind();
                con.Close();
                myGrid.Visible = true;
                Session["Rows"] = 0;
            }
            else if (this.radPvt.Checked)
            {

                myGrid.Visible = false;
                lblGeo.Visible = true;
                lblTag.Visible = true;
                txtLocation.Visible = true;
                txtTag.Visible = true;
                btnShare.Visible = true;
                btnShare.Enabled = true;
            }
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            int oldRow = int.Parse(Session["Rows"].ToString()); //Session gets assigned to a variable
            int rowind = ((GridViewRow)(sender as Control).NamingContainer).RowIndex; // rowind = number of selected textbox

            CheckBox cb = (CheckBox)myGrid.Rows[oldRow].FindControl("Checkbox1"); // Creates a "Independed checkbox"
            if (oldRow != rowind)
            {
                cb.Checked = false;  // if the oldRow does not = rowInd the oldRow checkbox gets unchecked
            }

            Session["Rows"] = rowind; // The new value is the selected rowindex
        }

        protected void btnShare_Click(object sender, EventArgs e)
        {
            if (radShare.Checked)
            {
                int picID = int.Parse(Session["PicID"].ToString()); // FotoID
                int rowind = int.Parse(Session["Rows"].ToString());// User
                string user = myGrid.Rows[rowind].Cells[3].Text;//User
                string geo = txtLocation.Text;
                string tag = txtTag.Text;
                int shareID;// user
                bool validNum = false;
                int NewId;

                con = new SqlConnection(Session["MyDB"].ToString());
                con.Open();
                com = new SqlCommand("SELECT UserID FROM Users WHERE Email ='" + user + "'", con);
                SqlDataReader read = com.ExecuteReader();
                read.Read();
                shareID = int.Parse(read.GetValue(0).ToString());
                con.Close();

                Random rand = new Random();
                con.Open();
                com = new SqlCommand("Select * from Shared", con);
                datRead = com.ExecuteReader();
                NewId = rand.Next(0, 1001);

                do
                {
                    while (datRead.Read())
                    {
                        if (NewId == (int)datRead.GetValue(0))
                        {
                            NewId = rand.Next(0, 1001);
                            break;
                        }
                        else
                            validNum = true;
                    }
                } while (validNum == false);
                con.Close();

                con.Open();
                com = new SqlCommand("INSERT INTO Shared VALUES (@RefId,@PicID,@GeoLocation,@Tags,@UserID)", con);
                com.Parameters.AddWithValue("@RefId", NewId);
                com.Parameters.AddWithValue("@PicID", picID);
                com.Parameters.AddWithValue("@GeoLocation", geo);
                com.Parameters.AddWithValue("@Tags", tag);
                com.Parameters.AddWithValue("@UserID", shareID);
                com.ExecuteNonQuery();
                con.Close();
                lblDisplay.Text = "Shared Succesfully";
                btnShare.Enabled = false;
                HyperLink1.Enabled = true;
                BtnUplaod.Enabled = true;
                txtLocation.Text = "";
                txtTag.Text = "";
                radPvt.Visible = false;
                radShare.Visible = false;
                lblGeo.Visible = false;
                lblTag.Visible = false;
                txtLocation.Visible = false;
                txtTag.Visible = false;
                myGrid.Visible = false;
                btnShare.Visible = false;
            }
            else if(radPvt.Checked)
            {
                int picID = int.Parse(Session["PicID"].ToString());
                string geo = txtLocation.Text;
                string tag = txtTag.Text;
                int shareID = int.Parse(Session["UserID"].ToString());
                bool validNum = false;
                int NewId;

                Random rand = new Random();
                con = new SqlConnection(Session["MyDB"].ToString());
                con.Open();
                com = new SqlCommand("Select * from Shared", con);
                datRead = com.ExecuteReader();
                NewId = rand.Next(0, 1001);

                do
                {
                    while (datRead.Read())
                    {
                        if (NewId == (int)datRead.GetValue(0))
                        {
                            NewId = rand.Next(0, 1001);
                            break;
                        }
                        else
                            validNum = true;
                    }
                } while (validNum == false);
                con.Close();

                con.Open();
                com = new SqlCommand("INSERT INTO Shared VALUES (@RefId,@PicID,@GeoLocation,@Tags,@UserID)", con);
                com.Parameters.AddWithValue("@RefId", NewId);
                com.Parameters.AddWithValue("@PicID", picID);
                com.Parameters.AddWithValue("@GeoLocation", geo);
                com.Parameters.AddWithValue("@Tags", tag);
                com.Parameters.AddWithValue("@UserID", shareID);
                com.ExecuteNonQuery();
                con.Close();
                lblDisplay.Text = "Shared Succesfully";
                btnShare.Enabled = false;
                HyperLink1.Enabled = true;
                BtnUplaod.Enabled = true;
                txtLocation.Text = "";
                txtTag.Text = "";
                radPvt.Visible = false;
                radShare.Visible = false;
                lblGeo.Visible = false;
                lblTag.Visible = false;
                txtLocation.Visible = false;
                txtTag.Visible = false;
                myGrid.Visible = false;
                btnShare.Visible = false;
                BtnUplaod.Enabled = true;
            }
        }
    }
}