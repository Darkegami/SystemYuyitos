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
                OracleCommand OC = new OracleCommand("INSERTAR_PRODUCTO", conexion);
                OC.CommandType = System.Data.CommandType.StoredProcedure;
                OC.Parameters.Add("ID_PRODUCTO", OracleType.Number).Value = producto.Id_producto;
                OC.Parameters.Add("NOMBRE_PRODUCTO", OracleType.VarChar).Value = producto.NombreProd;
                OC.Parameters.Add("FECHA_ELABORACION", OracleType.VarChar).Value = producto.Fecha_elaboracion.ToString("dd-MM-yyyy");
                OC.Parameters.Add("FEC_VENCIMIENTO", OracleType.VarChar).Value = producto.Fecha_vencimiento.ToString("dd-MM-yyyy");
                OC.Parameters.Add("PRECIO_VENTA", OracleType.Number).Value = producto.Precio_venta;
                OC.Parameters.Add("PRECIO_COMPRA", OracleType.Number).Value = producto.Precio_compra;
                OC.Parameters.Add("STOCK", OracleType.Number).Value = producto.Stock;
                OC.Parameters.Add("ID_FAMILIA_PRODUCTO", OracleType.Number).Value = producto.Familia;
                OC.Parameters.Add("ID_PROVEEDOR", OracleType.Number).Value = producto.Proveedor;
                OC.Parameters.Add("ID_TIPO_PRODUCTO", OracleType.Number).Value = producto.Tipo_producto;

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
         * Metodo para Eliminar los productos de la BD
         **/
        public bool EliminarProducto(int id_producto)
        {
            try
            {
                conexion.Open();
                OracleCommand OC = new OracleCommand("ELIMINAR_PRODUCTO", conexion);
                OC.CommandType = System.Data.CommandType.StoredProcedure;
                OC.Parameters.Add("V_ID_PRODUCTO", OracleType.Number).Value = id_producto;
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
        * Metodo para Modificar los productos de la BD
        **/
        public Producto BuscarProducto(int id_producto)
        {
            try
            {
                conexion.Open();
                OracleCommand OC = new OracleCommand("BUSCAR_PRODUCTO", conexion);
                OC.CommandType = System.Data.CommandType.StoredProcedure;
                OC.Parameters.Add("CURSOR_T", OracleType.Cursor).Direction = ParameterDirection.Output;
                OC.Parameters.Add("V_ID_PRODUCTO", OracleType.Number).Value = id_producto;
                OracleDataReader ODR = OC.ExecuteReader();
                Producto producto = null;
                while (ODR.Read())
                {
                  
                    producto.Id_producto = int.Parse(ODR["ID_PRODUCTO"].ToString());
                    producto.NombreProd = ODR["NOMBRE_PRODUCTO"].ToString();
                    producto.Fecha_elaboracion = DateTime.Parse(ODR["FECHA_ELABORACION"].ToString());
                    producto.Fecha_vencimiento = DateTime.Parse(ODR["FEC_VENCIMIENTO"].ToString());
                    producto.Precio_venta = int.Parse(ODR["PRECIO_VENTA"].ToString());
                    producto.Precio_compra = int.Parse(ODR["PRECIO_COMPRA"].ToString());
                    producto.Stock = int.Parse(ODR["STOCK"].ToString());
                    producto = new Producto();
                    Familia fam = new Familia();
                    fam.Id_familia = int.Parse(ODR["ID_FAMILIA_PRODUCTO"].ToString());
                    producto.Familia = fam;
                    Proveedor prov = new Proveedor();
                    prov.IDProv = int.Parse(ODR["ID_PROVEEDOR"].ToString());
                    producto.Proveedor = prov;
                    TipoProducto tp = new TipoProducto();
                    tp.Id_tipo_producto = int.Parse(ODR["ID_TIPO_PRODUCTO"].ToString());
                    producto.Tipo_producto = tp;

                    if (producto.Id_producto == id_producto)
                    {
                        conexion.Close();
                        return producto;
                    }
                }
                conexion.Close();
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool ModificarProducto(Producto producto)
        {
            try
            {
                conexion.Open();
                OracleCommand OC = new OracleCommand("MODIFICAR_PRODUCTO", conexion);
                OC.CommandType = System.Data.CommandType.StoredProcedure;
                OC.Parameters.Add("V_ID_PRODUCTO", OracleType.Number).Value = producto.Id_producto;
                OC.Parameters.Add("V_NOMBRE_PRODUCTO", OracleType.VarChar).Value = producto.NombreProd;
                OC.Parameters.Add("V_FECHA_ELABORACION", OracleType.VarChar).Value = producto.Fecha_elaboracion;
                OC.Parameters.Add("V_FEC_VENCIMIENTO", OracleType.VarChar).Value = producto.Fecha_vencimiento;
                OC.Parameters.Add("V_PRECIO_VENTA", OracleType.Number).Value = producto.Precio_venta;
                OC.Parameters.Add("V_PRECIO_COMPRA", OracleType.Number).Value = producto.Precio_compra;
                OC.Parameters.Add("V_STOCK", OracleType.Number).Value = producto.Precio_venta;
                OC.Parameters.Add("V_ID_FAMILIA_PRODUCTO", OracleType.Number).Value = producto.Familia;
                OC.Parameters.Add("V_ID_PROVEEDOR", OracleType.Number).Value = producto.Proveedor;
                OC.Parameters.Add("V_ID_TIPO_PRODUCTO", OracleType.Number).Value = producto.Tipo_producto;

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
                OracleCommand OC = new OracleCommand("LISTAR_PRODUCTOS", conexion);
                OC.CommandType = System.Data.CommandType.StoredProcedure;
                OC.Parameters.Add("CURSOR_T",OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataReader ODR = OC.ExecuteReader();
                List<Producto> listProducto = new List<Producto>();
                while (ODR.Read())
                {
                    Producto prod = new Producto();
                    prod.Id_producto = int.Parse(ODR["ID_PRODUCTO"].ToString());
                    prod.NombreProd = ODR["NOMBRE_PRODUCTO"].ToString();
                    prod.Precio_venta = int.Parse(ODR["PRECIO_VENTA"].ToString());
                    prod.Precio_compra = int.Parse(ODR["PRECIO_COMPRA"].ToString());
                    prod.Fecha_elaboracion = DateTime.Parse(ODR["FECHA_ELABORACION"].ToString());
                    prod.Fecha_vencimiento = DateTime.Parse(ODR["FEC_VENCIMIENTO"].ToString());
                    prod.Stock = int.Parse(ODR["STOCK"].ToString());
                    Familia fam = new Familia();
                    fam.Id_familia = int.Parse(ODR["ID_FAMILIA_PRODUCTO"].ToString());
                    fam.Nombre_familia = ODR["NOMBRE_FAMILIA"].ToString();
                    prod.Familia = fam;
                    Proveedor prov = new Proveedor();
                    prov.IDProv = int.Parse(ODR["ID_PROVEEDOR"].ToString());
                    prov.NombreProv = ODR["NOMBRE_PROV"].ToString();
                    prod.Proveedor = prov;
                    TipoProducto tp = new TipoProducto();
                    tp.Id_tipo_producto = int.Parse(ODR["ID_TIPO_PRODUCTO"].ToString());
                    tp.Nombre_tipo_prod = ODR["NOMBRE_TIPO_PROD"].ToString();
                    prod.Tipo_producto = tp;

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
                OracleCommand OC = new OracleCommand("INSERTAR_PROVEEDOR", conexion);
                OC.CommandType = System.Data.CommandType.StoredProcedure;
                OC.Parameters.Add("V_NOMBRE_PROV", OracleType.VarChar).Value = proveedor.NombreProv;
                OC.Parameters.Add("V_TELEFONO", OracleType.Number).Value = proveedor.Telefono;
                OC.Parameters.Add("V_ID_COMUNA", OracleType.Number).Value = proveedor.Id_comuna;
                OC.Parameters.Add("V_DIRECCION", OracleType.VarChar).Value = proveedor.Direccion;
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
         * Metodo para modificar un proveedor en la BD
         **/
        public bool ModificarProveedor(Proveedor proveedor)
        {
            try
            {
                conexion.Open();
                OracleCommand OC = new OracleCommand("MODIFICAR_PROVEEDOR", conexion);
                OC.CommandType = System.Data.CommandType.StoredProcedure;
                OC.Parameters.Add("V_ID_PROVEEDOR", OracleType.Number).Value = proveedor.IDProv;
                OC.Parameters.Add("V_NOMBRE_PROV", OracleType.VarChar).Value = proveedor.NombreProv;
                OC.Parameters.Add("V_TELEFONO", OracleType.Number).Value = proveedor.Telefono;
                OC.Parameters.Add("V_ID_COMUNA", OracleType.Number).Value = proveedor.Id_comuna;
                OC.Parameters.Add("V_DIRECCION", OracleType.VarChar).Value = proveedor.Direccion;
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
         * Metodo para eliminar un proveedor de la BD
         **/
         public bool EliminarProveedor(int id_proveedor)
        {
            try
            {
                conexion.Open();
                OracleCommand OC = new OracleCommand("ELIMINAR_PROVEEDOR",conexion);
                OC.CommandType = System.Data.CommandType.StoredProcedure;
                OC.Parameters.Add("V_ID_PROVEEDOR",OracleType.Number).Value = id_proveedor;
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
                OracleCommand OC = new OracleCommand("LISTAR_PROVEEDORES", conexion);
                OC.CommandType = System.Data.CommandType.StoredProcedure;
                OC.Parameters.Add("CURSOR_T",OracleType.Cursor).Direction=ParameterDirection.Output;
                OracleDataReader ODR = OC.ExecuteReader();
                List<Proveedor> listProveedor = new List<Proveedor>();
                while (ODR.Read())
                {
                    Proveedor prov = new Proveedor();
                    prov.IDProv = int.Parse(ODR["ID_PROVEEDOR"].ToString());
                    prov.NombreProv = ODR["NOMBRE_PROV"].ToString();
                    prov.Telefono = int.Parse(ODR["TELEFONO"].ToString());
                    Region reg = new Region();
                    reg.Id_region = int.Parse(ODR["ID_REGION"].ToString());
                    reg.Nombre_region = ODR["NOMBRE_REGION"].ToString();
                    prov.Region = reg;
                    Comuna com = new Comuna();
                    com.Id_comuna = int.Parse(ODR["ID_COMUNA"].ToString());
                    com.Nombre_comuna = ODR["NOMBRE_COMUNA"].ToString();
                    prov.Comuna =com;
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
                OracleCommand OC = new OracleCommand("ORDEN_NO_ENTREGADA",conexion);
                OC.CommandType = System.Data.CommandType.StoredProcedure;
                OC.Parameters.Add("CURSOR_T",OracleType.Cursor).Direction = ParameterDirection.Output;
                OC.Parameters.Add("V_ID_ORDEN",OracleType.VarChar).Value = id_orden;
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
                OracleCommand OC = new OracleCommand("COMPROBAR_PRODUCTO_ORDEN", conexion);
                OC.CommandType = System.Data.CommandType.StoredProcedure;
                OC.Parameters.Add("V_ID_ORDEN",OracleType.VarChar).Value = id_orden;
                OC.Parameters.Add("V_ID_PRODUCTO",OracleType.VarChar).Value = id_producto;
                OC.Parameters.Add("CURSOR_T",OracleType.Cursor).Direction = ParameterDirection.Output;
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
                OracleCommand OC = new OracleCommand("LISTAR_ORDENES", conexion);
                OC.CommandType = System.Data.CommandType.StoredProcedure;
                OC.Parameters.Add("CURSOR_T",OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataReader ODR = OC.ExecuteReader();
                List<OrdenCompra> listOrdenCompra = new List<OrdenCompra>();
                while (ODR.Read())
                {
                    OrdenCompra pp = new OrdenCompra();
                    pp.Id_orden_pedido = ODR["ID_ORDEN_PEDIDO"].ToString();
                    pp.Fecha_entrega = DateTime.Parse(ODR["FECHA_ENTREGA"].ToString());
                    pp.Fecha_orden = DateTime.Parse(ODR["FECHA_PEDIDO"].ToString());
                    EstadoOrden EO = new EstadoOrden();
                    EO.Id_estado_orden = int.Parse(ODR["ID_ESTADO_ORDEN"].ToString());
                    EO.Nombre_estado = ODR["NOMBRE_ESTADO"].ToString();
                    pp.Estado_orden = EO;
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
                OracleCommand OC = new OracleCommand("LISTAR_FAMILIAS",conexion);
                OC.CommandType = System.Data.CommandType.StoredProcedure;
                OC.Parameters.Add("CURSOR_T",OracleType.Cursor).Direction = ParameterDirection.Output;
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
                OracleCommand OC = new OracleCommand("PRODUCTOS_FILTRADOS", conexion);
                OC.CommandType = System.Data.CommandType.StoredProcedure;
                OC.Parameters.Add("V_ID_PROVEEDOR",OracleType.Number).Value = id_proveedor;
                OC.Parameters.Add("V_ID_FAMILIA",OracleType.Number).Value = id_familia;
                OC.Parameters.Add("CURSOR_T",OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataReader ODR = OC.ExecuteReader();
                List<Producto> listProducto = new List<Producto>();
                while (ODR.Read())
                {
                    Producto producto = new Producto();
                    producto.Id_producto = int.Parse(ODR["ID_PRODUCTO"].ToString());
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
                OracleCommand OC = new OracleCommand("LISTAR_DETALLE_ORDEN", conexion);
                OC.CommandType = System.Data.CommandType.StoredProcedure;
                OC.Parameters.Add("V_ID_ORDEN",OracleType.VarChar).Value = id_orden;
                OC.Parameters.Add("CURSOR_T",OracleType.Cursor).Direction = ParameterDirection.Output;
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
                OracleCommand OC = new OracleCommand("ORDEN_ENTREGADA", conexion);
                OC.CommandType = System.Data.CommandType.StoredProcedure;
                OC.Parameters.Add("CURSOR_T",OracleType.Cursor).Direction = ParameterDirection.Output;
                OC.Parameters.Add("V_ID_ORDEN",OracleType.VarChar).Value=id_orden;
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
        public bool DenegarRecepcion(RecepcionCompra recepcionCompra)
        {
            try
            {
                conexion.Open();
                OracleCommand OC = new OracleCommand("DENEGAR_RECEPCION", conexion);
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
         * Metodo que comprueba si existen productos en el detalle de la orden
         **/
        public bool ComprobarExistenciaDetalleOrden(string id_orden)
        {
            try
            {
                conexion.Open();
                OracleCommand OC = new OracleCommand("COMPROBAR_EXISTENCIA_DETALLE_ORDEN", conexion);
                OC.CommandType = System.Data.CommandType.StoredProcedure;
                OC.Parameters.Add("CURSOR_T",OracleType.Cursor).Direction = ParameterDirection.Output;
                OC.Parameters.Add("V_ID_ORDEN",OracleType.VarChar).Value = id_orden;
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
         * Metodo que comprueba la existencia de un administrador
         **/
        public bool ComprobarExistenciaAdministrador(string rut_admin)
        {
            try
            {
                conexion.Open();
                OracleCommand OC = new OracleCommand("COMPROBAR_RUT_ADMIN", conexion);
                OC.CommandType = System.Data.CommandType.StoredProcedure;
                OC.Parameters.Add("CURSOR_T",OracleType.Cursor).Direction = ParameterDirection.Output;
                OC.Parameters.Add("V_RUT_ADMIN",OracleType.VarChar).Value = rut_admin;
                OracleDataReader ODR = OC.ExecuteReader();
                List<Administrador> listAdministrador = new List<Administrador>();
                while (ODR.Read())
                {
                    Administrador admin = new Administrador();
                    admin.Rut_administrador = ODR["RUT_ADMINISTRADOR"].ToString();
                    listAdministrador.Add(admin);
                }
                if (listAdministrador.Count() > 0)
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
         * Metodo que lista todas las recepciones
         **/
         public List<RecepcionCompra> ListaRecepcionCompra()
        {
            try
            {
                conexion.Open();
                OracleCommand OC = new OracleCommand("LISTAR_RECEPCIONES",conexion);
                OC.CommandType = System.Data.CommandType.StoredProcedure;
                OC.Parameters.Add("CURSOR_T",OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataReader ODR = OC.ExecuteReader();
                List<RecepcionCompra> listRecepcion = new List<RecepcionCompra>();
                while (ODR.Read())
                {
                    RecepcionCompra recepcion = new RecepcionCompra();
                    recepcion.Comentarios = ODR["COMENTARIO"].ToString();
                    recepcion.Estado_recepcion = ODR["NOMBRE_ESTADO"].ToString();
                    recepcion.Fecha_recepcion = DateTime.Parse(ODR["FECHA_RECEPCION"].ToString());
                    recepcion.Id_recepcion_compra = ODR["ID_RECEPCION"].ToString();
                    recepcion.Id_orden_compra = ODR["ID_ORDEN_PEDIDO"].ToString();
                    recepcion.Rut_administrador = ODR["RUT_ADMINISTRADOR"].ToString();
                    listRecepcion.Add(recepcion);
                }
                conexion.Close();
                return listRecepcion;
            }
            catch (Exception)
            {
                conexion.Close();
                return null;
            }
        }
        /**
         * Metodo que lista todas las regiones
         **/
         public List<Region> ListaRegion()
        {
            try
            {
                conexion.Open();
                OracleCommand OC = new OracleCommand("LISTAR_REGIONES",conexion);
                OC.CommandType = System.Data.CommandType.StoredProcedure;
                OC.Parameters.Add("CURSOR_T",OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataReader ODR = OC.ExecuteReader();
                List<Region> listRegion = new List<Region>();
                while (ODR.Read())
                {
                    Region region = new Region();
                    region.Id_region = int.Parse(ODR["ID_REGION"].ToString());
                    region.Nombre_region = ODR["NOMBRE_REGION"].ToString();
                    listRegion.Add(region);
                }
                conexion.Close();
                return listRegion;
            }
            catch (Exception)
            {
                conexion.Close();
                return null;
            }
        }
        /**
         * Metodo que lista las comunas segun su region
         **/
        public List<Comuna> ListaComuna(int id_region)
        {
            try
            {
                conexion.Open();
                OracleCommand OC = new OracleCommand("LISTAR_COMUNAS", conexion);
                OC.CommandType = System.Data.CommandType.StoredProcedure;
                OC.Parameters.Add("CURSOR_T",OracleType.Cursor).Direction = ParameterDirection.Output;
                OC.Parameters.Add("V_ID_REGION",OracleType.Number).Value = id_region;
                OracleDataReader ODR = OC.ExecuteReader();
                List<Comuna> listComuna = new List<Comuna>();
                while (ODR.Read())
                {
                    Comuna comuna = new Comuna();
                    comuna.Id_comuna = int.Parse(ODR["ID_COMUNA"].ToString());
                    comuna.Nombre_comuna = ODR["NOMBRE_COMUNA"].ToString();
                    listComuna.Add(comuna);
                }
                conexion.Close();
                return listComuna;
            }
            catch (Exception)
            {
                conexion.Close();
                return null;
            }
        }
        /**
         * Metodo que busca a un proveedor
         **/
         public Proveedor BuscarProveedor(int id_proveedor)
        {
            try
            {
                conexion.Open();
                OracleCommand OC = new OracleCommand("BUSCAR_PROVEEDOR",conexion);
                OC.CommandType = System.Data.CommandType.StoredProcedure;
                OC.Parameters.Add("CURSOR_T",OracleType.Cursor).Direction = ParameterDirection.Output;
                OC.Parameters.Add("V_ID_PROVEEDOR",OracleType.Number).Value = id_proveedor;
                OracleDataReader ODR = OC.ExecuteReader();
                Proveedor proveedor = null;
                while (ODR.Read())
                {
                    proveedor = new Proveedor();
                    Comuna com = new Comuna();
                    com.Id_comuna = int.Parse(ODR["ID_COMUNA"].ToString());
                    proveedor.Comuna = com;
                    Region reg = new Region();
                    reg.Id_region = int.Parse(ODR["ID_REGION"].ToString());
                    proveedor.Region = reg;
                    proveedor.Direccion = ODR["DIRECCION"].ToString();
                    proveedor.IDProv = int.Parse(ODR["ID_PROVEEDOR"].ToString());
                    proveedor.NombreProv = ODR["NOMBRE_PROV"].ToString();
                    proveedor.Telefono = int.Parse(ODR["TELEFONO"].ToString());
                    if (proveedor.IDProv == id_proveedor)
                    {
                        conexion.Close();
                        return proveedor;
                    }
                }
                conexion.Close();
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<TipoProducto> ListaTipoProducto()
        {
            try
            {
                conexion.Open();
                OracleCommand OC = new OracleCommand("LISTAR_TIPO_PRODUCTO", conexion);
                OC.CommandType = System.Data.CommandType.StoredProcedure;
                OC.Parameters.Add("CURSOR_T", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataReader ODR = OC.ExecuteReader();
                List<TipoProducto> listTipoProducto = new List<TipoProducto>();
                while (ODR.Read())
                {
                    TipoProducto tipoProducto = new TipoProducto();
                    tipoProducto.Id_tipo_producto = int.Parse(ODR["ID_TIPO_PRODUCTO"].ToString());
                    tipoProducto.Nombre_tipo_prod = ODR["NOMBRE_TIPO_PROD"].ToString();
                    listTipoProducto.Add(tipoProducto);
                }
                conexion.Close();
                return listTipoProducto;
            }
            catch (Exception)
            {
                conexion.Close();
                return null;
            }
        }
    }
}
