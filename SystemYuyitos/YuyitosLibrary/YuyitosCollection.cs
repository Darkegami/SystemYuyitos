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
        OracleConnection conexion = new OracleConnection("DATA SOURCE=XE;PASSWORD=YUYITOS;USER ID=YUYITOS;");

        public bool IngresarProducto(Producto producto)
        {
            try
            {
                conexion.Open();
                OracleCommand OC = new OracleCommand("INSERTARPRODUCTO", conexion);
                OC.CommandType = System.Data.CommandType.StoredProcedure;
                OC.Parameters.Add("ID_PRODUCTO", OracleType.VarChar).Value = producto.IdProducto;
                OC.Parameters.Add("NOMBRE_PRODUCTO", OracleType.VarChar).Value = producto.NombreProd;
                OC.Parameters.Add("PRECIO_VENTA", OracleType.Number).Value = producto.PrecioVenta;
                OC.Parameters.Add("ID_TIPO_PRODUCTO", OracleType.Number).Value = producto.IdTipoProducto;
                OC.Parameters.Add("CANTIDAD", OracleType.Number).Value = producto.Cantidad;
                OC.Parameters.Add("FEC_INGRESO", OracleType.VarChar).Value = producto.FechaIngreso.ToString("dd-MM-yyyy");
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
        public List<Producto> ListaProducto()
        {
            try
            {
                conexion.Open();
                OracleCommand OC = new OracleCommand("SELECT * FROM PRODUCTO", conexion);
                OracleDataReader ODR = OC.ExecuteReader();
                List<Producto> listProducto = new List<Producto>();
                while (ODR.Read())
                {
                    Producto prod = new Producto();
                    prod.IdProducto = ODR["ID_PRODUCTO"].ToString();
                    prod.NombreProd = ODR["NOMBRE_PRODUCTO"].ToString();
                    prod.PrecioVenta = int.Parse(ODR["PRECIO_VENTA"].ToString());
                    prod.IdTipoProducto = int.Parse(ODR["ID_TIPO_PRODUCTO"].ToString());
                    prod.Cantidad = int.Parse(ODR["CANTIDAD"].ToString());
                    prod.FechaIngreso = DateTime.Parse(ODR["FEC_INGRESO"].ToString());

                    listProducto.Add(prod);
                }
                conexion.Close();
                return listProducto;
            }
            catch (Exception)
            {
                conexion.Close();
                return null;
            }
        }

        public bool IngresarProveedor(Proveedor proveedor)
        {
            try
            {
                conexion.Open();
                OracleCommand OC = new OracleCommand("INSERTARPROVEEDOR", conexion);
                OC.CommandType = System.Data.CommandType.StoredProcedure;
                OC.Parameters.Add("ID_PROVEEDOR", OracleType.Number).Value = proveedor.IDProv;
                OC.Parameters.Add("NOMBRE_PROV", OracleType.VarChar).Value = proveedor.NombreProv;
                OC.Parameters.Add("TELEFONO", OracleType.Number).Value = proveedor.Telefono;
                OC.Parameters.Add("SUCURSAL", OracleType.VarChar).Value = proveedor.Sucursal;
                OC.Parameters.Add("DIRECCION", OracleType.VarChar).Value = proveedor.Direccion;
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

        public List<Proveedor> ListaProveedor()
        {
            try
            {
                conexion.Open();
                OracleCommand OC = new OracleCommand("SELECT * FROM PROVEEDOR", conexion);
                OracleDataReader ODR = OC.ExecuteReader();
                List<Proveedor> listProveedor = new List<Proveedor>();
                while (ODR.Read())
                {
                    Proveedor prov = new Proveedor();
                    prov.IDProv = int.Parse(ODR["ID_PROVEEDOR"].ToString());
                    prov.NombreProv = ODR["NOMBRE_PROV"].ToString();
                    prov.Telefono = int.Parse(ODR["TELEFONO"].ToString());
                    prov.Sucursal = ODR["SUCURSAL"].ToString();
                    prov.Direccion = ODR["DIRECCION"].ToString();


                    listProveedor.Add(prov);
                }
                conexion.Close();
                return listProveedor;
            }
            catch (Exception)
            {
                conexion.Close();
                return null;
            }
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
