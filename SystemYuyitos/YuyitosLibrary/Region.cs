using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuyitosLibrary
{
    public class Region
    {
        private int _id_region;
        private string _nombre_region;

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

        public string Nombre_region
        {
            get
            {
                return _nombre_region;
            }

            set
            {
                _nombre_region = value;
            }
        }
    }
}
