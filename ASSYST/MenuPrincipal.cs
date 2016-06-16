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

        private void btnDatosCPAceptar_Click(object sender, EventArgs e)
        {
            database datos = new database();
            string tipoBusqueda = "", parametroBusqueda = "", valorParametroBusqueda = "";
            try
            {
                if (rbDatosCPAmbos.Checked == true) 
                {
                    tipoBusqueda = rbDatosCPAmbos.Text;
                    if (rbDatosCPTodos.Checked == true) { parametroBusqueda = rbDatosCPTodos.Text; }
                    else if (rbDatosCPRFC.Checked == true) { parametroBusqueda = rbDatosCPRFC.Text; valorParametroBusqueda = txtDatosCPRFC.Text; }
                    else if (rbDatosCPNombre.Checked == true) { parametroBusqueda = rbDatosCPNombre.Text; valorParametroBusqueda = txtDatosCPNombre.Text; }
                    else {}
                }
                else if (rbDatosCPClientes.Checked == true)
                {
                    tipoBusqueda = rbDatosCPClientes.Text;
                    if (rbDatosCPTodos.Checked == true) { parametroBusqueda = rbDatosCPTodos.Text; }
                    else if (rbDatosCPRFC.Checked == true) { parametroBusqueda = rbDatosCPRFC.Text; valorParametroBusqueda = txtDatosCPRFC.Text; }
                    else if (rbDatosCPNombre.Checked == true) { parametroBusqueda = rbDatosCPNombre.Text; valorParametroBusqueda = txtDatosCPNombre.Text; }
                    else { }
                }
                else if (rbDatosCPProvedores.Checked == true)
                {
                    tipoBusqueda = rbDatosCPProvedores.Text;
                    if (rbDatosCPTodos.Checked == true) { parametroBusqueda = rbDatosCPTodos.Text; }
                    else if (rbDatosCPRFC.Checked == true) { parametroBusqueda = rbDatosCPRFC.Text; valorParametroBusqueda = txtDatosCPRFC.Text; }
                    else if (rbDatosCPNombre.Checked == true) { parametroBusqueda = rbDatosCPNombre.Text; valorParametroBusqueda = txtDatosCPNombre.Text; }
                    else { }
                }
                else { MessageBox.Show("Parametros de busqueda no valido"); }
                dgvDatosCP.DataSource = datos.listaCP(tipoBusqueda, parametroBusqueda, valorParametroBusqueda);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDatosCPAltaAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                database datos = new database();
                DataTable dt = new DataTable("Resultado");
                Cliente clienteactual;
                Provedor provedorActual;
                object empresa = new object();
                if (rbDatosCPAltaCliente.Checked == true)
                {
                    clienteactual = new Cliente()
                    {
                        RFC = txtDatosCPAltaRFC.Text,
                        Nombre = txtDatosCPAltaNombre.Text,
                        Calle = txtDatosCPAltaCalle.Text,
                        NExt = txtDatosCPAltaNExt.Text,
                        Telefono = txtDatosCPAltaTelefono.Text,
                        NombreContacto = txtDatosCPAltaNomContacto.Text,
                        ApPatContacto = txtDatosCPAltaApPatContacto.Text,
                        ApMatContacto = txtDatosCPAltaApMatContacto.Text,
                        CorreoContacto = txtDatosCPAltaCorreoContacto.Text,
                        IdCiudad = Convert.ToInt32(cmbDatosCPAltaCiudad.Text)
                    };
                    //empresa = (Cliente)empresa;
                    dt = datos.insertarClienteProvedor(clienteactual);
                }
                else if (rbDatosCPAltaProvedor.Checked == true)
                {
                    provedorActual = new Provedor()
                    {
                        RFC = txtDatosCPAltaRFC.Text,
                        Nombre = txtDatosCPAltaNombre.Text,
                        Calle = txtDatosCPAltaCalle.Text,
                        NExt = txtDatosCPAltaNExt.Text,
                        Telefono = txtDatosCPAltaTelefono.Text,
                        NombreContacto = txtDatosCPAltaNomContacto.Text,
                        ApPatContacto = txtDatosCPAltaApPatContacto.Text,
                        ApMatContacto = txtDatosCPAltaApMatContacto.Text,
                        CorreoContacto = txtDatosCPAltaCorreoContacto.Text,
                        IdCiudad = Convert.ToInt32(cmbDatosCPAltaCiudad.Text)
                    }; ;
                    //empresa = (Provedor)empresa;
                    dt = datos.insertarClienteProvedor(provedorActual);
                }
                //dt = datos.insertarClienteProvedor(empresa);


                if (datos.Log.Equals("NUEVO"))
                {
                    MessageBox.Show("Registro exitoso de: " + dt.Rows[0]["nombre"].ToString() + "\n" + "Con RFC: " + dt.Rows[0]["RFC"].ToString(), "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (datos.Log.Equals("EXISTENTE"))
                {
                    MessageBox.Show("Ya existe un registro de: " + dt.Rows[0]["nombre"].ToString() + "\n" + "Con RFC: " + dt.Rows[0]["RFC"].ToString(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else { MessageBox.Show(datos.Log); }
               
            }
            catch ( Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        #region variablesActualizarCliente
        string tipo = "";
        #endregion

        private void btnDatosCPActBuscar_Click(object sender, EventArgs e)
        {
            database datos = new database();
            string tipoBusqueda = "", parametroBusqueda = "", valorParametroBusqueda = "";
            try
            {
                if (rbDatosCPActualizarClientes.Checked == true)
                {
                    tipoBusqueda = rbDatosCPActualizarClientes.Text;
                    tipo = tipoBusqueda;
                    if (rbDatosCPActualizarTodos.Checked == true) { parametroBusqueda = rbDatosCPActualizarTodos.Text; }
                    else if (rbDatosCPActualizarRFC.Checked == true) { parametroBusqueda = rbDatosCPActualizarRFC.Text; valorParametroBusqueda = txtDatosCPActRFC.Text; }
                    else if (rbDatosCPActualizarNombre.Checked == true) { parametroBusqueda = rbDatosCPActualizarNombre.Text; valorParametroBusqueda = txtDatosCPActNombre.Text; }
                    else { }
                }
                else if (rbDatosCPActualizarProvedores.Checked == true)
                {
                    tipoBusqueda = rbDatosCPActualizarProvedores.Text;
                    tipo = tipoBusqueda;
                    if (rbDatosCPActualizarTodos.Checked == true) { parametroBusqueda = rbDatosCPActualizarTodos.Text; }
                    else if (rbDatosCPActualizarRFC.Checked == true) { parametroBusqueda = rbDatosCPActualizarRFC.Text; valorParametroBusqueda = txtDatosCPActRFC.Text; }
                    else if (rbDatosCPActualizarNombre.Checked == true) { parametroBusqueda = rbDatosCPActualizarNombre.Text; valorParametroBusqueda = txtDatosCPActNombre.Text; }
                    else { }
                }
                else { MessageBox.Show("Parametros de busqueda no valido"); }
                dgvActualizar.DataSource = datos.listaCP(tipoBusqueda, parametroBusqueda, valorParametroBusqueda);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvActualizar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                database datos = new database();
                if (tipo.Equals("Clientes"))
                {
                    Cliente cliente = new Cliente() { RFC = dgvActualizar.Rows[e.RowIndex].Cells["rfc"].Value.ToString() };
                    cliente = (Cliente)datos.cargarDatosCliPro(cliente, tipo);
                    txtCPActualizarRFC.Text = cliente.RFC;
                    txtCPActualizarNombre.Text = cliente.Nombre;
                    txtCPActualizarCalle.Text = cliente.Calle;
                    txtCPActualizarNExt.Text = cliente.NExt;
                    txtCPActualizarTelefono.Text = cliente.Telefono;
                    cmbCPActualizarCiudad.Text = cliente.IdCiudad.ToString();
                    cmbCPActualizarEstado.Text = cliente.EstadoCliente.ToString();
                    txtCPActualizarNombreCont.Text = cliente.NombreContacto;
                    txtCPActualizarApPaternoCont.Text = cliente.ApPatContacto;
                    txtCPActualizarApMatCont.Text = cliente.ApMatContacto;
                    txtCPActualizarCorreoCont.Text = cliente.CorreoContacto;
                }
                else if (tipo.Equals("Provedores"))
                {
                    Provedor provedor = new Provedor() { RFC = dgvActualizar.Rows[e.RowIndex].Cells["rfc"].Value.ToString() };
                    provedor = (Provedor)datos.cargarDatosCliPro(provedor, tipo);
                    txtCPActualizarRFC.Text = provedor.RFC;
                    txtCPActualizarNombre.Text = provedor.Nombre;
                    txtCPActualizarCalle.Text = provedor.Calle;
                    txtCPActualizarNExt.Text = provedor.NExt;
                    txtCPActualizarTelefono.Text = provedor.Telefono;
                    cmbCPActualizarCiudad.Text = provedor.IdCiudad.ToString();
                    cmbCPActualizarEstado.Text = provedor.EstadoProvedor.ToString();
                    txtCPActualizarNombreCont.Text = provedor.NombreContacto;
                    txtCPActualizarApPaternoCont.Text = provedor.ApPatContacto;
                    txtCPActualizarApMatCont.Text = provedor.ApMatContacto;
                    txtCPActualizarCorreoCont.Text = provedor.CorreoContacto;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            

        }
    }
}
