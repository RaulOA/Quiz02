using System;
using System.Web.UI;

namespace Quiz02_
{
    public partial class Resultado : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verificar si existe un mensaje en el querystring
            if (!string.IsNullOrEmpty(Request.QueryString["mensaje"]))
            {
                // Mostrar el mensaje en el Label
                lblMensaje.Text = Request.QueryString["mensaje"];
            }
            else
            {
                // Si no hay mensaje, mostrar uno predeterminado
                lblMensaje.Text = "La operación no ha proporcionado un mensaje.";
            }
        }
    }
}
