using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using ASSYST.modelos;

namespace ASSYST
{
    public partial class Form1 : DevComponents.DotNetBar.Metro.MetroForm
    {
        Empleado empleado;
        database datos;
        public Form1(Empleado empActual)
        {
            InitializeComponent();
            empleado = empActual;
        }

        #region Variables
        
        Thread thregistro;
        Thread thLogin;
        #endregion

        #region Metodos

        public void methlogin()
        {
            Thread.Sleep(2000);
            MessageBox.Show("conexion exitosa");
        }

        public void methRegistro()
        {
            Thread.Sleep(3000);
            MessageBox.Show("Registro exitoso");
        }
        #endregion

        #region MainForm
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            thLogin = new Thread(methlogin);
            thLogin.Start();
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            thregistro = new Thread(methRegistro);
            thregistro.Start();
        }
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            datos = new database();
            lblEmpleadoNombre.Text = empleado.NombreCompleto;
            DataTable dtEmpresas = datos.listaEmpresas();
            dgvEmpresas.DataSource = dtEmpresas;
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            Empresa empresaActual = new Empresa(dgvEmpresas.Rows[0].Cells["rfc"].Value.ToString());
            datos  = new database();
            empresaActual = datos.seleccionEmpresa(empresaActual);
            MenuPrincipal mp = new MenuPrincipal(empleado, empresaActual);
            mp.Show();
            this.Hide();
            
        }

    }
}
