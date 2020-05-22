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
        private int _id_tipo_producto;
        private int _cantidad;
        private DateTime _fecha_elaboracion;
        private DateTime _fecha_vencimiento;
        private DateTime _fecha_ingreso;

        public DateTime FechaIngreso
        {
            get { return _fecha_ingreso; }
            set { _fecha_ingreso = value; }
        }

        public DateTime FechaElaboracion
        {
            get { return _fecha_elaboracion; }
            set { _fecha_elaboracion = value; }
        }

        public DateTime FechaVencimiento
        {
            get { return _fecha_vencimiento; }
            set { _fecha_vencimiento = value; }
        }
        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        public int PrecioVenta
        {
            get { return _precio_venta; }
            set { _precio_venta = value; }
        }

        public int IdTipoProducto
        {
            get { return _id_tipo_producto; }
            set { _id_tipo_producto = value; }
        }

        public string IdProducto
        {
            get { return _id_producto; }
            set { _id_producto = value; }
        }

        public string NombreProd
        {
            get { return _nombreProd; }
            set { _nombreProd = value; }
        }
    }
}
