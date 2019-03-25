using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace connected
{
    public partial class WebForm1 : System.Web.UI.Page
    {
       public  SqlConnection Getconnection()
        {
            SqlConnection con = new SqlConnection("data source = DESKTOP-GQADM33; initial catalog = adp.net; integrated security = true");
            return con;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            SqlConnection con = Getconnection();
            SqlCommand cmd = new SqlCommand("Inserttest", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@First_name", TextBox2.Text);
            cmd.Parameters.AddWithValue("@Last_name", TextBox3.Text);
            cmd.Parameters.AddWithValue("@Email", TextBox4.Text);
            cmd.Parameters.AddWithValue("@Phone", TextBox5.Text);
            con.Open();
            int flag = cmd.ExecuteNonQuery();
            if (flag > 0)
            {
                message.Text = "record inserted";
            }

            con.Close();


        }

        protected void delete(object sender, EventArgs e)
        {
            SqlConnection con = Getconnection();
            SqlCommand cmd = new SqlCommand("Deletetest", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Addess_id", Convert.ToInt16(TextBox1.Text));
            con.Open();
            int flag = cmd.ExecuteNonQuery();
            if (flag > 0)
            {
                message.Text = "Record deleted succesfully";

            }
            con.Close();


            


        }

        protected void update(object sender, EventArgs e)
        {
            SqlConnection con = Getconnection();
            SqlCommand cmd = new SqlCommand("Updatetest", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@First_name", TextBox2.Text);
            cmd.Parameters.AddWithValue("@Address_ID",Convert.ToInt16( TextBox1.Text));
            con.Open();
            int flag = cmd.ExecuteNonQuery();
            if (flag > 0)
            {
                message.Text = "record updates successfully";
            }

            

        }

        protected void search(object sender, EventArgs e)
        {
            
            try
            {
                using (SqlConnection con = Getconnection())
                {
                    SqlDataAdapter da = new SqlDataAdapter("Select * from adotest", con);

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {

            }


        }
    }
}