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
    public partial class login : DevComponents.DotNetBar.Metro.MetroForm
    {
        public login()
        {
            InitializeComponent();
        }

        #region Variables
        #endregion

        #region Metodos
        private void login_Load(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            database datos = new database();
            Empleado empActual = new Empleado(txtUsuario.Text, txtContrasenia.Text);
            empActual = datos.login(empActual);
            if (datos.Log.Equals("EXITO")) 
            {
                Form1 fmEmpresa = new Form1(empActual);
                fmEmpresa.Show();
                this.Hide();
            }
            else if (datos.Log.Equals("USUARIO INEXISTENTE")) 
            {
                MessageBox.Show(datos.Log);
            }
            else if (datos.Log.Equals("CONTRASEÑA ERRONEA")) 
            {
                MessageBox.Show(datos.Log);
            }
            else { MessageBox.Show(datos.Log); }

        }
        #endregion
    }
}
