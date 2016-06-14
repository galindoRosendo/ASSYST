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

        #endregion

    }
}
