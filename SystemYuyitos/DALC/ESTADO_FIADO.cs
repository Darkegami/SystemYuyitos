//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DALC
{
    using System;
    using System.Collections.Generic;
    
    public partial class ESTADO_FIADO
    {
        public ESTADO_FIADO()
        {
            this.FIADO = new HashSet<FIADO>();
        }
    
        public decimal ID_ESTADO_FIADO { get; set; }
        public string NOMBRE_ESTADO { get; set; }
    
        public virtual ICollection<FIADO> FIADO { get; set; }
    }
}
