using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using MahApps.Metro.Behaviours;
using MahApps.Metro.Controls.Dialogs;
using YuyitosLibrary;

namespace SystemYuyitos
{
    /// <summary>
    /// Lógica de interacción para Registro_Orden_Compra.xaml
    /// </summary>
    public partial class Registro_Orden_Compra : MetroWindow
    {
        private YuyitosCollection YC = new YuyitosCollection();
        public static Registro_Orden_Compra ventanaRegistroOrden;

        public Registro_Orden_Compra()
        {
            InitializeComponent();
            this.cargarGrillaOrden();
            cboProveedor.ItemsSource= null;
            cboProveedor.ItemsSource = YC.ListaProveedor();

            cboFamilia.ItemsSource = null;
            cboFamilia.ItemsSource = YC.ListaFamilia();
        }

        public static Registro_Orden_Compra getInstance()
        {
            if (ventanaRegistroOrden == null)
            {
                ventanaRegistroOrden = new Registro_Orden_Compra();
            }

            return ventanaRegistroOrden;
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            Menu.getInstance().Show();
            ventanaRegistroOrden = null;
            this.Close();
        }

        private void cargarGrillaOrden()
        {
            dgGrillaOrden.ItemsSource = null;
            dgGrillaOrden.ItemsSource = YC.ListaOrdenCompra();
        }

        private void cargarGrillaProducto(string id_orden)
        {
            dgGrillaProducto.ItemsSource = null;
            dgGrillaProducto.ItemsSource = YC.ListaDetalleOrden(id_orden);
        }

        private void btnIngresarProducto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (true)
                {
                    if (txtCantidad.Text.Trim()==""||txtIdOrden.Text.Trim()==""||cboFamilia.SelectedIndex < 0 || cboProducto.SelectedIndex < 0 || cboProveedor.SelectedIndex < 0)
                    {
                        MessageBox.Show("No puede dejar campos sin rellenar", "ERROR");
                        return;
                    }
                    else
                    {
                        if (YC.LaOrdenNoFueEntregada(txtIdOrden.Text.Trim()))
                        {
                            if (YC.ComprobarProductoEnLaOrden(txtIdOrden.Text.Trim(),cboProducto.SelectedValue.ToString()))
                            {
                                MessageBox.Show("Ya fue ingresado este producto en esta orden","ERROR");
                                return;
                            }
                            else
                            {
                                DetalleOrdenCompra detalleOrden = new DetalleOrdenCompra();
                                detalleOrden.Cantidad_pack = int.Parse(txtCantidad.Text);
                                detalleOrden.Id_orden = txtIdOrden.Text;
                                detalleOrden.Id_producto = cboProducto.SelectedValue.ToString();
                                if (YC.CrearDetalleOrden(detalleOrden))
                                {
                                    MessageBox.Show("Se ha ingresado un producto al detalle de la orden","PRODUCTO INGRESADO A LA ORDEN");
                                    this.cargarGrillaOrden();
                                    this.cargarGrillaProducto(detalleOrden.Id_orden);
                                    return;
                                }
                                else
                                { 
                                    MessageBox.Show("Ha ocurrido un error, contacte a un tecnico a la brevedad", "ERROR");
                                    return;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ingrese una orden de compra correcta y que no haya sido recepcionada","ERROR");
                            return;
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnCrearOrden_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dpFechaEntrega.SelectedDate == null || txtRutAdmin.Text.Trim() =="")
                {
                    MessageBox.Show("Ingrese la informacion correctamente", "ERROR");
                    return;
                }
                else
                {
                    if (dpFechaEntrega.SelectedDate.Value < DateTime.Now.AddDays(-1))
                    {
                        MessageBox.Show("La fecha de entrega no puede ser antes de la fecha de hoy", "ERROR FECHA ENTREGA");
                        return;
                    }
                    else
                    {
                        if (YC.ComprobarExistenciaAdministrador(txtRutAdmin.Text.Trim()))
                        {
                            OrdenCompra ordenCompra = new OrdenCompra();
                            ordenCompra.Rut_administrador = txtRutAdmin.Text;
                            ordenCompra.Id_orden_pedido = string.Format("{0:yyyyMMddHHmm}", DateTime.Now);
                            ordenCompra.Fecha_orden = DateTime.Today;
                            ordenCompra.Fecha_entrega = dpFechaEntrega.SelectedDate.Value;
                            ordenCompra.Valor_final = 0;
                            ordenCompra.Id_estado_orden = 1;
                            if (YC.CrearOrdenCompra(ordenCompra))
                            {
                                MessageBox.Show("La orden ha sido ingresada exitosamente", "ORDEN AGREGADA");
                                this.cargarGrillaOrden();
                                return;
                            }
                            else
                            {
                                MessageBox.Show("Ha ocurrido un error, contacte a un tecnico a la brevedad", "ERROR");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("El rut de administrador no coincide con ninguno de nuestros registros", "ERROR");
                            return;
                        }
                    }

                }

            }
            catch (Exception error)
            {

                throw;
            }
        }

        private void cboProveedor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cboProducto.ItemsSource = null;
            try
            {
                int id_proveedor = (int)cboProveedor.SelectedValue;
                int id_familia = (int)cboFamilia.SelectedValue;
                cboProducto.ItemsSource = YC.ObtenerProductoFiltrado(id_proveedor, id_familia);
            }
            catch (Exception)
            {

                return;
            }
        }

        private void cboFamilia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cboProducto.ItemsSource = null;
            try
            {
                int id_proveedor = (int)cboProveedor.SelectedValue;
                int id_familia = (int)cboFamilia.SelectedValue;
                cboProducto.ItemsSource = YC.ObtenerProductoFiltrado(id_proveedor, id_familia);
            }
            catch (Exception)
            {

                return;
            }
        }

        private void txtIdOrden_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.cargarGrillaProducto(txtIdOrden.Text);
        }

