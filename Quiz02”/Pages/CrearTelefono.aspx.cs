using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Quiz02_
{
    public partial class CrearTelefono : Page
    {
        // Contexto de base de datos, asumiendo que ya tienes un DbContext o similar configurado
        private Quiz02_.Data.PV_Quiz02Entities dbContext = new Quiz02_.Data.PV_Quiz02Entities();

        // Método de validación de la fecha de lanzamiento
        protected void cvFechaLanzamiento_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DateTime fechaLanzamiento;
            bool isDate = DateTime.TryParse(args.Value, out fechaLanzamiento);

            if (isDate && fechaLanzamiento <= DateTime.Now)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }

        // Método para mostrar un mensaje de alerta con JavaScript
        private void ShowMessage(string message)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + message + "');", true);
        }

        // Evento al hacer clic en el botón "Guardar"
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)  // Verifica si el formulario es válido
            {
                // Recoger los datos del formulario
                string marca = txtMarca.Text.Trim();
                string nombre = txtNombre.Text.Trim();
                int? anhoFabricacion = string.IsNullOrEmpty(txtAnhoFabricacion.Text) ? (int?)null : Convert.ToInt32(txtAnhoFabricacion.Text);
                DateTime? fechaLanzamiento = string.IsNullOrEmpty(txtFechaLanzamiento.Text) ? (DateTime?)null : Convert.ToDateTime(txtFechaLanzamiento.Text);
                int? precio = string.IsNullOrEmpty(txtPrecio.Text) ? (int?)null : Convert.ToInt32(txtPrecio.Text);

                try
                {
                    // Llamar al procedimiento almacenado para crear el teléfono
                    int resultado = dbContext.spCrearTelefono(marca, nombre, anhoFabricacion, fechaLanzamiento, precio);

                    if (resultado > 0)
                    {
                        // Mostrar mensaje de éxito
                        Response.Redirect("Resultado.aspx?mensaje=Teléfono creado con éxito!");
                    }
                    else
                    {
                        // Mostrar mensaje de error si la creación no fue exitosa
                        ShowMessage("Hubo un error al crear el teléfono. Intente nuevamente.");
                    }
                }
                catch (Exception ex)
                {
                    // Capturar cualquier excepción y mostrar el error
                    ShowMessage("Error: " + ex.Message);
                }
            }
            else
            {
                // Si la validación del formulario falla
                ShowMessage("Por favor, complete todos los campos correctamente.");
            }
        }
    }
}
