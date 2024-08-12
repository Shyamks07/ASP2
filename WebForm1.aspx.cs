using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

using System.Configuration;

namespace WebApplication2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack!=true)
            {
                show();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int eid = Convert.ToInt16(TextBox1.Text);
            string n = TextBox2.Text;
            int sal = Convert.ToInt16(TextBox3.Text);
          string Constring =ConfigurationManager.ConnectionStrings["employee1"].ConnectionString;
            SqlConnection con = new SqlConnection(Constring);
            con.Open();
            string sqlstmt = "insert into employee1(empid,firstname,salary)values(@empid,@firstname,@salary)";
            SqlCommand cmd = new SqlCommand(sqlstmt, con);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@empid", eid);
            cmd.Parameters.AddWithValue("@firstname", n);
            cmd.Parameters.AddWithValue("@salary", sal);
            cmd.ExecuteNonQuery();
            con.Close();
            show();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int a= Convert.ToInt16(TextBox4.Text);
            string Constring = ConfigurationManager.ConnectionStrings["employee1"].ConnectionString;
            SqlConnection con = new SqlConnection(Constring);
            con.Open();
            string sqlstm = "delete from  employee1 where empid=@empid";
            SqlCommand cmd = new SqlCommand(sqlstm, con);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@empid", a);
            cmd.ExecuteNonQuery();
            con.Close();
            show();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int x= Convert.ToInt32(TextBox5.Text);
            int d = Convert.ToInt16(TextBox6.Text);
            string Constring = ConfigurationManager.ConnectionStrings["employee1"].ConnectionString;
            SqlConnection con = new SqlConnection(Constring);
            con.Open();
            string sqlstm = "update employee1 set salary=@s where empid=@d";
            SqlCommand cmd = new SqlCommand(sqlstm, con);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@s", x);
            cmd.Parameters.AddWithValue("@d", d);
            cmd.ExecuteNonQuery();
            con.Close();
            show();
        }


        public void show()
        {
            string Constring = ConfigurationManager.ConnectionStrings["employee1"].ConnectionString;
            SqlConnection con = new SqlConnection(Constring);
            con.Open();
            string sqlstm = "select * from employee1";

            SqlDataAdapter adp = new SqlDataAdapter(sqlstm, con);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            GridView1.DataSource = ds;
            GridView1.DataBind();

            con.Close();
        }
    }
}