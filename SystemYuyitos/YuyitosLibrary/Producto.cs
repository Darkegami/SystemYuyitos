using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuyitosLibrary
{
    public class Producto
    {
        private int _id_producto;
        private string _nombreProd;
        private int _precio_venta;
        private int _precio_compra;
        private int _stock;
        private DateTime _fecha_elaboracion;
        private DateTime _fecha_vencimiento;
        private Familia _familia;
        private Proveedor _proveedor;
        private TipoProducto _tipo_producto;
        private int _id_familia;
        private int _id_proveedor;
        private int _id_tipo_prod;


        public int Id_Familia
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

        public int Id_Proveedor
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
        public int Id_TipoProd
        {
            get
            {
                return _id_tipo_prod;
            }

            set
            {
                _id_tipo_prod= value;
            }
        }



        public int Id_producto
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

        public string NombreProd
        {
            get
            {
                return _nombreProd;
            }

            set
            {
                _nombreProd = value;
            }
        }

        public int Precio_venta
        {
            get
            {
                return _precio_venta;
            }

            set
            {
                _precio_venta = value;
            }
        }

        public DateTime Fecha_elaboracion
        {
            get
            {
                return _fecha_elaboracion;
            }

            set
            {
                _fecha_elaboracion = value;
            }
        }

        public DateTime Fecha_vencimiento
        {
            get
            {
                return _fecha_vencimiento;
            }

            set
            {
                _fecha_vencimiento = value;
            }
        }

        public int Precio_compra
        {
            get
            {
                return _precio_compra;
            }

            set
            {
                _precio_compra = value;
            }
        }

        public Familia Familia
        {
            get
            {
                return _familia;
            }

            set
            {
                _familia = value;
            }
        }

        public Proveedor Proveedor
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

        public TipoProducto Tipo_producto
        {
            get
            {
                return _tipo_producto;
            }

            set
            {
                _tipo_producto = value;
            }
        }

        public int Stock
        {
            get
            {
                return _stock;
            }

            set
            {
                _stock = value;
            }
        }
    }
}
