using System;
using System.Linq;
using System.Web.UI;
using Quiz02_.Data;

namespace Quiz02_
{
    public partial class ListaTelefonos : Page
    {
        private PV_Quiz02Entities dbContext = new PV_Quiz02Entities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Cargar los datos de los teléfonos al cargar la página por primera vez
                CargarTelefonos();
            }
        }

        private void CargarTelefonos()
        {
            try
            {
                // Llamar al procedimiento almacenado para obtener la lista de teléfonos
                var telefonos = dbContext.spConsultarTelefonos().ToList();

                // Asignar la lista al GridView y enlazar los datos
                gvTelefonos.DataSource = telefonos;
                gvTelefonos.DataBind();
            }
            catch (Exception ex)
            {
                // Manejo básico de errores
                Response.Write("Error al cargar los teléfonos: " + ex.Message);
            }
        }
    }
}
