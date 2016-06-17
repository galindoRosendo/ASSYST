using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using ASSYST.modelos;

namespace ASSYST.modelos
{
    public class database
    {

        public database() 
        {
            conn = new MySqlConnection(conString);
        }

        #region Variables
        private string log = "";
        static string conString = "server=localhost;uid=administrador;pwd=ALESAN2016sys;database=alesandb;";
        MySqlConnection conn;
        
        #endregion

        #region Metodos

        public string Log
        {
            get { return log; }
            set { log = value; }
        }
       
        public Empleado login(Empleado empLogin)
        {
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                cmd = new MySqlCommand("SP_LogInUsuario", conn);
                cmd.Parameters.Add(new MySqlParameter("@SPcorreoE", empLogin.CorreoE));
                cmd.Parameters.Add(new MySqlParameter("@SPcontrasenia", empLogin.Contrasenia));
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                da.Fill(dt);
                empLogin.Nombre = dt.Rows[0]["idempleado"].ToString();
                empLogin.Nombre=dt.Rows[0]["nombre_s"].ToString();
                empLogin.ApPaterno = dt.Rows[0]["apPaterno"].ToString();
                empLogin.ApMaterno = dt.Rows[0]["apMaterno"].ToString();
                empLogin.CorreoE = dt.Rows[0]["correoElectronico"].ToString();
                empLogin.Contrasenia = dt.Rows[0]["contrasenia"].ToString();
                empLogin.Departamento = dt.Rows[0]["departamento"].ToString();
                empLogin.EstadoEmpleado = Convert.ToChar(dt.Rows[0]["estadoEmpleado"]);
                empLogin.IdSucursal = Convert.ToInt32(dt.Rows[0]["idsucursal"]);
                log = dt.Rows[0]["Mensaje"].ToString();
            }
            catch (MySqlException MySQLex)
            {
                log = MySQLex.Message;
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
            return empLogin;
        }

        public DataTable listaEmpresas() 
        {
            DataTable dt = new DataTable("Empresas");
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd = new MySqlCommand("SELECT Nombre,RFC FROM alesandb.empresa;", conn);// Prepared statement SELECT * FROM admin WHERE admin_username=@val1 AND admin_password=PASSWORD(@val2)
                MySqlDataAdapter da = new MySqlDataAdapter();
                conn.Open();
                cmd.Prepare();
                da.SelectCommand = cmd;
                da.Fill(dt);
            }
            catch (MySqlException MSQLEx)
            {

                log = MSQLEx.Message;
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }


            return dt; 
        }

        public Empresa seleccionEmpresa(Empresa empresa)
        {
            DataTable dt = new DataTable("DatosEmpresa");
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd = new MySqlCommand("SELECT idempresa,nombre,rfc,telefono,calle,numExt,idCiudad FROM alesandb.empresa LIMIT 1;", conn);// Prepared statement SELECT * FROM admin WHERE admin_username=@val1 AND admin_password=PASSWORD(@val2)
                MySqlDataAdapter da = new MySqlDataAdapter();
                conn.Open();
                cmd.Prepare();
                da.SelectCommand = cmd;
                da.Fill(dt);
                empresa.IdEmpresa = Convert.ToInt32(dt.Rows[0]["idempresa"]);
                empresa.NombreEmpresa = dt.Rows[0]["nombre"].ToString();
                empresa.RFC = dt.Rows[0]["rfc"].ToString();
                empresa.Telefono = dt.Rows[0]["telefono"].ToString();
                empresa.Calle = dt.Rows[0]["calle"].ToString();
                empresa.NExterior = dt.Rows[0]["numExt"].ToString();
                empresa.IdCiudad = Convert.ToInt32(dt.Rows[0]["idCiudad"]);
            }
            catch (MySqlException MSQLEx)
            {

                log = MSQLEx.Message;
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }


