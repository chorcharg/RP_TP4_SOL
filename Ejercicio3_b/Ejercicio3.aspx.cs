using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace EJERCICIO3
{
    public partial class Ejercicio3 : System.Web.UI.Page
    {
        private const string LibreriaBD = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Libreria;Integrated Security=True";
        private string ConsultaLibreria = "SELECT * FROM Temas";
        
        private DataSet setDatos = new DataSet();
        private int temaSeleccionado=0;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarDropDownListTemas();
            }
        }

        private void LlenarDropDownListTemas()
        {
            SqlConnection conexion = new SqlConnection(LibreriaBD);
            // Abrir la conexión.
            conexion.Open();

            // Crear un comando SQL para seleccionar los temas.
            SqlCommand comando = new SqlCommand(ConsultaLibreria, conexion);
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            adaptador.Fill(setDatos, "Temas"); 

            // Enlazar el DropDownList al DataSet.
            DdlTemas.DataSource = setDatos.Tables["Temas"]; 
            // Establece el campo que se mostrará en el DropDownList.
            DdlTemas.DataTextField = "Tema"; 
            DdlTemas.DataValueField = "IdTema";
            DdlTemas.DataBind();
            conexion.Close();

        }



        protected void LbVerLibros_Click(object sender, EventArgs e)
        {

            Response.Redirect($"ListadoLibros.aspx?themeId="+DdlTemas.SelectedItem.Value);
        }
    }
}