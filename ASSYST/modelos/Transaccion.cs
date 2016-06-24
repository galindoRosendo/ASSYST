using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASSYST.modelos
{
    public class Transaccion
    {
        #region Atributos
        private int idTransaccion;
        private string rfc;
        private string folio;
        private int idEmpleado;
        private string fechaTransaccion;
        private int idMetodoPago;
        private int idBancho;
        private double monto;
        private char estadoTransaccion;
        private string tipoTransaccion;
        #endregion

        #region Propiedades

        public int IdTransaccion
        {
            get { return idTransaccion; }
            set { idTransaccion = value; }
        }

        public string RFC
        {
            get { return rfc; }
            set { rfc = value; }
        }

        public string Folio
        {
            get { return folio; }
            set { folio = value; }
        }

        public int IdEmpleado
        {
            get { return idEmpleado; }
            set { idEmpleado = value; }
        }

        public string FechaTransaccion
        {
            get { return fechaTransaccion; }
            set { fechaTransaccion = value; }
        }

        public int IdMetodoPago
        {
            get { return idMetodoPago; }
            set { idMetodoPago = value; }
        }

        public int IdBanco
        {
            get { return idBancho; }
            set { idBancho = value; }
        }

        public double Monto
        {
            get { return monto; }
            set { monto = value; }
        }

        public char EstadoTransaccion
        {
            get { return estadoTransaccion; }
            set { estadoTransaccion = value; }
        }

        public string TipoTransaccion
        {
            get { return tipoTransaccion; }
            set { tipoTransaccion = value; }
        }
        #endregion

    }
}
