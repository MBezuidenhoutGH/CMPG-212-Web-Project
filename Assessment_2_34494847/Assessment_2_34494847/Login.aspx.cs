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
    public partial class Login : System.Web.UI.Page
    {
        //Global variables
        SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\marce\Desktop\2021 Uni\Sem 1\CMPG212\Assessment_2_34494847\Assessment_2_34494847\Assessment_2_34494847\App_Data\myDB.mdf;Integrated Security=True");
        SqlCommand sqlCom;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Simple exception handling
            try
            {
                //Creating a receiver cookie referenced as "log", recalling the temperory cookie "tempUser" that is stored on the system
                HttpCookie log = Request.Cookies["tempUser"];

                //If a cookie was created named "tempUser" then the value will not be null,         
                /*if (log["remember"] != null)
                {
                    //Then I test if the value is 1, this means the user wanted to be rememberd but if its 0 then the user does not want to be remembered
                    if (log["remember"] == "1")
                    {
                        Response.Redirect("Workshop.aspx");
                    }
                }
                else
                {
                    //Incase there was not a cookie named "tempUser", in that case the value is null, refer to above, 
                    //then I just create the cookie the system is looking for and then
                    //set the "remember" value by default to 0 to prevent any errors
                    HttpCookie tempUser = new HttpCookie("tempUser");
                    tempUser["remember"] = "0";
                    Response.Cookies.Add(tempUser);
                }*/
            }
            catch
            {
                lblError.Text = "Something went wrong with loading the page, please contact technical support.";
            }
        }

        protected void btnLog_Click(object sender, EventArgs e)
        {
            sqlCon.Open();

            string flag = "";
            string find = "SELECT * FROM myData";
            sqlCom = new SqlCommand(find, sqlCon);
            //I use the sql reader object to scan through my database to see if the user is authorized to actually log into the system
            SqlDataReader scan = sqlCom.ExecuteReader();

            //I do this with a while loop so that it starts at the beginning and finish at the end without leaving anything out
            while (scan.Read())
            {
                //Here I test the value of columm 0 and 1 in my database because its the username and password columm, perspectively
                if ((scan.GetValue(0).ToString() == tbUsername.Text) && (scan.GetValue(1).ToString() == tbPassword.Text))
                {
                    //If the login credentials were found then I start creating my cookies
                    //I store the users name and password here to use on the workshop page
                    HttpCookie user = new HttpCookie("user");
                    user["username"] = tbUsername.Text;
                    user["password"] = tbPassword.Text;
                    Response.Cookies.Add(user);

                    //Here I created a temporary cookie for if the user wants to be remembered, 
                    //I created a seperate cookie so that I can do more complex testing in multiple pages without errors
                    HttpCookie tempUser = new HttpCookie("tempUser");         

                    if (cbRem.Checked == true)
                    {
                        tempUser["remember"] = "1";
                        tempUser.Expires = DateTime.Now.AddDays(2);
                        Response.Cookies.Add(tempUser);
                    }
                    else if (cbRem.Checked == false)
                    {
                        tempUser["remember"] = "0";
                        Response.Cookies.Add(tempUser);
                    }
    
                    sqlCon.Close();                   
                    Response.Redirect("Workshop.aspx");
                    break;
                }
                //Testing if the login username or password is incorrect
                else if((scan.GetValue(0).ToString() == tbUsername.Text) && (scan.GetValue(1).ToString() != tbPassword.Text))
                {
                    flag = "1";
                    break;
                    //sqlCon.Close();
                }
                else if((scan.GetValue(0).ToString() != tbUsername.Text) && (scan.GetValue(1).ToString() == tbPassword.Text))
                {
                    flag = "0";
                    break;
                    //sqlCon.Close();
                }
            }
            //If they are incorrect then I tell the user if the password is incorrect or the overall credentials is incorrect

            //Will be stupid if you say the password was found but the username is wrong    !!!!!!!!!!NB NB NB NB NB!!!!!!!!!!
            if (flag == "1")
                lblError.Text = "You are a user but your given password is incorrect";
            else if(flag == "0")
                lblError.Text = "Invalid login credentials";
            else
                lblError.Text = "Invalid login credentials";
        }
    }
}