        private void dgGrillaOrden_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                OrdenCompra ordenCompra = (OrdenCompra)dgGrillaOrden.SelectedItem;
                txtIdOrden.Text = ordenCompra.Id_orden_pedido;
            }
            catch (Exception)
            {
                return;
            }
            
        }

        private void btnEliminarProducto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtIdOrden.Text.Trim() == "" || cboFamilia.SelectedIndex < 0 || cboProducto.SelectedIndex < 0 || cboProveedor.SelectedIndex < 0)
                {
                    MessageBox.Show("No puede dejar campos sin rellenar", "ERROR");
                    return;
                }
                else
                {
                    if (YC.EliminarDetalleOrden(txtIdOrden.Text.Trim(),cboProducto.SelectedValue.ToString()))
                    {
                        MessageBox.Show("Se ha eliminado un producto del detalle de la orden","PRODUCTO ELIMINADO DE LA ORDEN");
                        this.cargarGrillaOrden();
                        this.cargarGrillaProducto(txtIdOrden.Text);
                        return;
                    }
                    else
                    {
                        MessageBox.Show("No se ha encontrado esta orden en la BD","ERROR");
                        return;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void dgGrillaProducto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DetalleOrdenCompra detalleOrden= (DetalleOrdenCompra)dgGrillaProducto.SelectedItem;
                cboProveedor.SelectedValue = detalleOrden.Id_proveedor;
                cboFamilia.SelectedValue = detalleOrden.Id_familia;
                cboProducto.ItemsSource = YC.ObtenerProductoFiltrado(detalleOrden.Id_proveedor, detalleOrden.Id_familia);
                cboProducto.SelectedValue = detalleOrden.Id_producto;
                txtCantidad.Text = detalleOrden.Cantidad_pack.ToString();
            }
            catch (Exception)
            {

                return;
            }
        }

        private void btnEliminarOrden_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtIdOrden.Text.Trim()=="")
                {
                    MessageBox.Show("Rellene el campo del numero de orden");
                    return;
                }
                else
                {
                    if (YC.LaOrdenNoFueEntregada(txtIdOrden.Text))
                    {
                        if (YC.EliminarOrden(txtIdOrden.Text))
                        {
                            MessageBox.Show("Se ha eliminado la orden correctamente","ORDEN ELIMINADA");
                            this.cargarGrillaOrden();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("La orden que intenta eliminar tiene registros en otra tabla", "ERROR");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ingrese una orden de compra correcta y que no haya sido recepcionada", "ERROR");
                        return;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnVerInventario_Click(object sender, RoutedEventArgs e)
        {
            Inventario.getInstance().Show();
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Menu.getInstance().Show();
            ventanaRegistroOrden = null;
        }
    }
}
