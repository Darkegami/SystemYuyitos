using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuyitosLibrary
{
    public class Proveedor
    {
        private string _iDProv;
        private string _nombreProv;
        private int _telefono;
        private string _sucursal;
        private string _direccion;


        public Proveedor()
        {

        }


        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }


        public string Sucursal
        {
            get { return _sucursal; }
            set { _sucursal = value; }
        }


        public int Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        public  string NombreProv
        {
            get { return _nombreProv; }
            set { _nombreProv = value; }
        }

        public string IDProv
        {
            get { return _iDProv; }
            set { _iDProv = value; }
        }

    }
}
