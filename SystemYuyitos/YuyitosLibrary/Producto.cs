﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuyitosLibrary
{
    public class Producto
    {
        private string _id_producto;
        private string _nombreProd;
        private int _precio_venta;
        private int _precio_compra;
        private int _stock;
        private DateTime _fecha_elaboracion;
        private DateTime _fecha_vencimiento;
        private DateTime _fecha_ingreso;
        private Familia _familia;
        private Proveedor _proveedor;
        private TipoProducto _tipo_producto;

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

        public DateTime Fecha_ingreso
        {
            get
            {
                return _fecha_ingreso;
            }

            set
            {
                _fecha_ingreso = value;
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
