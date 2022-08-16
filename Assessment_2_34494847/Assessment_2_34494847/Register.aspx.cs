using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Assessment_2_34494847
{
    //Marcello Bezuidenhout 34494847
    public partial class _default : System.Web.UI.Page
    {
        //Global variables
        SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C: \Users\marce\Desktop\2021 Uni\Sem 1\CMPG212\Assessment_2_34494847\Assessment_2_34494847\Assessment_2_34494847\App_Data\myDB.mdf;Integrated Security=True");
        SqlCommand sqlCom;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            //Simple exception handling
            try
            {
                sqlCon.Open();

                string insertData = "INSERT INTO myData(Username, Password) VALUES(@user, @pass)";
                sqlCom = new SqlCommand(insertData, sqlCon);

                sqlCom.Parameters.AddWithValue("@user", tbUsername.Text);
                sqlCom.Parameters.AddWithValue("@pass", tbPassword.Text);
                sqlCom.ExecuteNonQuery();

                sqlCon.Close();
                Response.Redirect("Login.aspx");
            }
            catch(SqlException sqlE)
            {
                lblError.Text = sqlE.ToString();
            }
        }
    }
}