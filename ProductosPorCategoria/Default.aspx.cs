using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ProductosPorCategoria
{
    public partial class _Default : Page
    {
        string connectionString = "Server=localhost\\SQLEXPRESS;Database=PracticaEval;Trusted_Connection=True;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCategoriasConVentas2019();
            }
        }

        private void CargarCategoriasConVentas2019()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                SELECT DISTINCT c.CodigoCategoria, c.Nombre
                FROM Categoria c
                JOIN Producto p ON c.CodigoCategoria = p.CodigoCategoria
                JOIN Venta v ON p.CodigoProducto = v.CodigoProducto
                WHERE YEAR(v.Fecha) = 2019";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                ddlCategorias.DataSource = cmd.ExecuteReader();
                ddlCategorias.DataTextField = "Nombre";
                ddlCategorias.DataValueField = "CodigoCategoria";
                ddlCategorias.DataBind();
            }

            ddlCategorias.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Selecciona una categoría --", ""));
        }

        protected void ddlCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            string categoriaId = ddlCategorias.SelectedValue;

            if (!string.IsNullOrEmpty(categoriaId))
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"
                    SELECT DISTINCT p.Nombre AS Producto
                    FROM Producto p
                    JOIN Venta v ON p.CodigoProducto = v.CodigoProducto
                    WHERE p.CodigoCategoria = @categoriaId AND YEAR(v.Fecha) = 2019";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@categoriaId", categoriaId);
                    conn.Open();
                    gvProductos.DataSource = cmd.ExecuteReader();
                    gvProductos.DataBind();
                }
            }
            else
            {
                gvProductos.DataSource = null;
                gvProductos.DataBind();
            }
        }
    }
}