using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ASSYST.modelos;

namespace ASSYST
{
    public partial class MenuPrincipal : DevComponents.DotNetBar.Metro.MetroForm
    {
        Empleado empleadoActual;
        Empresa empresaActual;
        public MenuPrincipal(Empleado empleado, Empresa empresa)
        {
            InitializeComponent();
            empleadoActual = empleado;
            empresaActual = empresa;
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {

            lblNombreEmpleado.Text = empleadoActual.NombreCompleto;
            lblNombreEmpresa.Text = empresaActual.NombreEmpresa;
        }
    }
}
