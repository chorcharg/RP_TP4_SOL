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
        private const string consultaSqlProvincias = "SELECT * FROM Provincias";
        private const string consultaSqlLocalidades = "SELECT * FROM Localidades"; 

        private DataSet setDatos = new DataSet();



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                {
                    //Cargo El dataset con todas las tablas 
                    CargarTablas();
                    //Agrego el item de Seleccione "X"
                    DdlProvinciaInicio.Items.Add(new ListItem("--Seleccione Provincia--", "-1"));
                    DdlProvinciaFinal.Items.Add(new ListItem("--Seleccione Provincia--", "-1"));
                    DdlLocalidadInicio.Items.Add(new ListItem("--Seleccione Localidad--", "-1"));
                    DdlLocalidadFinal.Items.Add(new ListItem("--Seleccione Localidad--", "-1"));
                    //Cargo Los DropDownList
                    CargarProvincias_Y_Localidades();
                    

                }
            }
        }
        private void CargarTablas()
        {

            SqlConnection sqlConnection = new SqlConnection(ViajesDB);
            sqlConnection.Open();

            //CARGO LA TABLA DE PROVINCIAS
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(consultaSqlProvincias, sqlConnection);
            sqlDataAdapter.Fill(setDatos, "Provincias");

            sqlDataAdapter = new SqlDataAdapter(consultaSqlLocalidades, sqlConnection);
            sqlDataAdapter.Fill(setDatos, "Localidades");
            sqlConnection.Close();
       
        }

        private void CargarProvincias_Y_Localidades()
        {
            foreach (DataRow provincia in setDatos.Tables["Provincias"].Rows)
            {
                DdlProvinciaInicio.Items.Add(
                    new ListItem(provincia["NombreProvincia"].ToString(), provincia["IdProvincia"].ToString())
                    );

                DdlProvinciaFinal.Items.Add(
                    new ListItem(provincia["NombreProvincia"].ToString(), provincia["IdProvincia"].ToString())
                    );
            }

            foreach (DataRow localidad in setDatos.Tables["Localidades"].Rows)
            {
                DdlLocalidadInicio.Items.Add(
                    new ListItem(localidad["NombreLocalidad"].ToString(), localidad["IdLocalidad"].ToString())
                    );
                DdlLocalidadFinal.Items.Add(
                    new ListItem(localidad["NombreLocalidad"].ToString(), localidad["IdLocalidad"].ToString())
                    );
            }
        }

    }
}