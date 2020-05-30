using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuyitosLibrary
{
    public class Comuna
    {
        private int _id_comuna;
        private string _nombre_comuna;
        private Region _region;

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

        public string Nombre_comuna
        {
            get
            {
                return _nombre_comuna;
            }

            set
            {
                _nombre_comuna = value;
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
