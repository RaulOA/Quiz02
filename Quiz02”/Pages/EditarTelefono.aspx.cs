using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Quiz02_.Data;

namespace Quiz02_
{
    public partial class EditarTelefono : Page
    {
        PV_Quiz02Entities dbContext = new PV_Quiz02Entities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Obtener el parámetro 'id' de la query string
                int idTelefono;
                if (int.TryParse(Request.QueryString["id"], out idTelefono))
                {
                    // Cargar los datos del teléfono según el ID
                    CargarTelefono(idTelefono);
                }
                else
                {
                    // Redirigir a la lista si no hay ID válido
                    Response.Redirect("ListaTelefonos.aspx");
                }
            }
        }

        protected void cvFechaLanzamiento_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DateTime fechaLanzamiento;

            // Intenta convertir el valor del campo de texto a un tipo DateTime
            if (DateTime.TryParse(txtFechaLanzamiento.Text, out fechaLanzamiento))
            {
                // Compara la fecha ingresada con la fecha actual
                if (fechaLanzamiento <= DateTime.Now)
                {
                    args.IsValid = true; // La validación es exitosa
                }
                else
                {
                    args.IsValid = false; // La fecha es mayor a la actual, no es válida
                }
            }
            else
            {
                args.IsValid = false; // No es una fecha válida
            }
        }

        private void CargarTelefono(int idTelefono)
        {
            var telefono = dbContext.spConsultarTelefonoPorId(idTelefono).FirstOrDefault();
            if (telefono != null)
            {
                txtMarca.Text = telefono.marca;
                txtNombre.Text = telefono.nombre;
                txtAnhoFabricacion.Text = telefono.anhoFabricacion.ToString();
                txtFechaLanzamiento.Text = telefono.fechaLanzamiento?.ToString("yyyy-MM-dd");
                txtPrecio.Text = telefono.precio.ToString();
            }
            else
            {
                // Si no se encuentra el teléfono, redirigir a la lista
                Response.Redirect("ListaTelefonos.aspx");
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int idTelefono = int.Parse(Request.QueryString["id"]);
                try
                {
                    dbContext.spEditarTelefono(idTelefono, txtMarca.Text, txtNombre.Text,
                        int.Parse(txtAnhoFabricacion.Text),
                        DateTime.Parse(txtFechaLanzamiento.Text),
                        int.Parse(txtPrecio.Text));

                    // Redirigir al resultado si se guarda con éxito
                    Response.Redirect("Resultado.aspx?mensaje=Ha modificado correctamente un teléfono en la base de datos");
                }
                catch (Exception ex)
                {
                    MostrarMensaje($"Error al actualizar el teléfono: {ex.Message}");
                }
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int idTelefono = int.Parse(Request.QueryString["id"]);
            try
            {
                dbContext.spEliminarTelefono(idTelefono);

                // Redirigir al resultado después de eliminar
                Response.Redirect("Resultado.aspx?mensaje=Ha eliminado correctamente la información de un teléfono en la base de datos");
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error al eliminar el teléfono: {ex.Message}");
            }
        }

        private void MostrarMensaje(string message)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('{message}');", true);
        }
    }
}
