using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuyitosLibrary
{
    public class Familia
    {
        private int _id_familia;
        private string _nombre_familia;

        public int Id_familia
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

        public string Nombre_familia
        {
            get
            {
                return _nombre_familia;
            }

            set
            {
                _nombre_familia = value;
            }
        }
    }
}
