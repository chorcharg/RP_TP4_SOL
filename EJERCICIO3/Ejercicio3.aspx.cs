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
        private const string LibreriaBD = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Libreria;Integrated Security=True
 ";
        private string ConsultaLibreria = "SELECT * FROM Temas";
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}