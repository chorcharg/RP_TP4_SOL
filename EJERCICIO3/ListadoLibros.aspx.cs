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
    public partial class WebForm1 : System.Web.UI.Page
    {
        private const string LibreriaBD = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Libreria;Integrated Security=True";
        private string ConsultaLibrosPorTema = "SELECT * FROM Libros WHERE IdTema = @IdTema";
        private DataSet setDatos = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Recuperar el ID del tema desde el parámetro de consulta
                int idTema = Convert.ToInt32(Request.QueryString["themeId"]);
                LlenarGvLibros(idTema);
            }
        }

        private void LlenarGvLibros(int idTema)
        {
            using (SqlConnection conexion = new SqlConnection(LibreriaBD))
            {
                // Abrir la conexión.
                conexion.Open();

                // Crear un comando SQL para seleccionar los libros del tema específico.
                SqlCommand comando = new SqlCommand(ConsultaLibrosPorTema, conexion);
                comando.Parameters.AddWithValue("@IdTema", idTema);

                SqlDataReader sqlDataReader = comando.ExecuteReader();
                GvLibros.DataSource = sqlDataReader;
                GvLibros.DataBind();

                // Cerrar la conexión.
                conexion.Close();
            }
        }
    

    protected void GvLibros_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }

        protected void LBConsultarTema_Click(object sender, EventArgs e)
        {
            // Redirigir a la página "Seleccionar Tema"
            Response.Redirect("Ejercicio3.aspx");
        }
    }
}