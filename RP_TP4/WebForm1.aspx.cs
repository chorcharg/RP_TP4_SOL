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

            //Cargo El dataset con todas las tablas 
            CargarTablas();

            if (!IsPostBack)
            {

                    //Agrego el item de Seleccione "default"
                    DdlProvinciaInicio.Items.Add(new ListItem("--Seleccione Provincia--", "-1"));
                    DdlProvinciaFinal.Items.Add(new ListItem("--Seleccione Provincia--", "-1"));
                    DdlLocalidadInicio.Items.Add(new ListItem("--Seleccione Localidad--", "-1"));
                    DdlLocalidadFinal.Items.Add(new ListItem("--Seleccione Localidad--", "-1"));


                    //Cargo Los DropDownList de provincias
                    CargarProvincias();
                    
            }
        }


        private void CargarTablas()
        {

            SqlConnection sqlConnection = new SqlConnection(ViajesDB);
            sqlConnection.Open();

            //CARGO LA TABLA DE PROVINCIAS
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(consultaSqlProvincias, sqlConnection);
            sqlDataAdapter.Fill(setDatos, "Provincias");

            //CARGO LA TABLA DE LOCALIDADES
            sqlDataAdapter = new SqlDataAdapter(consultaSqlLocalidades, sqlConnection);
            sqlDataAdapter.Fill(setDatos, "Localidades");
            sqlConnection.Close();
       
        }


        //como parametros estan los DDL, de esa forma usamos un solo meotdo para ambos conjuntos de DDL
        //desde el evento change de los DDL, llamamos a este metodo, pasandole como argumento 
        //los DDL quer intervienen

        private void carga_localidades(DropDownList ddlProvincias, DropDownList ddlLocalidades)
        {
            //cargo el value del item seleccionado en el DDL de provincias, como ID de provincia
            String idProvincia = ddlProvincias.SelectedItem.Value;

            //simepre limpio y agrego item default
            ddlLocalidades.Items.Clear();
            ddlLocalidades.Items.Add(new ListItem("--Seleccione Localidad--", "-1"));

            //si se selecciono el "defauult" no sigo,
            if (idProvincia == "-1")
            {
                return;
            }

            // recorro la tabla localidades del setDatos, 

            foreach (DataRow localidad in setDatos.Tables["Localidades"].Rows)
            {

                // si el campo IdProvincia del row de localidad, me coincide con idProvincia,
                // lo cargo en el DDL de localidades

                if (localidad["IdProvincia"].ToString().Equals(idProvincia))
                {
                    ddlLocalidades.Items.Add(
                        new ListItem (
                            localidad["NombreLocalidad"].ToString(), 
                            localidad["IdLocalidad"].ToString()
                            )
                        );
                }

            }


        }

        private void CargarProvincias()
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

        }

        protected void DdlProvinciaInicio_SelectedIndexChanged(object sender, EventArgs e)
        {

            carga_localidades(DdlProvinciaInicio, DdlLocalidadInicio);

        }

        protected void DdlProvinciaFinal_SelectedIndexChanged(object sender, EventArgs e)
        {
            carga_localidades(DdlProvinciaFinal, DdlLocalidadFinal);
        }
    }
}