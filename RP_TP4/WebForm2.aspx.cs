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
    public partial class WebForm2 : System.Web.UI.Page
    {
        private const string cadenaDeConexion = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Neptuno;Integrated Security=True;";
        private string consultaProductos = "SELECT IdProducto, NombreProducto, IdCategoría, CantidadPorUnidad, PrecioUnidad FROM Productos";
        private DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection sqlConnection = new SqlConnection(cadenaDeConexion);
                sqlConnection.Open();

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(consultaProductos, cadenaDeConexion);
                sqlDataAdapter.Fill(ds, "Productos");

                Gv_Productos.DataSource = ds.Tables["Productos"];
                Gv_Productos.DataBind();

                sqlConnection.Close();
            }
        }

    }
}