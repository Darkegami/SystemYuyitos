using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuyitosLibrary
{
    public class Proveedor
    {
        private int _iDProv;
        private string _nombreProv;
        private int _telefono;
        private string _direccion;
        private Comuna _comuna;
        private Region _region;

            
        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
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

        public int IDProv
        {
            get { return _iDProv; }
            set { _iDProv = value; }
        }

        public Comuna Comuna
        {
            get
            {
                return _comuna;
            }

            set
            {
                _comuna = value;
            }
        }

        public Region Region
        {
            get
            {
                return _region;
            }

            set
            {
                _region = value;
            }
        }
    }
}
