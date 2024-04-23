using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace RP_TP4
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        private const string ViajesDB = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Viajes;Integrated Security=True";
        private string consultaSql = "SELECT * FROM Provincia";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection Viajes = new SqlConnection(ViajesDB);
                Viajes.Open();
                SqlCommand sqlCommand = new SqlCommand(consultaSql, Viajes);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            }

        }

    }

}