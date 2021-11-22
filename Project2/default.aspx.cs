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
    public partial class _default : System.Web.UI.Page
    {
        public SqlConnection conn;
        public SqlDataAdapter adapt;
        public DataTable dt;
        public SqlCommand com;

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
        }// Encrypting the password

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["MyDB"] = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Documents\IT2021\SEM2\CMPG323\Pro2\Project2\Project2\App_Data\MyDB.mdf;Integrated Security=True";// Local DB
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUn.Text;
            string pw = encrypt(txtPw.Text);
            string myAdt = "SELECT COUNT(*) FROM Users WHERE Email='" + user + "'and Password ='" + pw + "'";

            conn = new SqlConnection(Session["MyDB"].ToString());
            conn.Open();
            adapt = new SqlDataAdapter(myAdt, conn);
            dt = new DataTable();
            adapt.Fill(dt);

            if (dt.Rows[0][0].ToString() == "1") //The COUNT() int the SELECT statement gets a value 0/1 if value = 1 the login is correct
            {
                conn = new SqlConnection(Session["MyDB"].ToString());
                conn.Open();
                com = new SqlCommand("SELECT * FROM Users WHERE Email='" + user + "'and Password ='" + pw + "'", conn);
                SqlDataReader read = com.ExecuteReader();
                read.Read();
                Session["UserID"] = (read.GetInt32(0)).ToString(); // Assigns the UserID to the Session to be used later in the program
                conn.Close();

                Response.Redirect("Main.aspx");
            }
            else // If COUNT() = 0 the Username/Password is wrong
            {
                lblError.Text = "Username/Password incorrect please try again";
            }
            conn.Close();
        }
    }
}