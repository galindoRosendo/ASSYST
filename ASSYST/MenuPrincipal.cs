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
        #region Variables
        Empleado empleadoActual;
        Empresa empresaActual;
        DataTable cuentas, clientes, provedores;
        database datos;
        string tipo = "";
        #endregion

        public MenuPrincipal(Empleado empleado, Empresa empresa)
        {
            InitializeComponent();
            empleadoActual = empleado;
            empresaActual = empresa;
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            datos = new database();
            lblNombreEmpleado.Text = empleadoActual.NombreCompleto;
            lblNombreEmpresa.Text = empresaActual.NombreEmpresa;
            cuentas = datos.listaCuentas();
            clientes = datos.listaClientes();
            provedores = datos.listaProvedores();
            dgvCuentasEstados.DataSource = cuentas;
            dgvIngresosAbonosClientes.DataSource = clientes;
            dgvIngresosCargosClientes.DataSource = clientes;
            dgvEgresosAbonosProvedores.DataSource = provedores;
            dgvEgresosCargosProvedores.DataSource = provedores;

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
                    PDatos.DatosCliente = new Cliente() { RFC = dgvActualizar.Rows[e.RowIndex].Cells["rfc"].Value.ToString() };
                    PDatos.DatosCliente = (Cliente)datos.cargarDatosCliPro(PDatos.DatosCliente, tipo);
                    txtCPActualizarRFC.Text = PDatos.DatosCliente.RFC;
                    txtCPActualizarNombre.Text = PDatos.DatosCliente.Nombre;
                    txtCPActualizarCalle.Text = PDatos.DatosCliente.Calle;
                    txtCPActualizarNExt.Text = PDatos.DatosCliente.NExt;
                    txtCPActualizarTelefono.Text = PDatos.DatosCliente.Telefono;
                    cmbCPActualizarCiudad.Text = PDatos.DatosCliente.IdCiudad.ToString();
                    cmbCPActualizarEstado.Text = PDatos.DatosCliente.EstadoCliente.ToString();
                    txtCPActualizarNombreCont.Text = PDatos.DatosCliente.NombreContacto;
                    txtCPActualizarApPaternoCont.Text = PDatos.DatosCliente.ApPatContacto;
                    txtCPActualizarApMatCont.Text = PDatos.DatosCliente.ApMatContacto;
                    txtCPActualizarCorreoCont.Text = PDatos.DatosCliente.CorreoContacto;
                }
                else if (tipo.Equals("Provedores"))
                {
                    PDatos.DatosProvedor = new Provedor() { RFC = dgvActualizar.Rows[e.RowIndex].Cells["rfc"].Value.ToString() };
                    PDatos.DatosProvedor = (Provedor)datos.cargarDatosCliPro(PDatos.DatosProvedor, tipo);
                    txtCPActualizarRFC.Text = PDatos.DatosProvedor.RFC;
                    txtCPActualizarNombre.Text = PDatos.DatosProvedor.Nombre;
                    txtCPActualizarCalle.Text = PDatos.DatosProvedor.Calle;
                    txtCPActualizarNExt.Text = PDatos.DatosProvedor.NExt;
                    txtCPActualizarTelefono.Text = PDatos.DatosProvedor.Telefono;
                    cmbCPActualizarCiudad.Text = PDatos.DatosProvedor.IdCiudad.ToString();
                    cmbCPActualizarEstado.Text = PDatos.DatosProvedor.EstadoProvedor.ToString();
                    txtCPActualizarNombreCont.Text = PDatos.DatosProvedor.NombreContacto;
                    txtCPActualizarApPaternoCont.Text = PDatos.DatosProvedor.ApPatContacto;
                    txtCPActualizarApMatCont.Text = PDatos.DatosProvedor.ApMatContacto;
                    txtCPActualizarCorreoCont.Text = PDatos.DatosProvedor.CorreoContacto;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        private void btnDatosCPActActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                database datos = new database();
                DataTable resultadoSP = new DataTable("ResultadoSPActualizarCP");
                if (tipo.Equals("Clientes"))
                {
                    PDatos.DatosCliente = new Cliente();
                    PDatos.DatosCliente.RFC = txtCPActualizarRFC.Text;
                    PDatos.DatosCliente.Nombre =txtCPActualizarNombre.Text;
                    PDatos.DatosCliente.Calle = txtCPActualizarCalle.Text;
                    PDatos.DatosCliente.NExt = txtCPActualizarNExt.Text;
                    PDatos.DatosCliente.Telefono = txtCPActualizarTelefono.Text;
                    PDatos.DatosCliente.IdCiudad =Convert.ToInt32(cmbCPActualizarCiudad.Text);
                    PDatos.DatosCliente.EstadoCliente = Convert.ToChar(cmbCPActualizarEstado.Text);
                    PDatos.DatosCliente.NombreContacto = txtCPActualizarNombreCont.Text;
                    PDatos.DatosCliente.ApPatContacto = txtCPActualizarApPaternoCont.Text;
                    PDatos.DatosCliente.ApMatContacto = txtCPActualizarApMatCont.Text;
                    PDatos.DatosCliente.CorreoContacto = txtCPActualizarCorreoCont.Text;
                    resultadoSP = datos.actualizarCP(PDatos.DatosCliente);

                }
                else if (tipo.Equals("Provedores"))
                {
                    PDatos.DatosProvedor = new Provedor();
                    PDatos.DatosProvedor.RFC = txtCPActualizarRFC.Text;
                    PDatos.DatosProvedor.Nombre = txtCPActualizarNombre.Text;
                    PDatos.DatosProvedor.Calle = txtCPActualizarCalle.Text;
                    PDatos.DatosProvedor.NExt = txtCPActualizarNExt.Text;
                    PDatos.DatosProvedor.Telefono = txtCPActualizarTelefono.Text;
                    PDatos.DatosProvedor.IdCiudad = Convert.ToInt32(cmbCPActualizarCiudad.Text);
                    PDatos.DatosProvedor.EstadoProvedor = Convert.ToChar(cmbCPActualizarEstado.Text);
                    PDatos.DatosProvedor.NombreContacto = txtCPActualizarNombreCont.Text;
                    PDatos.DatosProvedor.ApPatContacto = txtCPActualizarApPaternoCont.Text;
                    PDatos.DatosProvedor.ApMatContacto = txtCPActualizarApMatCont.Text;
                    PDatos.DatosProvedor.CorreoContacto = txtCPActualizarCorreoCont.Text;

                    resultadoSP = datos.actualizarCP(PDatos.DatosProvedor);
                }

                MessageBox.Show(resultadoSP.Rows[0]["MENSAJE"].ToString(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                //if (resultadoSP.Rows[0]["MENSAJE"].Equals("CLIENTE ACTUALIZADO")) 
                //{
                //}
                //else if (resultadoSP.Rows[0]["MENSAJE"].Equals("CLIENTE INEXISTENTE")) 
                //{
                //}
                //else if (resultadoSP.Rows[0]["MENSAJE"].Equals("PROVEDOR ACTUALIZADO")) 
                //{
                //}
                //else if (resultadoSP.Rows[0]["MENSAJE"].Equals("PROVEDOR INEXISTENTE")) 
                //{
                //}

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnCuentasEstadosActualizar_Click(object sender, EventArgs e)
        {
            datos = new database();
            cuentas = datos.listaCuentas();
            dgvCuentasEstados.DataSource = cuentas;
        }
    }
}
