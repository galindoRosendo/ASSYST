using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASSYST.modelos
{
    public class Empleado
    {
        public Empleado(string email,string contra)
        {
            CorreoE = email;
            Contrasenia = contra;
        }

        #region Atributos
        private int idEmpleado;
        private string nombre;
        private string apPaterno;
        private string apMaterno;
        private string correoE;
        private string contrasenia;
        private string departamento;
        private char estadoEmpleado;
        private int idSucursal;
        #endregion

        #region Propiedades
        public int IdEmpleado
        {
            get { return idEmpleado; }
            set { idEmpleado = value; }
        }
       

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        

        public string ApPaterno
        {
            get { return apPaterno; }
            set { apPaterno = value; }
        }
        

        public string ApMaterno
        {
            get { return apMaterno; }
            set { apMaterno = value; }
        }
        

        public string CorreoE
        {
            get { return correoE; }
            set { correoE = value; }
        }
        

        public string Contrasenia
        {
            get { return contrasenia; }
            set { contrasenia = value; }
        }
        

        public string Departamento
        {
            get { return departamento; }
            set { departamento = value; }
        }
        

        public char EstadoEmpleado
        {
            get { return estadoEmpleado; }
            set { estadoEmpleado = value; }
        }

        

        public int IdSucursal
        {
            get { return idSucursal; }
            set { idSucursal = value; }
        }
        #endregion

        public string NombreCompleto
        {
            get
            {
                return nombre + " " + apPaterno + " " + apMaterno;
            }
        }

    }
}
