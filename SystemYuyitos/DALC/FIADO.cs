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
    
    public partial class FIADO
    {
        public FIADO()
        {
            this.REGISTRO_ABONO = new HashSet<REGISTRO_ABONO>();
        }
    
        public decimal ID_FIADO { get; set; }
        public System.DateTime FECHA_FIADO { get; set; }
        public decimal MONTO_FIADO { get; set; }
        public decimal ID_ESTADO_FIADO { get; set; }
        public string ID_VENTA { get; set; }
    
        public virtual ESTADO_FIADO ESTADO_FIADO { get; set; }
        public virtual VENTA VENTA { get; set; }
        public virtual ICollection<REGISTRO_ABONO> REGISTRO_ABONO { get; set; }
    }
}
