using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuyitosLibrary
{
    class RecepcionCompra
    {
        private string _id_recepcion_compra;
        private DateTime _fecha;
        private string _comentarios;
        private EstadoRecepcion _estado_recepcion;
        private int _id_estado_recepcion;
        private int _id_orden_compra;
        private string _rut_administrador;

        public string Id_recepcion_compra
        {
            get
            {
                return _id_recepcion_compra;
            }

            set
            {
                _id_recepcion_compra = value;
            }
        }

        public DateTime Fecha
        {
            get
            {
                return _fecha;
            }

            set
            {
                _fecha = value;
            }
        }

        public string Comentarios
        {
            get
            {
                return _comentarios;
            }

            set
            {
                _comentarios = value;
            }
        }

        internal EstadoRecepcion Estado_recepcion
        {
            get
            {
                return _estado_recepcion;
            }

            set
            {
                _estado_recepcion = value;
            }
        }

        public int Id_estado_recepcion
        {
            get
            {
                return _id_estado_recepcion;
            }

            set
            {
                _id_estado_recepcion = value;
            }
        }

        public int Id_orden_compra
        {
            get
            {
                return _id_orden_compra;
            }

            set
            {
                _id_orden_compra = value;
            }
        }

        public string Rut_administrador
        {
            get
            {
                return _rut_administrador;
            }

            set
            {
                _rut_administrador = value;
            }
        }
    }
}
