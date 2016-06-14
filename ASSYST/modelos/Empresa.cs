using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASSYST.modelos
{
    public class Empresa
    {
        public Empresa(string inRFC)
        {
            RFC = inRFC;
        }

        #region Atributos
        private int idEmpresa;
        private string nombreEmpresa;
        private string rfc;
        private string telefono;
        private string calle;
        private string nExterior;
        private int idCiudad;
        #endregion

        #region Propiedades
        public int IdEmpresa
        {
            get { return idEmpresa; }
            set { idEmpresa = value; }
        }
        
        public string NombreEmpresa
        {
            get { return nombreEmpresa; }
            set { nombreEmpresa = value; }
        }
        
        public string RFC
        {
            get { return rfc; }
            set { rfc = value; }
        }
        
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        
        public string Calle
        {
            get { return calle; }
            set { calle = value; }
        }
        
        public string NExterior
        {
            get { return nExterior; }
            set { nExterior = value; }
        }

        public int IdCiudad
        {
            get { return idCiudad; }
            set { idCiudad = value; }
        }
        #endregion

    }
}
