using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Assessment_2_34494847
{
    //Marcello Bezuidenhout 34494847
    public partial class WebForm1 : System.Web.UI.Page
    {
        //Global variables
        SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C: \Users\marce\Desktop\2021 Uni\Sem 1\CMPG212\Assessment_2_34494847\Assessment_2_34494847\Assessment_2_34494847\App_Data\myDB.mdf;Integrated Security=True");
        SqlCommand sqlCom;

        //Methods to remove code redundancy, also its a good programming technique
        //setLanguage method is used at the radio buttons selection so that I dont have to type all of this over and over
        private void setLanguage(bool Java, bool CSharp, bool CPP)
        {
            HttpCookie retreive = Request.Cookies["User"];
            string update = "UPDATE myData SET Java=@lang1,CSharp=@lang2,CPP=@lang3 WHERE Username = '" + retreive["username"] + "'";

            sqlCon.Open();

            sqlCom = new SqlCommand(update, sqlCon);
            sqlCom.Parameters.AddWithValue("@lang1", Java);
            sqlCom.Parameters.AddWithValue("@lang2", CSharp);
            sqlCom.Parameters.AddWithValue("@lang3", CPP);
            sqlCom.ExecuteNonQuery();

            sqlCon.Close();
            //Response.Redirect("Workshop.aspx");
        }

        //displayDatabase method is declared for code redundancy reasons aswell
        private void displayDatabase()
        {
            HttpCookie retreive = Request.Cookies["user"];
            string dispdata = "SELECT Username, WorkshopDate, Java, CSharp, CPP FROM myData WHERE Username = '" + retreive["username"] + "'";

            sqlCon.Open();

            sqlCom = new SqlCommand(dispdata, sqlCon);
            SqlDataAdapter DA = new SqlDataAdapter();
            DataSet DS = new DataSet();

            DA.SelectCommand = sqlCom;
            DA.Fill(DS);

            gvData.DataSource = DS;
            gvData.DataBind();

            sqlCon.Close();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Here I test that the user that is logged in is indeed a authorized user
            HttpCookie retreive = Request.Cookies["user"];
            sqlCon.Open();
                     
            string scanData = "SELECT * FROM myData";
            sqlCom = new SqlCommand(scanData, sqlCon);
            SqlDataReader scan = sqlCom.ExecuteReader();

            //So I scan through the database and use a flag because...
            //if you immediately have a condition to go back to login the page, every row where the user is not matched, it will return to the login page
            //hence I use a flag to test the match after this loop
            bool flag = true;
            while(scan.Read())
            {
                if (scan.GetValue(0).ToString() == retreive["username"])
                {
                    Label1.Text = "Welcome " + retreive["username"] + "!";               
                    break;
                } 
                else if(scan.GetValue(0).ToString() != retreive["username"])
                {
                    flag = false;
                }
            }         
            if(flag == false) //test the match
            {
                Response.Redirect("Login.aspx");
            }
            sqlCon.Close();
            displayDatabase(); 
        }

        protected void btnCon_Click(object sender, EventArgs e)
        {
            //Retreiving the selected date and the active user
            HttpCookie retreive = Request.Cookies["user"];           
            DateTime sel = calPref.SelectedDate;

            sqlCon.Open();

            //Then I update the activer user's date with the selected date
            string update = "UPDATE myData SET WorkshopDate = @date WHERE Username = '" + retreive["username"] + "'";
            sqlCom = new SqlCommand(update, sqlCon);
            sqlCom.Parameters.AddWithValue("@date", sel);
            sqlCom.ExecuteNonQuery();
           
            sqlCon.Close();
            displayDatabase();
        }

        protected void rbJava_CheckedChanged(object sender, EventArgs e)
        {
            //Here the user selects the preferred programming language
            //Also here you see the methods come into play to remove code redundancies
            //I used descriptive method names so anyone can understand it easily
            if (rbJava.Checked)
            {
                setLanguage(true, false, false);
                displayDatabase();
            }
            else if(rbCSharp.Checked)
            {
                setLanguage(false, true, false);
                displayDatabase();
            }
            else if (rbCPP.Checked)
            {
                setLanguage(false, false, true);
                displayDatabase();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //When someone logsout, it means they dont want to be remembered anymore
            //So I request the active users temporary cookie to change if the person wants to be remembered
            HttpCookie rem = Request.Cookies["tempUser"];
            //Then I set it to 0 which means the user does not want to be remembered because the person logged out
            rem["remember"] = "0";
            //Then I update it
            Response.Cookies.Add(rem);
            //And redirect the user back to the login page
            Response.Redirect("Login.aspx");
        }
    }
}