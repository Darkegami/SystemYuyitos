using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuyitosLibrary
{
    public class RecepcionCompra
    {
        private string _id_recepcion_compra;
        private DateTime _fecha_recepcion;
        private string _comentarios;
        private string _id_orden_compra;
        private string _rut_administrador;
        private int _id_estado_recepcion;
        private string _estado_recepcion;

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

        public DateTime Fecha_recepcion
        {
            get
            {
                return _fecha_recepcion;
            }

            set
            {
                _fecha_recepcion = value;
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

        public string Estado_recepcion
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

        public string Id_orden_compra
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
    }
}
