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
using System.Data.OracleClient;

namespace SystemYuyitos
{
    /// <summary>
    /// Lógica de interacción para AdminInv.xaml
    /// </summary>
    public partial class AdminInv : MetroWindow
    {

        private YuyitosCollection YC = new YuyitosCollection();
        public static AdminInv ventanaInventario;
        public AdminInv()
        {
            InitializeComponent();
            this.cargarGrilla();
            cboFamiliaProducto.ItemsSource = YC.ListaFamilia();
            cboProveedor.ItemsSource = YC.ListaProveedor();
            cboTipoProducto.ItemsSource = YC.ListaTipoProducto();
           
        }

        public static AdminInv getInstance()
        {
            if (ventanaInventario == null)
            {
                ventanaInventario = new AdminInv();
            }

            return ventanaInventario;
        }

        private void cargarGrilla()
        {
            dgProducto.ItemsSource = null;
            dgProducto.ItemsSource = YC.ListaProducto();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtCodigo.Text == "" || txtNombreProd.Text == "" || dpFechaElaboracion.SelectedDate == null || dpFechaVencimiento.SelectedDate == null || txtPrecioVenta.Text == "" || txtPrecioCompra.Text == "" || txtStock.Text == ""
                   || cboFamiliaProducto.SelectedIndex < 0 || cboProveedor.SelectedIndex < 0 || cboTipoProducto.SelectedIndex < 0)
                {
                    MessageBox.Show("No puede dejar campos sin llenar", "ERROR");
                    return;
                }
                else
                {
                    Producto producto = new Producto();
                    producto.Id_producto = txtCodigo.Text;
                    producto.NombreProd = txtNombreProd.Text;
                    producto.Fecha_elaboracion = dpFechaElaboracion.SelectedDate.Value;
                    producto.Fecha_vencimiento = dpFechaVencimiento.SelectedDate.Value;
                    producto.Precio_venta = int.Parse(txtPrecioVenta.Text);
                    producto.Precio_compra = int.Parse(txtPrecioCompra.Text);
                    producto.Stock = int.Parse(txtStock.Text);
                    producto.Id_Familia = (int)cboFamiliaProducto.SelectedValue;
                    producto.Id_Proveedor = (int)cboProveedor.SelectedValue;
                    producto.Id_TipoProd = (int)cboTipoProducto.SelectedValue;

                    if (YC.IngresarProducto(producto))
                    {
                        MessageBox.Show("Se ha ingresado el producto exitosamente", "PRODUCTO INGRESADO");
                        this.cargarGrilla();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error, contacte a un técnico a la brevedad", "ERROR");
                        return;
                    }
                }
            }
            catch (Exception error)
            {
                throw;
            }
        }
    

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(txtBuscarProd.Text== "")
                {
                    MessageBox.Show("Ingrese el código del Producto antes de buscar", "ERROR");
                    return;
                }
                else
                {
                    string v_id_producto;
                    try
                    {
                        v_id_producto = txtBuscarProd.Text;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ingrese solo números en el campo del código del producto", "ERROR");
                        return;
                    }

                    Producto producto = YC.BuscarProducto(v_id_producto);
                    if (producto == null)
                    {
                        MessageBox.Show("El código del producto ingresado no se encuentra en la BD", "ERROR");
                        return;
                    }
                    else
                    {
                        txtCodigo.Text = producto.Id_producto.ToString();
                        txtNombreProd.Text = producto.NombreProd;
                        dpFechaElaboracion.SelectedDate = producto.Fecha_elaboracion;
                        dpFechaVencimiento.SelectedDate = producto.Fecha_vencimiento;
                        txtPrecioVenta.Text = producto.Precio_venta.ToString();
                        txtPrecioCompra.Text = producto.Precio_compra.ToString();
                        txtStock.Text = producto.Stock.ToString();
                        cboFamiliaProducto.SelectedValue = producto.Familia.Id_familia;
                        cboProveedor.SelectedValue = producto.Proveedor.IDProv;
                        cboTipoProducto.SelectedValue = producto.Tipo_producto.Id_tipo_producto;

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(txtBuscarProd.Text == "")
                {
                    MessageBox.Show("Ingrese el código del Producto antes de modificar", "ERROR");
                    return;
                }
                if (txtBuscarProd.Text == "" || txtNombreProd.Text == "" || dpFechaElaboracion.SelectedDate == null || dpFechaVencimiento.SelectedDate == null || txtPrecioVenta.Text == "" || txtPrecioCompra.Text == "" || txtStock.Text == ""
                   || cboFamiliaProducto.SelectedIndex < 0 || cboProveedor.SelectedIndex < 0 || cboTipoProducto.SelectedIndex < 0)
                {
                    MessageBox.Show("No puede dejar campos sin llenar", "ERROR");
                    return;
                }
                else
                {
                    Producto producto = new Producto();
                    string v_id_producto;
                    v_id_producto = txtBuscarProd.Text;
                    
                   
                   
                   
                    producto.NombreProd = txtNombreProd.Text;
                    producto.Fecha_elaboracion = dpFechaElaboracion.SelectedDate.Value;
                    producto.Fecha_vencimiento = dpFechaVencimiento.SelectedDate.Value;
                    producto.Precio_venta = int.Parse(txtPrecioVenta.Text);
                    producto.Precio_compra = int.Parse(txtPrecioCompra.Text);
                    producto.Stock = int.Parse(txtStock.Text);
                    producto.Id_Familia = (int)cboFamiliaProducto.SelectedValue;
                    producto.Id_Proveedor = (int)cboProveedor.SelectedValue;
                    producto.Id_TipoProd = (int)cboTipoProducto.SelectedValue;

                    if (YC.ModificarProducto(producto))
                    {
                        MessageBox.Show("Se ha modificado el Producto exitosamente", "PRODUCTO MODIFICADO");
                        this.cargarGrilla();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error, contacte a un técnico a la brevedad", "ERROR");
                        return;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
          
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtBuscarProd.Text == "")
                {
                    MessageBox.Show("Ingrese el código del producto antes de eliminar", "ERROR");
                    return;
                }
                else
                {
                    string v_id_producto;
                    try
                    {
                        v_id_producto = txtBuscarProd.Text;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ingrese solo números en el campo del código del producto", "ERROR");
                        return;
                    }
                    if (YC.EliminarProducto(v_id_producto))
                    {
                        MessageBox.Show("Se ha eliminado el Producto exitosamente", "PRODUCTO ELIMINADO");
                        this.cargarGrilla();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("El Producto que intenta eliminar no existe o tiene registros en otra tabla", "ERROR");
                        return;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }


        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            Menu.getInstance().Show();
            ventanaInventario = null;
            this.Close();
        }

        private void BtnLimpiar_Click(object sender, RoutedEventArgs e)
        {
           
            

        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Menu.getInstance().Show();
            ventanaInventario = null;
        }

        private void DgProducto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Producto producto = (Producto)dgProducto.SelectedItem;
                txtCodigo.Text = producto.Id_producto.ToString();
                txtNombreProd.Text = producto.NombreProd;
                dpFechaElaboracion.SelectedDate = producto.Fecha_elaboracion;
                dpFechaVencimiento.SelectedDate = producto.Fecha_vencimiento;
                txtPrecioVenta.Text = producto.Precio_venta.ToString();
                txtPrecioCompra.Text = producto.Precio_compra.ToString();
                txtStock.Text = producto.Stock.ToString();
                cboFamiliaProducto.SelectedValue = producto.Familia.Id_familia;
                cboProveedor.SelectedValue = producto.Proveedor.IDProv;
                cboTipoProducto.SelectedValue = producto.Tipo_producto.Id_tipo_producto;

            }
            catch (Exception)
            {
                return;
            }
             
            
        }

    }
}
