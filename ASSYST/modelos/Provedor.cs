using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASSYST.modelos
{
    public class Provedor
    {

        #region atributos
        private int idProvedor;
        private string rfc;
        private string nombre;
        private string calle;
        private string nExt;
        private string telefono;
        private string nombreContacto;
        private string apPatContacto;
        private string apMatContacto;
        private string correoContacto;
        private int idCiudad;
        private char estadoProvedor;
        #endregion 

        #region Propiedades
        public int Idcliente
        {
            get { return idProvedor; }
            set { idProvedor = value; }
        }

        public string RFC
        {
            get { return rfc; }
            set { rfc = value; }
        }
        
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Calle
        {
            get { return calle; }
            set { calle = value; }
        }

        public string NExt
        {
            get { return nExt; }
            set { nExt = value; }
        }
        
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        
        public string NombreContacto
        {
            get { return nombreContacto; }
            set { nombreContacto = value; }
        }
        
        public string ApPatContacto
        {
            get { return apPatContacto; }
            set { apPatContacto = value; }
        }

        public string ApMatContacto
        {
            get { return apMatContacto; }
            set { apMatContacto = value; }
        }
        
        public string CorreoContacto
        {
            get { return correoContacto; }
            set { correoContacto = value; }
        }
        
        public int IdCiudad
        {
            get { return idCiudad; }
            set { idCiudad = value; }
        }
        

        public char EstadoProvedor
        {
            get { return estadoProvedor; }
            set { estadoProvedor = value; }
        }

        #endregion

    }
}
