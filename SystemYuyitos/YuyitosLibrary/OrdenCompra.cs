using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuyitosLibrary
{
    public class OrdenCompra
    {
        private string _id_orden_pedido;
        private DateTime _fecha_orden;
        private DateTime _fecha_entrega;
        private int _valor_final;
        private string _rut_administrador;
        private int _id_estado_orden;
        private string _estado_orden;

        public DateTime Fecha_orden
        {
            get
            {
                return _fecha_orden;
            }

            set
            {
                _fecha_orden = value;
            }
        }

        public DateTime Fecha_entrega
        {
            get
            {
                return _fecha_entrega;
            }

            set
            {
                _fecha_entrega = value;
            }
        }

        public int Valor_final
        {
            get
            {
                return _valor_final;
            }

            set
            {
                _valor_final = value;
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

        public int Id_estado_orden
        {
            get
            {
                return _id_estado_orden;
            }

            set
            {
                _id_estado_orden = value;
            }
        }

        public string Id_orden_pedido
        {
            get
            {
                return _id_orden_pedido;
            }

            set
            {
                _id_orden_pedido = value;
            }
        }

        public string Estado_orden
        {
            get
            {
                return _estado_orden;
            }

            set
            {
                _estado_orden = value;
            }
        }
    }
}
