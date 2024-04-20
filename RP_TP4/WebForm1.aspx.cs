using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace RP_TP4
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        private const string ViajesDB = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Viajes;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection Viajes = new SqlConnection(ViajesDB);
            Viajes.Open();


        }
    }
}