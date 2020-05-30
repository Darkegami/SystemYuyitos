using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuyitosLibrary
{
    public class Administrador
    {
        private string _rut_administrador;
        private string _nombres;
        private string _apellidos;
        private string _direccion;
        private string _mail;
        private int _telefono;
        private int _id_comuna;
        private string _usuario;

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

        public string Nombres
        {
            get
            {
                return _nombres;
            }

            set
            {
                _nombres = value;
            }
        }

        public string Apellidos
        {
            get
            {
                return _apellidos;
            }

            set
            {
                _apellidos = value;
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

        public string Mail
        {
            get
            {
                return _mail;
            }

            set
            {
                _mail = value;
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

        public string Usuario
        {
            get
            {
                return _usuario;
            }

            set
            {
                _usuario = value;
            }
        }
    }
}
