using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuyitosLibrary
{
    public class EstadoOrden
    {
        private int _id_estado_orden;
        private string _nombre_estado;

        public int Id_estado_orden
        {
            get
            {
                return _id_estado_orden;
            }

            set
            {
                _id_estado_orden = value;
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
