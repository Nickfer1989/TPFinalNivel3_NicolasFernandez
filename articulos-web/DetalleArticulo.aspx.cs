using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace articulos_web
{
    public partial class DetalleArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //txtId.Enabled = false;
            try
            {
                if (!IsPostBack)
                {
                    ElementoNegocio negocio = new ElementoNegocio();
                    List<Elemento> lista = negocio.listar();

                    ddlMarca.DataSource = lista;
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();

                    CategoriaNegocio categorianegocio = new CategoriaNegocio();
                    List<Elemento> lista2 = categorianegocio.listar();

                    ddlCategoria.DataSource = lista2;
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();
                }

                //conf si estamos modificando.
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "" && !IsPostBack)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                  
                    Articulo seleccionado = (negocio.listar(id))[0];

                    //pre cargar los campos...
                    txtId.Text = id;
                    txtId.ReadOnly = true;
                    txtCodArt.Text = seleccionado.Codigo;
                    txtCodArt.ReadOnly = true;
                    txtNombre.Text = seleccionado.Nombre;
                    txtNombre.ReadOnly = true;
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtDescripcion.ReadOnly = true;
                    txtImagenUrl.Text = seleccionado.ImagenUrl;
                    txtImagenUrl.ReadOnly = true;
                    txtPrecio.Text = seleccionado.Precio.ToString();
                    txtPrecio.ReadOnly = true;

                    ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                    ddlMarca.Enabled = false;
                    ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();
                    ddlCategoria.Enabled = false;

                    txtImagenUrl_TextChanged(sender, e);

                }

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }

        }

       protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = txtImagenUrl.Text;
        }
}   }