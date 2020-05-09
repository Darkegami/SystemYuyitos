using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuyitosLibrary
{
    public class Producto
    {
        private string _nombreProd;
        private string _codigo;
        private string _categoria;
        private int _precio;
        private int _total;
        private DateTime _fecha;
 

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        public int Total
        {
            get { return _total; }
            set { _total = value; }
        }

        public int Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }

        public string Categoria
        {
            get { return _categoria; }
            set { _categoria = value; }
        }

        public string Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        public string NombreProd
        {
            get { return _nombreProd; }
            set { _nombreProd = value; }
        }
    }
}
