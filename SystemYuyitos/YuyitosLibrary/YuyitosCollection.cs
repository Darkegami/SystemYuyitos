using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
using System.Data;

namespace YuyitosLibrary
{
    public class YuyitosCollection
    {
        OracleConnection conexion = new OracleConnection("DATA SOURCE=orcl;PASSWORD=YUYITOS;USER ID=YUYITOS;");

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

        public bool CrearOrdenCompra(OrdenCompra ordenCompra)
        {
            try
            {
                conexion.Open();
                OracleCommand OC = new OracleCommand("INSERTARORDEN", conexion);
                OC.CommandType = System.Data.CommandType.StoredProcedure;
                OC.Parameters.Add("ID_ORDEN", OracleType.VarChar).Value = ordenCompra.Id_orden_pedido;
                OC.Parameters.Add("FECHA_ORDEN", OracleType.VarChar).Value = ordenCompra.Fecha_orden.ToString("dd-MM-yyyy");
                OC.Parameters.Add("FECHA_PEDIDO", OracleType.VarChar).Value = ordenCompra.Fecha_entrega.ToString("dd-MM-yyyy");
                OC.Parameters.Add("VALOR", OracleType.Number).Value = ordenCompra.Valor_final;
                OC.Parameters.Add("RUT_ADMIN", OracleType.VarChar).Value = ordenCompra.Rut_administrador;
                OC.Parameters.Add("ID_ESTADO", OracleType.Number).Value = ordenCompra.Id_estado_orden;
                OC.ExecuteNonQuery();
                conexion.Close();
                return true;
            }
            catch (Exception)
            {
                conexion.Close();
                return false;
            }
        }

        public List<OrdenCompra> ListaOrdenCompra()
        {
            try
            {
                conexion.Open();
                OracleCommand OC = new OracleCommand("SELECT * FROM ORDEN_PEDIDO", conexion);
                OracleDataReader ODR = OC.ExecuteReader();
                List<OrdenCompra> listOrdenCompra = new List<OrdenCompra>();
                while (ODR.Read())
                {
                    OrdenCompra pp = new OrdenCompra();
                    pp.Id_orden_pedido = ODR["ID_ORDEN_PEDIDO"].ToString();
                    pp.Fecha_entrega = DateTime.Parse(ODR["FECHA_ENTREGA"].ToString());
                    pp.Fecha_orden = DateTime.Parse(ODR["FECHA_PEDIDO"].ToString());
                    pp.Id_estado_orden = int.Parse(ODR["ID_ESTADO_ORDEN"].ToString());
                    pp.Rut_administrador = ODR["RUT_ADMINISTRADOR"].ToString();
                    pp.Valor_final = int.Parse(ODR["VALOR_FINAL_PEDIDO"].ToString());
                    
                    listOrdenCompra.Add(pp);
                }
                conexion.Close();
                return listOrdenCompra;
            }
            catch (Exception)
            {
                conexion.Close();
                return null;
            }
        }
    }
}
