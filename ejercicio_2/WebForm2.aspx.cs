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
        private DataSet dataProductos = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CargarDatos();
            }
        }
        protected void CargarDatos()
        {
            SqlConnection sqlConnection = new SqlConnection(cadenaDeConexion);
            
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(consultaProductos, cadenaDeConexion);
            sqlDataAdapter.Fill(dataProductos, "Productos");
                
            //cargo el grid view
            Gv_Productos.DataSource = dataProductos.Tables["Productos"];
            Gv_Productos.DataBind();

            sqlConnection.Close();
            
        }

        protected void LimpiarFiltros()
        {
            Tb_IdProducto.Text = "";
            Tb_IdCategoria.Text = "";
        }

        protected void Btn_QuitarFiltro_Click(object sender, EventArgs e)
        {
            LimpiarFiltros();
            CargarDatos(); 
        }

        protected void Btn_Filtrar_Click(object sender, EventArgs e)
        {

            if (!validarTbs())
            {
                lbl_error1.Text = "Debe ingresar al menos un filtro";
                return;
            }
            lbl_error1.Text = "";

            SqlConnection sqlConnection = new SqlConnection(cadenaDeConexion);
            sqlConnection.Open();
            
            if(Tb_IdCategoria.Text.Trim() != "" && Tb_IdProducto.Text.Trim() != "")
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(FiltroDoble() , cadenaDeConexion);
                sqlDataAdapter.Fill(dataProductos, "Productos");
            }
            else
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(FiltroSimple(), cadenaDeConexion);
                sqlDataAdapter.Fill(dataProductos, "Productos");
            }
                
            //cargo el grid view
            Gv_Productos.DataSource = dataProductos.Tables["Productos"];
            Gv_Productos.DataBind();

            sqlConnection.Close();
        }
        private string FiltroSimple()
        {
            string ConsultaFiltro = consultaProductos + " WHERE ";
            
            if (Tb_IdProducto.Text.Trim() != "")
            {
                ConsultaFiltro += "IdProducto " + Ddl_IdProducto.SelectedValue.ToString() + Tb_IdProducto.Text.Trim();
            }

            else if(Tb_IdCategoria.Text.Trim() != "")
            {
                ConsultaFiltro += "IdCategoría " + Ddl_IdCategoria.SelectedValue.ToString() + Tb_IdCategoria.Text.Trim();
            }

            return ConsultaFiltro;
        }

        private string FiltroDoble()
        {
            
            string ConsultaFiltro = consultaProductos + " WHERE ";
            
                ConsultaFiltro +=
                    "IdProducto " + Ddl_IdProducto.SelectedValue.ToString() + Tb_IdProducto.Text
                    + " AND " +
                    " IdCategoría " + Ddl_IdCategoria.SelectedValue.ToString() + Tb_IdCategoria.Text;
                       
            return ConsultaFiltro;
        }



        private Boolean validarTbs()
        {

            if(Tb_IdCategoria.Text.Trim()=="" && Tb_IdProducto.Text.Trim() == "")
            {

                return false;
            }


            return true;
        }

    }

}