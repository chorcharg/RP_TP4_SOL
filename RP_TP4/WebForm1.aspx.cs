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
        private const string consultaSql = "SELECT * FROM Provincias";

        private DataSet setDatos = new DataSet();



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

            SqlConnection sqlConnection = new SqlConnection(ViajesDB);
            sqlConnection.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(consultaSql, sqlConnection);

            sqlDataAdapter.Fill(setDatos, "Provincias");
            sqlConnection.Close();


            //DdlProvinciaInicio.Items.Insert(0, "--Seleccione Provincia--");

            DdlProvinciaInicio.Items.Add(new ListItem("--Seleccione Provincia--", "-1"));
            foreach (DataRow provincia in setDatos.Tables["Provincias"].Rows)
            {
                DdlProvinciaInicio.Items.Add(
                    new ListItem(provincia["NombreProvincia"].ToString(), provincia["IdProvincia"].ToString())
                    );

            }


            /*
            DdlProvinciaInicio.DataSource = setDatos.Tables["Provincias"];
            DdlProvinciaInicio.DataTextField = "NombreProvincia";
            DdlProvinciaInicio.DataValueField = "IdProvincia";
            DdlProvinciaInicio.DataBind();
            */
            



        }
    }
}