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
    
    public partial class ADMINISTRADOR
    {
        public ADMINISTRADOR()
        {
            this.INFORME = new HashSet<INFORME>();
            this.ORDEN_PEDIDO = new HashSet<ORDEN_PEDIDO>();
            this.RECEPCION_PEDIDO = new HashSet<RECEPCION_PEDIDO>();
        }
    
        public string RUT_ADMINISTRADOR { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO { get; set; }
        public string DIRECCION { get; set; }
        public string MAIL { get; set; }
        public decimal TELEFONO { get; set; }
        public decimal ID_COMUNA { get; set; }
        public string NOMBRE_USUARIO { get; set; }
    
        public virtual COMUNA COMUNA { get; set; }
        public virtual USUARIO USUARIO { get; set; }
        public virtual ICollection<INFORME> INFORME { get; set; }
        public virtual ICollection<ORDEN_PEDIDO> ORDEN_PEDIDO { get; set; }
        public virtual ICollection<RECEPCION_PEDIDO> RECEPCION_PEDIDO { get; set; }
    }
}
