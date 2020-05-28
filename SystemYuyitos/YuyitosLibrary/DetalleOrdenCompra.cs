using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuyitosLibrary
{
    public class DetalleOrdenCompra
    {
        private string _id_orden;
        private string _id_producto;
        private int _cantidad_pack;
        private int _precio_compra_total;
        private string _producto;
        private string _proveedor;
        private int _id_proveedor;
        private int _id_familia;

        public string Id_orden
        {
            get
            {
                return _id_orden;
            }

            set
            {
                _id_orden = value;
            }
        }

        public string Id_producto
        {
            get
            {
                return _id_producto;
            }

            set
            {
                _id_producto = value;
            }
        }

        public int Cantidad_pack
        {
            get
            {
                return _cantidad_pack;
            }

            set
            {
                _cantidad_pack = value;
            }
        }

        public int Precio_compra_total
        {
            get
            {
                return _precio_compra_total;
            }

            set
            {
                _precio_compra_total = value;
            }
        }

        public string Producto
        {
            get
            {
                return _producto;
            }

            set
            {
                _producto = value;
            }
        }

        public string Proveedor
        {
            get
            {
                return _proveedor;
            }

            set
            {
                _proveedor = value;
            }
        }

        public int Id_proveedor
        {
            get
            {
                return _id_proveedor;
            }

            set
            {
                _id_proveedor = value;
            }
        }

        public int Id_familia
        {
            get
            {
                return _id_familia;
            }

            set
            {
                _id_familia = value;
            }
        }
    }
}
