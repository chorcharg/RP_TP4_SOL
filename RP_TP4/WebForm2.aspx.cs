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
                // Almacenar el DataSet en el estado
                Session["ProductosDataSet"] = ds;

                Gv_Productos.DataSource = ds.Tables["Productos"];
                Gv_Productos.DataBind();

                sqlConnection.Close();
            }
            else
            {
                // Recuperar el DataSet del estado de sesión
                ds = (DataSet)Session["ProductosDataSet"];
            }
        }
        protected void Tb_IdProducto_TextChanged(object sender, EventArgs e)
        {
            // Obtener el valor ingresado en el TextBox
            string idProducto = Tb_IdProducto.Text.Trim();

            // Actualizar el DropDownList con el valor ingresado
            Ddl_IdProducto.SelectedValue = idProducto;

            // Filtrar los datos según el ID del producto
            DataView ProductoFiltrado = ds.Tables["Productos"].DefaultView;
            string IdProdFiltrado = $"IdProducto = '{idProducto}'";
            ProductoFiltrado.RowFilter = IdProdFiltrado;

            // Asignar los datos filtrados al control GridView
            Gv_Productos.DataSource = ProductoFiltrado;
            Gv_Productos.DataBind();
        }
        protected void Ddl_IdProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtiene  el ID del producto seleccionado
            string idProducto = Ddl_IdProducto.SelectedValue;

            // Filtra los datos según el ID del producto
            DataView ProductoFiltrado = ds.Tables["Productos"].DefaultView;
            ProductoFiltrado.RowFilter = $"IdProducto = '{idProducto}'";

            // Asigna los datos filtrados al control GridView 
            Gv_Productos.DataSource = ProductoFiltrado;
            Gv_Productos.DataBind();

        }

        protected void Tb_IdCategoria_TextChanged(object sender, EventArgs e)
        {
            // Obtener el valor ingresado en el TextBox
            string idCategoria = Tb_IdCategoria.Text.Trim();

            // Actualizar el DropDownList con el valor ingresado
            Ddl_IdCategoria.SelectedValue = idCategoria;

            // Filtrar los datos según el ID de categoria
            DataView CategoriaFiltrada = ds.Tables["Productos"].DefaultView;
            string IdCategFiltrada = $"IdCategoría = '{idCategoria}'";
            CategoriaFiltrada.RowFilter = IdCategFiltrada;

            // Asignar los datos filtrados al control GridView
            Gv_Productos.DataSource = CategoriaFiltrada;
            Gv_Productos.DataBind();
        }

        protected void Ddl_IdCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtiene  el ID de la Categoria seleccionada
            string idCategoria = Ddl_IdCategoria.SelectedValue;

            // Filtra los datos según el ID de Categoria
            DataView CategoriaFiltrada = ds.Tables["Productos"].DefaultView;
            CategoriaFiltrada.RowFilter = $"IdCategoría = '{idCategoria}'";

            // Asigna los datos filtrados al control GridView 
            Gv_Productos.DataSource = CategoriaFiltrada;
            Gv_Productos.DataBind();
        }
    }
}