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
    
    public partial class CLIENTE
    {
        public CLIENTE()
        {
            this.VENTA = new HashSet<VENTA>();
        }
    
        public string RUT_CLIENTE { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDOS { get; set; }
        public decimal TELEFONO { get; set; }
        public string DIRECCION { get; set; }
        public string MAIL { get; set; }
        public decimal ID_COMUNA { get; set; }
    
        public virtual COMUNA COMUNA { get; set; }
        public virtual ICollection<VENTA> VENTA { get; set; }
    }
}
