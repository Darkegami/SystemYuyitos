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
        private int _id_comuna;
        private Region _region;
        private int _id_region;

        public int IDProv
        {
            get
            {
                return _iDProv;
            }

            set
            {
                _iDProv = value;
            }
        }

        public string NombreProv
        {
            get
            {
                return _nombreProv;
            }

            set
            {
                _nombreProv = value;
            }
        }

        public int Telefono
        {
            get
            {
                return _telefono;
            }

            set
            {
                _telefono = value;
            }
        }

        public string Direccion
        {
            get
            {
                return _direccion;
            }

            set
            {
                _direccion = value;
            }
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

        public int Id_comuna
        {
            get
            {
                return _id_comuna;
            }

            set
            {
                _id_comuna = value;
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

        public int Id_region
        {
            get
            {
                return _id_region;
            }

            set
            {
                _id_region = value;
            }
        }
    }
}
