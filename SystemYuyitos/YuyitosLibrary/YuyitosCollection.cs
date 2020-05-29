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
        OracleConnection conexion = new OracleConnection("DATA SOURCE=ORCL;PASSWORD=YUYITOS;USER ID=YUYITOS;");
        /**
         * Metodo para ingresar un producto a la BD
         **/
        public bool IngresarProducto(Producto producto)
        {
            try
            {
                conexion.Open();
                OracleCommand OC = new OracleCommand("INSERTARPRODUCTO", conexion);
                OC.CommandType = System.Data.CommandType.StoredProcedure;
                OC.Parameters.Add("ID_PRODUCTO", OracleType.VarChar).Value = producto.Id_producto;
                OC.Parameters.Add("NOMBRE_PRODUCTO", OracleType.VarChar).Value = producto.NombreProd;
                OC.Parameters.Add("PRECIO_VENTA", OracleType.Number).Value = producto.Precio_venta;
                OC.Parameters.Add("ID_TIPO_PRODUCTO", OracleType.Number).Value = producto.Id_tipo_producto;
                OC.Parameters.Add("CANTIDAD", OracleType.Number).Value = producto.Cantidad;
                OC.Parameters.Add("FEC_INGRESO", OracleType.VarChar).Value = producto.Fecha_ingreso.ToString("dd-MM-yyyy");
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
        /**
         * Metodo para listar todos los productos de la BD
         **/
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
                    prod.Id_producto = ODR["ID_PRODUCTO"].ToString();
                    prod.NombreProd = ODR["NOMBRE_PRODUCTO"].ToString();
                    prod.Precio_venta = int.Parse(ODR["PRECIO_VENTA"].ToString());
                    prod.Id_tipo_producto = int.Parse(ODR["ID_TIPO_PRODUCTO"].ToString());
                    prod.Cantidad = int.Parse(ODR["CANTIDAD"].ToString());
                    prod.Fecha_ingreso = DateTime.Parse(ODR["FEC_INGRESO"].ToString());

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
        /**
         * Metodo para ingresar un proveedor a la BD
         **/
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
                OC.Parameters.Add("SUCURSAL", OracleType.VarChar).Value = proveedor.Comuna;
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
        /**
         * Metodo para listar a todos los proveedores de la BD
         **/
        public List<Proveedor> ListaProveedor()
        {
            try
            {
                conexion.Open();
                OracleCommand OC = new OracleCommand("SELECT * FROM PROVEEDOR P INNER JOIN COMUNA C ON C.ID_COMUNA=P.ID_COMUNA INNER JOIN REGION R ON C.ID_REGION=R.ID_REGION", conexion);
                OracleDataReader ODR = OC.ExecuteReader();
                List<Proveedor> listProveedor = new List<Proveedor>();
                while (ODR.Read())
                {
                    Proveedor prov = new Proveedor();
                    prov.IDProv = int.Parse(ODR["ID_PROVEEDOR"].ToString());
                    prov.NombreProv = ODR["NOMBRE_PROV"].ToString();
                    prov.Telefono = int.Parse(ODR["TELEFONO"].ToString());
                    prov.Region = ODR["NOMBRE_REGION"].ToString();
                    prov.Comuna = ODR["NOMBRE_COMUNA"].ToString();
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
        /**
         * Metodo que valida la existencia de una orden de compra en estado "NO ENTREGADA"
         **/
        public bool LaOrdenNoFueEntregada(string id_orden)
        {
            try
            {
                conexion.Open();
                OracleCommand OC = new OracleCommand("SELECT * FROM ORDEN_PEDIDO WHERE ID_ORDEN_PEDIDO="+id_orden+" AND ID_ESTADO_ORDEN=1",conexion);
                OracleDataReader ODR = OC.ExecuteReader();
                List<OrdenCompra> listOrden = new List<OrdenCompra>();
                while (ODR.Read())
                {
                    OrdenCompra orden = new OrdenCompra();
                    orden.Id_orden_pedido = ODR["ID_ORDEN_PEDIDO"].ToString();
                    listOrden.Add(orden);
                }
                if (listOrden.Count()>0)
                {
                    conexion.Close();
                    return true;
                }
                else
                {
                    conexion.Close();
                    return false;
                }
                
            }
            catch (Exception)
            {
                conexion.Close();
                return false;
            }
        }
        /**
         * Metodo que comprueba si es que ya se ingreso el producto en la orden con anterioridad
         **/
        public bool ComprobarProductoEnLaOrden(string id_orden,string id_producto)
        {
            try
            {
                conexion.Open();
                OracleCommand OC = new OracleCommand("SELECT * FROM DETALLE_ORDEN_PEDIDO WHERE ID_ORDEN_PEDIDO=" + id_orden + " AND ID_PRODUCTO="+id_producto, conexion);
                OracleDataReader ODR = OC.ExecuteReader();
                List<DetalleOrdenCompra> listDetalleOrden = new List<DetalleOrdenCompra>();
                while (ODR.Read())
                {
                    DetalleOrdenCompra detalleOrden = new DetalleOrdenCompra();
                    detalleOrden.Id_orden = ODR["ID_ORDEN_PEDIDO"].ToString();
                    listDetalleOrden.Add(detalleOrden);
                }
                if (listDetalleOrden.Count() > 0)
                {
                    conexion.Close();
                    return true;
                }
                else
                {
                    conexion.Close();
                    return false;
                }

            }
            catch (Exception)
            {
                conexion.Close();
                return false;
            }
        }
        /**
         * Metodo que crea una orden de compra en la BD
         **/
        public bool CrearOrdenCompra(OrdenCompra ordenCompra)
        {
            try
            {
                conexion.Open();
                OracleCommand OC = new OracleCommand("INSERTAR_ORDEN", conexion);
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
        /**
         * Metodo para listar a todas las ordenes de compra de la BD
         **/
        public List<OrdenCompra> ListaOrdenCompra()
        {
            try
            {
                conexion.Open();
                OracleCommand OC = new OracleCommand("SELECT * FROM ORDEN_PEDIDO OP INNER JOIN ESTADO_ORDEN EO ON EO.ID_ESTADO_ORDEN=OP.ID_ESTADO_ORDEN", conexion);
                OracleDataReader ODR = OC.ExecuteReader();
                List<OrdenCompra> listOrdenCompra = new List<OrdenCompra>();
                while (ODR.Read())
                {
                    OrdenCompra pp = new OrdenCompra();
                    pp.Id_orden_pedido = ODR["ID_ORDEN_PEDIDO"].ToString();
                    pp.Fecha_entrega = DateTime.Parse(ODR["FECHA_ENTREGA"].ToString());
                    pp.Fecha_orden = DateTime.Parse(ODR["FECHA_PEDIDO"].ToString());
                    pp.Estado_orden = ODR["NOMBRE_ESTADO"].ToString();
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
        /**
         * Metodo para listar los datos de la familia del producto de la BD
         **/
        public List<Familia> ListaFamilia()
        {
            try
            {
                conexion.Open();
                OracleCommand OC = new OracleCommand("SELECT * FROM FAMILIA_PRODUCTO",conexion);
                OracleDataReader ODR = OC.ExecuteReader();
                List<Familia> listFamilia = new List<Familia>();
                while (ODR.Read())
                {
                    Familia familia = new Familia();
                    familia.Id_familia = int.Parse(ODR["ID_FAMILIA_PRODUCTO"].ToString());
                    familia.Nombre_familia = ODR["NOMBRE_FAMILIA"].ToString();
                    listFamilia.Add(familia);
                }
                conexion.Close();
                return listFamilia;
            }
            catch (Exception)
            {
                conexion.Close();
                return null;
            }
        }
        /**
         * Metodo que obtiene la lista de los productos filtrados por proveedor y familia
         **/
        public List<Producto> ObtenerProductoFiltrado(int id_proveedor, int id_familia)
        {
            try
            {
                conexion.Open();
                OracleCommand OC = new OracleCommand("SELECT * FROM PRODUCTO WHERE ID_PROVEEDOR ="+id_proveedor+" AND ID_FAMILIA_PRODUCTO="+id_familia, conexion);
                OracleDataReader ODR = OC.ExecuteReader();
                List<Producto> listProducto = new List<Producto>();
                while (ODR.Read())
                {
                    Producto producto = new Producto();
                    producto.Id_producto = ODR["ID_PRODUCTO"].ToString();
                    producto.NombreProd = ODR["NOMBRE_PRODUCTO"].ToString();

                    listProducto.Add(producto);
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
        /**
         * Metodo que lista los datos del detalle de una orden de compra
         **/
        public List<DetalleOrdenCompra> ListaDetalleOrden(string id_orden)
        {
            try
            {
                conexion.Open();
                OracleCommand OC = new OracleCommand("SELECT * FROM DETALLE_ORDEN_PEDIDO DOP "+
                    "INNER JOIN PRODUCTO P ON P.ID_PRODUCTO=DOP.ID_PRODUCTO "+
                    "INNER JOIN PROVEEDOR PR ON P.ID_PROVEEDOR = PR.ID_PROVEEDOR WHERE DOP.ID_ORDEN_PEDIDO="+id_orden, conexion);
                OracleDataReader ODR = OC.ExecuteReader();
                List<DetalleOrdenCompra> listDetalleOrden = new List<DetalleOrdenCompra>();
                while (ODR.Read())
                {
                    DetalleOrdenCompra detalleOrden = new DetalleOrdenCompra();
                    detalleOrden.Cantidad_pack = int.Parse(ODR["CANTIDAD"].ToString());
                    detalleOrden.Id_orden = ODR["ID_ORDEN_PEDIDO"].ToString();
                    detalleOrden.Producto = ODR["NOMBRE_PRODUCTO"].ToString();
                    detalleOrden.Precio_compra_total = int.Parse(ODR["PRECIO_COMPRA_TOTAL"].ToString());
                    detalleOrden.Proveedor = ODR["NOMBRE_PROV"].ToString();
                    detalleOrden.Id_familia = int.Parse(ODR["ID_FAMILIA_PRODUCTO"].ToString());
                    detalleOrden.Id_proveedor = int.Parse(ODR["ID_PROVEEDOR"].ToString());
                    detalleOrden.Id_producto = ODR["ID_PRODUCTO"].ToString();
                    listDetalleOrden.Add(detalleOrden);
                }

                conexion.Close();
                return listDetalleOrden;
            }
            catch (Exception)
            {
                conexion.Close();
                return null;
            }
        }
        /**
         * Metodo para ingresar el detalle de una orden
         **/
         public bool CrearDetalleOrden(DetalleOrdenCompra detalleOrden)
        {
            try
            {
                conexion.Open();
                OracleCommand OC = new OracleCommand("INSERTAR_DETALLE_ORDEN",conexion);
                OC.CommandType = System.Data.CommandType.StoredProcedure;
                OC.Parameters.Add("CANTIDAD",OracleType.Number).Value =detalleOrden.Cantidad_pack;
                OC.Parameters.Add("ID_ORDEN", OracleType.VarChar).Value=detalleOrden.Id_orden;
                OC.Parameters.Add("ID_PRODUCTO", OracleType.VarChar).Value = detalleOrden.Id_producto;
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
        /**
         * Metodo para eliminar un producto del detalle de una orden
         **/
        public bool EliminarDetalleOrden(string id_orden,string id_producto)
        {
            try
            {
                conexion.Open();
                OracleCommand OC = new OracleCommand("ELIMINAR_DETALLE_ORDEN",conexion);
                OC.CommandType = System.Data.CommandType.StoredProcedure;
                OC.Parameters.Add("V_ID_ORDEN",OracleType.VarChar).Value = id_orden;
                OC.Parameters.Add("V_ID_PRODUCTO", OracleType.VarChar).Value = id_producto;
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
        /**
         * Metodo para eliminar una orden
         **/
        public bool EliminarOrden(string id_orden)
        {
            try
            {
                conexion.Open();
                OracleCommand OC = new OracleCommand("ELIMINAR_ORDEN", conexion);
                OC.CommandType = System.Data.CommandType.StoredProcedure;
                OC.Parameters.Add("V_ID_ORDEN", OracleType.VarChar).Value = id_orden;
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
        /**
         * Metodo que valida la existencia de una orden de compra en estado "ENTREGADA"
         **/
        public bool LaOrdenFueEntregada(string id_orden)
        {
            try
            {
                conexion.Open();
                OracleCommand OC = new OracleCommand("SELECT * FROM ORDEN_PEDIDO WHERE ID_ORDEN_PEDIDO=" + id_orden + " AND ID_ESTADO_ORDEN=2", conexion);
                OracleDataReader ODR = OC.ExecuteReader();
                List<OrdenCompra> listOrden = new List<OrdenCompra>();
                while (ODR.Read())
                {
                    OrdenCompra orden = new OrdenCompra();
                    orden.Id_orden_pedido = ODR["ID_ORDEN_PEDIDO"].ToString();
                    listOrden.Add(orden);
                }
                if (listOrden.Count() > 0)
                {
                    conexion.Close();
                    return true;
                }
                else
                {
                    conexion.Close();
                    return false;
                }

            }
            catch (Exception)
            {
                conexion.Close();
                return false;
            }
        }
        /**
         * Metodo que valida la existencia de una recepcion de una orden en estado "DENEGADA"
         **/
        public bool LaRecepcionFueDenegada(string id_orden)
        {
            try
            {
                conexion.Open();
                OracleCommand OC = new OracleCommand("SELECT * FROM RECEPCION_PEDIDO WHERE ID_ESTADO_RECEPCION=2 AND ID_ORDEN_PEDIDO="+id_orden, conexion);
                OracleDataReader ODR = OC.ExecuteReader();
                List<RecepcionCompra> listRecepcion = new List<RecepcionCompra>();
                while (ODR.Read())
                {
                    RecepcionCompra recepcion = new RecepcionCompra();
                    recepcion.Id_recepcion_compra = ODR["ID_RECEPCION"].ToString();
                    listRecepcion.Add(recepcion);
                }
                if (listRecepcion.Count() > 0)
                {
                    conexion.Close();
                    return true;
                }
                else
                {
                    conexion.Close();
                    return false;
                }

            }
            catch (Exception)
            {
                conexion.Close();
                return false;
            }
        }
        /**
         * Metodo que confirma la recepcion de una orden
         **/
        public bool ConfirmarRecepcion(RecepcionCompra recepcionCompra)
        {
            try
            {
                conexion.Open();
                OracleCommand OC = new OracleCommand("CONFIRMAR_RECEPCION",conexion);
                OC.CommandType = System.Data.CommandType.StoredProcedure;
                OC.Parameters.Add("V_COMENTARIOS", OracleType.VarChar).Value = recepcionCompra.Comentarios;
                OC.Parameters.Add("V_FECHA_RECEPCION", OracleType.VarChar).Value = recepcionCompra.Fecha_recepcion.ToString("dd-MM-yyyy");
                OC.Parameters.Add("V_ID_ESTADO", OracleType.Number).Value = recepcionCompra.Id_estado_recepcion;
                OC.Parameters.Add("V_ID_ORDEN", OracleType.VarChar).Value = recepcionCompra.Id_orden_compra;
                OC.Parameters.Add("V_ID_RECEPCION", OracleType.VarChar).Value = recepcionCompra.Id_recepcion_compra;
                OC.Parameters.Add("V_RUT_ADMIN", OracleType.VarChar).Value = recepcionCompra.Rut_administrador;
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
        /**
         * Metodo que denega la recepcion de una orden
         **/
        public bool denegarRecepcion(RecepcionCompra recepcionCompra)
        {
            try
            {
                conexion.Open();
                OracleCommand OC = new OracleCommand("DENEGAR_RECEPCION", conexion);
                OC.CommandType = System.Data.CommandType.StoredProcedure;
                OC.Parameters.Add("V_COMENTARIOS", OracleType.VarChar).Value = recepcionCompra.Comentarios;
                OC.Parameters.Add("V_FECHA_RECEPCION", OracleType.VarChar).Value = recepcionCompra.Fecha_recepcion;
                OC.Parameters.Add("V_ID_ESTADO", OracleType.Number).Value = recepcionCompra.Id_estado_recepcion;
                OC.Parameters.Add("V_ID_ORDEN", OracleType.VarChar).Value = recepcionCompra.Id_orden_compra;
                OC.Parameters.Add("V_ID_RECEPCION", OracleType.VarChar).Value = recepcionCompra.Id_recepcion_compra;
                OC.Parameters.Add("V_RUT_ADMIN", OracleType.VarChar).Value = recepcionCompra.Rut_administrador;
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
    }
}
