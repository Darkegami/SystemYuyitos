using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuyitosLibrary
{
    public class YuyitosCollection
    {
        public List<Proveedor> proveedores = new List<Proveedor>();
        public bool GuardarProveedor(Proveedor proveedor)
        {
            foreach (Proveedor a in proveedores)
            {
                if (a.IDProv == proveedor.IDProv)
                {
                    return false;
                }
            }
            this.proveedores.Add(proveedor);
            return true;
        }

        public Proveedor BuscarProveedor(string iDProv){
            foreach (Proveedor a in proveedores)
            {
                if(a.IDProv == iDProv)
                {
                    return a;
                }
            }
            return null;
        }

        public bool EliminarProveedor(string iDProv)
        {
            Proveedor prov = this.BuscarProveedor(iDProv);
            if (prov == null)
            {
                return false;
            }
            this.proveedores.Remove(prov);
            return true;
        }

        public List<Producto> productos = new List<Producto>();
        public bool GuardarProducto(Producto producto)
        {
            foreach(Producto a in productos)
            {
                if(a.Codigo == producto.Codigo)
                {
                    return false;
                }
            }
            this.productos.Add(producto);
            return true;
        }
        public Producto BuscarProducto(string codigo)
        {
            foreach (Producto a in productos)
            {
                if (a.Codigo == codigo)
                {
                    return a;
                }
            }
            return null;
        }

        public bool EliminarProducto(string codigo)
        {
            Producto prod = this.BuscarProducto(codigo);
            if (prod == null)
            {
                return false;
            }
            this.productos.Remove(prod);
            return true;
        }
    }
}
