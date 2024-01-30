using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;


namespace articulos_web
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Seguridad.sesionActiva(Session["trainee"]))
            {
                Trainee user = (Trainee)Session["trainee"];
                lblUser.Text = user.Email;
                if (!string.IsNullOrEmpty(user.ImagenPerfil))
                {
                    imgAvatar.ImageUrl = "~/Images/" + user.ImagenPerfil + "?v=" + DateTime.Now.Ticks.ToString();
                }
                else
                {
                    imgAvatar.ImageUrl = "https://cdn.iconscout.com/icon/free/png-512/free-profile-417-1163876.png?f=webp&w=256";
                }

            }
            else
            {
                imgAvatar.ImageUrl = "https://cdn.iconscout.com/icon/free/png-512/free-profile-417-1163876.png?f=webp&w=256";
            }

            if (!(Page is Login || Page is Registro  || Page is Error || Page is Default || Page is DetalleArticulo ))
            {
                if (!Seguridad.sesionActiva(Session["trainee"]))
                    Response.Redirect("Login.aspx", false);
                else
                {
                    Trainee user = (Trainee)Session["trainee"];
                    lblUser.Text = user.Email;
                    if (!string.IsNullOrEmpty(user.ImagenPerfil))
                        imgAvatar.ImageUrl = "~/Images/" + user.ImagenPerfil + "?v=" + DateTime.Now.Ticks.ToString();
                }
            }
            

        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}