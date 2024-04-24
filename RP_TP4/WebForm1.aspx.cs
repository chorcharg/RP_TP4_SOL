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
        private string consultaSql = "SELECT * FROM Provincias";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                {
                    CargarProvincias();
                    
                }
            }
        }
        private void CargarProvincias()
        {
            using (SqlConnection Viajes = new SqlConnection(ViajesDB))
            {
                try
                {
                    Viajes.Open();
                    string consultaSql = "SELECT * FROM Provincias";
                    SqlCommand sqlCommand = new SqlCommand(consultaSql, Viajes);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    DdlProvinciaInicio.Items.Clear();

                    DdlProvinciaInicio.Items.Insert(0, new ListItem("--Seleccionar Provincia--", ""));
                    while (sqlDataReader.Read())
                    {
                        string nombreProvincia = sqlDataReader["NombreProvincia"].ToString();
                        string idProvincia = sqlDataReader["IdProvincia"].ToString();
                        DdlProvinciaInicio.Items.Add(new ListItem(nombreProvincia, idProvincia));



                    }
                }
                finally { };
            }
        }
    }
}