            return empresa; 
        }

        public DataTable listaCP(string tipoBusqueda,string parametroBusqueda,string valorParametroBusqueda) 
        {
            DataTable dt = new DataTable("ClientesProvedores");
            MySqlCommand cmd = new MySqlCommand();
            string query = "";
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter();
                if (tipoBusqueda.Equals("Clientes"))
                {
                    switch (parametroBusqueda)
                    {
                        case "Todos":
                            query = "SELECT * "+
                                    "FROM alesandb.clientes;";
                            cmd = new MySqlCommand(query, conn);
                            conn.Open();
                            cmd.Prepare();
                            da.SelectCommand = cmd;
                            da.Fill(dt);
                            break;
                        case "RFC":
                            query = "SELECT * "+
                                    "FROM alesandb.clientes "+
                                    "WHERE RFC = @SPRFC;";
                            cmd = new MySqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@SPRFC", valorParametroBusqueda);
                            conn.Open();
                            cmd.Prepare();
                            da.SelectCommand = cmd;
                            da.Fill(dt);
                            break;
                        case "Nombre":
                            query = "SELECT * "+
                                    "FROM alesandb.clientes "+
                                    "WHERE nombre = @SPnombre;";
                            cmd = new MySqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@SPnombre", valorParametroBusqueda);
                            conn.Open();
                            cmd.Prepare();
                            da.SelectCommand = cmd;
                            da.Fill(dt);
                            break;
                        default:
                            break;
                    }
                    
                }
                else if (tipoBusqueda.Equals("Provedores"))
                {
                    switch (parametroBusqueda)
                    {
                        case "Todos":
                            query = "SELECT * "+
                                    "FROM alesandb.provedores;";
                            cmd = new MySqlCommand(query, conn);
                            conn.Open();
                            cmd.Prepare();
                            da.SelectCommand = cmd;
                            da.Fill(dt);
                            break;
                        case "RFC":
                            query = "SELECT * " +
                                    "FROM alesandb.provedores " +
                                    "WHERE RFC = @SPRFC;";
                            cmd = new MySqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@SPRFC", valorParametroBusqueda);
                            conn.Open();
                            cmd.Prepare();
                            da.SelectCommand = cmd;
                            da.Fill(dt);
                            break;
                        case "Nombre":
                            query = "SELECT * " +
                                    "FROM alesandb.provedores " +
                                    "WHERE nombre = @SPnombre;";
                            cmd = new MySqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@SPnombre", valorParametroBusqueda);
                            conn.Open();
                            cmd.Prepare();
                            da.SelectCommand = cmd;
                            da.Fill(dt);
                            break;
                        default:
                            break;
                    }
                }
                else if (tipoBusqueda.Equals("Ambos"))
                {
                    switch (parametroBusqueda)
                    {
                        case "Todos":
                            query = "SELECT *,'PROVEDOR' AS Tipo "+
                                    "FROM alesandb.provedores "+
                                    "UNION "+
                                    "SELECT * ,'CLIENTE' AS Tipo "+
                                    "FROM alesandb.clientes;";
                            cmd = new MySqlCommand(query, conn);
                            conn.Open();
                            cmd.Prepare();
                            da.SelectCommand = cmd;
                            da.Fill(dt);
                            break;
                        case "RFC":
                            query = "SELECT *,'PROVEDOR' AS Tipo "+
                                    "FROM alesandb.provedores "+
                                    "WHERE RFC = @SPRFC "+
                                    "UNION "+
                                    "SELECT *,'CLIENTE' AS Tipo "+
                                    "FROM alesandb.clientes "+
                                    "WHERE RFC = @SPRFC2;";
                            cmd = new MySqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@SPRFC", valorParametroBusqueda);
                            cmd.Parameters.AddWithValue("@SPRFC2", valorParametroBusqueda);
                            conn.Open();
                            cmd.Prepare();
                            da.SelectCommand = cmd;
                            da.Fill(dt);
                            break;
                        case "Nombre":
                            query = "SELECT *,'PROVEDOR' AS Tipo "+
                                    "FROM alesandb.provedores "+
                                    "WHERE nombre = @SPnombre "+
                                    "UNION "+
                                    "SELECT *,'CLIENTE' AS Tipo "+
                                    "FROM alesandb.clientes "+
                                    "WHERE nombre = @SPnombre2;";
                            cmd = new MySqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@SPnombre", valorParametroBusqueda);
                            cmd.Parameters.AddWithValue("@SPnombre2", valorParametroBusqueda);
                            conn.Open();
                            cmd.Prepare();
                            da.SelectCommand = cmd;
                            da.Fill(dt);
                            break;
                        default:
                            break;
                    }
                }
                else { log = "Parametro no valido"; }
                
            }
            catch (MySqlException MSQLEx)
            {

                log = MSQLEx.Message;
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
            return dt; 

        }

        public DataTable insertarClienteProvedor(object empresa) 
        {
            DataTable dt= new DataTable("Resultado");
            MySqlCommand cmd= new MySqlCommand();
            string query = "";
            string tipoEmp = "";
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter();
                //Datos para comprobar clase de objeto empresa
                Type cli = typeof(Cliente);
                Type pro = typeof(Provedor);
                Type emp = empresa.GetType();

                if (emp.Equals(cli))
                {
                    tipoEmp = "CLIENTE";
                    Cliente empAct =(Cliente)empresa;
                    query = "CALL `alesandb`.`SP_CrearClienteProvedor`(@tipo, @rfc, @nombre, @calle, @nExt,@telefono, @correoContacto, @nombreContacto, @apPatContacto, @apMatContacto, @idCiudad);";
                    cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@tipo", tipoEmp);
                    cmd.Parameters.AddWithValue("@rfc",empAct.RFC);
                    cmd.Parameters.AddWithValue("@nombre",empAct.Nombre);
                    cmd.Parameters.AddWithValue("@calle",empAct.Calle);
                    cmd.Parameters.AddWithValue("@nExt",empAct.NExt);
                    cmd.Parameters.AddWithValue("@telefono",empAct.Telefono);
                    cmd.Parameters.AddWithValue("@correoContacto",empAct.CorreoContacto);
                    cmd.Parameters.AddWithValue("@nombreContacto",empAct.NombreContacto);
                    cmd.Parameters.AddWithValue("@apPatContacto",empAct.ApPatContacto);
                    cmd.Parameters.AddWithValue("@apMatContacto",empAct.ApMatContacto);
                    cmd.Parameters.AddWithValue("@idCiudad",empAct.IdCiudad);
                    conn.Open();
                    cmd.Prepare();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                    Log = dt.Rows[0]["MENSAJE"].ToString();
                }
                else if (emp.Equals(pro))
                {
                    tipoEmp = "PROVEDOR";
                    Provedor empAct = (Provedor)empresa;
                    query = "CALL `alesandb`.`SP_CrearClienteProvedor`(@tipo, @rfc, @nombre, @calle, @nExt,@telefono, @correoContacto, @nombreContacto, @apPatContacto, @apMatContacto, @idCiudad);";
                    cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@tipo", tipoEmp);
                    cmd.Parameters.AddWithValue("@rfc", empAct.RFC);
                    cmd.Parameters.AddWithValue("@nombre", empAct.Nombre);
                    cmd.Parameters.AddWithValue("@calle", empAct.Calle);
                    cmd.Parameters.AddWithValue("@nExt", empAct.NExt);
                    cmd.Parameters.AddWithValue("@telefono", empAct.Telefono);
                    cmd.Parameters.AddWithValue("@correoContacto", empAct.CorreoContacto);
                    cmd.Parameters.AddWithValue("@nombreContacto", empAct.NombreContacto);
                    cmd.Parameters.AddWithValue("@apPatContacto", empAct.ApPatContacto);
                    cmd.Parameters.AddWithValue("@apMatContacto", empAct.ApMatContacto);
                    cmd.Parameters.AddWithValue("@idCiudad", empAct.IdCiudad);
                    conn.Open();
                    cmd.Prepare();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                    Log = dt.Rows[0]["MENSAJE"].ToString();
                    
                }
                else { log = "Ningun tipo"; }

                
            }
            catch (MySqlException ex)
            {
                log = ex.Message;
            }
            finally 
            {
                conn.Close();
                cmd.Dispose();
            }
            return dt;
        }

        public object cargarDatosCliPro(object empresaParcial,string tipo)
        {
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                if (tipo.Equals("Clientes")) 
                {
                    Cliente clienteParcial =(Cliente)empresaParcial;
                    cmd = new MySqlCommand("SELECT rfc,nombre,calle,numExt,telefono,estadoCliente,contactoEmail,contactoNombre_s,contactoApPaterno,contactoApMaterno,idCiudad FROM alesandb.clientes WHERE rfc=@SPRFC;", conn);
                    cmd.Parameters.Add(new MySqlParameter("@SPRFC", clienteParcial.RFC));
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                    clienteParcial.RFC = dt.Rows[0]["rfc"].ToString();
                    clienteParcial.Nombre = dt.Rows[0]["nombre"].ToString();
                    clienteParcial.Calle = dt.Rows[0]["calle"].ToString();
                    clienteParcial.NExt = dt.Rows[0]["numExt"].ToString();
                    clienteParcial.Telefono = dt.Rows[0]["telefono"].ToString();
                    clienteParcial.EstadoCliente = Convert.ToChar(dt.Rows[0]["estadoCliente"].ToString());
                    clienteParcial.CorreoContacto = dt.Rows[0]["contactoEmail"].ToString();
                    clienteParcial.NombreContacto = dt.Rows[0]["contactoNombre_s"].ToString();
                    clienteParcial.ApPatContacto = dt.Rows[0]["contactoApPaterno"].ToString();
                    clienteParcial.ApMatContacto = dt.Rows[0]["contactoApMaterno"].ToString();
                    clienteParcial.IdCiudad = Convert.ToInt32(dt.Rows[0]["idCiudad"].ToString());
                    empresaParcial = (object)clienteParcial;
                }
                else if (tipo.Equals("Provedores")) 
                {
                    Provedor provParcial = (Provedor)empresaParcial;
                    cmd = new MySqlCommand("SELECT rfc,nombre,calle,numExt,telefono,estadoProvedor,contactoEmail,contactoNombre_s,contactoApPaterno,contactoApMaterno,idCiudad FROM alesandb.provedores WHERE rfc=@SPRFC;", conn);
                    cmd.Parameters.Add(new MySqlParameter("@SPRFC", provParcial.RFC));
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                    provParcial.RFC = dt.Rows[0]["rfc"].ToString();
                    provParcial.Nombre = dt.Rows[0]["nombre"].ToString();
                    provParcial.Calle = dt.Rows[0]["calle"].ToString();
                    provParcial.NExt = dt.Rows[0]["numExt"].ToString();
                    provParcial.Telefono = dt.Rows[0]["telefono"].ToString();
                    provParcial.EstadoProvedor = Convert.ToChar(dt.Rows[0]["estadoProvedor"].ToString());
                    provParcial.CorreoContacto = dt.Rows[0]["contactoEmail"].ToString();
                    provParcial.NombreContacto = dt.Rows[0]["contactoNombre_s"].ToString();
                    provParcial.ApPatContacto = dt.Rows[0]["contactoApPaterno"].ToString();
                    provParcial.ApMatContacto = dt.Rows[0]["contactoApMaterno"].ToString();
                    provParcial.IdCiudad = Convert.ToInt32(dt.Rows[0]["idCiudad"].ToString());
                    empresaParcial = (object)provParcial;
                }
                
            }
            catch (MySqlException MySQLex)
            {
                log = MySQLex.Message;
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
            return empresaParcial;
        }

        public DataTable actualizarCP(object empresa)
        {
            DataTable dt = new DataTable("Resultado");
            MySqlCommand cmd = new MySqlCommand();
            string query = "";
            string tipoEmp = "";
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter();
                //Datos para comprobar clase de objeto empresa
                Type cli = typeof(Cliente);
                Type pro = typeof(Provedor);
                Type emp = empresa.GetType();

                if (emp.Equals(cli))
                {
                    tipoEmp = "CLIENTE";
                    Cliente empAct = (Cliente)empresa;
                    query = "CALL `alesandb`.`SP_ActualizarClienteProvedor`(@tipo, @rfc, @nombre, @calle, @nExt,@telefono, @correoContacto, @nombreContacto, @apPatContacto, @apMatContacto, @idCiudad, @estado);";
                    cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@tipo", tipoEmp);
                    cmd.Parameters.AddWithValue("@rfc", empAct.RFC);
                    cmd.Parameters.AddWithValue("@nombre", empAct.Nombre);
                    cmd.Parameters.AddWithValue("@calle", empAct.Calle);
                    cmd.Parameters.AddWithValue("@nExt", empAct.NExt);
                    cmd.Parameters.AddWithValue("@telefono", empAct.Telefono);
                    cmd.Parameters.AddWithValue("@correoContacto", empAct.CorreoContacto);
                    cmd.Parameters.AddWithValue("@nombreContacto", empAct.NombreContacto);
                    cmd.Parameters.AddWithValue("@apPatContacto", empAct.ApPatContacto);
                    cmd.Parameters.AddWithValue("@apMatContacto", empAct.ApMatContacto);
                    cmd.Parameters.AddWithValue("@idCiudad", empAct.IdCiudad);
                    cmd.Parameters.AddWithValue("@estado", empAct.EstadoCliente);
                    conn.Open();
                    cmd.Prepare();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                    Log = dt.Rows[0]["MENSAJE"].ToString();
                }
                else if (emp.Equals(pro))
                {
                    tipoEmp = "PROVEDOR";
                    Provedor empAct = (Provedor)empresa;
                    query = "CALL `alesandb`.`SP_ActualizarClienteProvedor`(@tipo, @rfc, @nombre, @calle, @nExt,@telefono, @correoContacto, @nombreContacto, @apPatContacto, @apMatContacto, @idCiudad,@estado);";
                    cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@tipo", tipoEmp);
                    cmd.Parameters.AddWithValue("@rfc", empAct.RFC);
                    cmd.Parameters.AddWithValue("@nombre", empAct.Nombre);
                    cmd.Parameters.AddWithValue("@calle", empAct.Calle);
                    cmd.Parameters.AddWithValue("@nExt", empAct.NExt);
                    cmd.Parameters.AddWithValue("@telefono", empAct.Telefono);
                    cmd.Parameters.AddWithValue("@correoContacto", empAct.CorreoContacto);
                    cmd.Parameters.AddWithValue("@nombreContacto", empAct.NombreContacto);
                    cmd.Parameters.AddWithValue("@apPatContacto", empAct.ApPatContacto);
                    cmd.Parameters.AddWithValue("@apMatContacto", empAct.ApMatContacto);
                    cmd.Parameters.AddWithValue("@idCiudad", empAct.IdCiudad);
                    cmd.Parameters.AddWithValue("@estado", empAct.EstadoProvedor);
                    conn.Open();
                    cmd.Prepare();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                    Log = dt.Rows[0]["MENSAJE"].ToString();

                }
                else { log = "Ningun tipo"; }


            }
            catch (MySqlException ex)
            {
                log = ex.Message;
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
            }
            return dt;
        }
        #endregion

    }
}
