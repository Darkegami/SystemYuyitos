using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuyitosLibrary
{
    class EstadoRecepcion
    {
        private int _id_estado_recepcion;
        private string _nombre_estado;

        public int Id_estado_recepcion
        {
            get
            {
                return _id_estado_recepcion;
            }

            set
            {
                _id_estado_recepcion = value;
            }
        }

        public string Nombre_estado
        {
            get
            {
                return _nombre_estado;
            }

            set
            {
                _nombre_estado = value;
            }
        }
    }
}
