using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuyitosLibrary
{
    public class TipoProducto
    {
        private int _id_tipo_producto;
        private string _nombre_tipo_prod;

        public int Id_tipo_producto
        {
            get
            {
                return _id_tipo_producto;
            }

            set
            {
                _id_tipo_producto = value;
            }
        }

        public string Nombre_tipo_prod
        {
            get
            {
                return _nombre_tipo_prod;
            }

            set
            {
                _nombre_tipo_prod = value;
            }
        }
    }
}
