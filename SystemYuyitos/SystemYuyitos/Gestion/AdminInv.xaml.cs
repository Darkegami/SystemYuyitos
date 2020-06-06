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
using Microsoft.Win32;
using System.IO;

namespace SystemYuyitos
{
    /// <summary>
    /// Lógica de interacción para AdminInv.xaml
    /// </summary>
    public partial class AdminInv : MetroWindow
    {

        private YuyitosCollection YC = new YuyitosCollection();
        private OpenFileDialog ofdSeleccionar = new OpenFileDialog();
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
        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ( txtNombreProd.Text == "" || dpFechaElaboracion.SelectedDate == null || dpFechaVencimiento.SelectedDate == null || txtPrecioVenta.Text == "" || txtPrecioCompra.Text == "" || txtStock.Text == ""
                   || cboFamiliaProducto.SelectedIndex < 0 || cboProveedor.SelectedIndex < 0 || cboTipoProducto.SelectedIndex < 0)
                {
                    MessageBox.Show("No puede dejar campos sin llenar", "ERROR");
                    return;
                }
                else
                {
                    Producto producto = new Producto();
                    producto.NombreProd = txtNombreProd.Text;
                    producto.Fecha_elaboracion = dpFechaElaboracion.SelectedDate.Value;
                    producto.Fecha_vencimiento = dpFechaVencimiento.SelectedDate.Value;
                    producto.Precio_venta = int.Parse(txtPrecioVenta.Text);
                    producto.Precio_compra = int.Parse(txtPrecioCompra.Text);
                    producto.Stock = int.Parse(txtStock.Text);
                    producto.Id_familia = (int)cboFamiliaProducto.SelectedValue;
                    producto.Id_proveedor = (int)cboProveedor.SelectedValue;
                    producto.Id_tipo_prod = (int)cboTipoProducto.SelectedValue;
                    try
                    {
                       
                        string imagePath = @"" + ofdSeleccionar.FileName;
                        string imgBase64String = GetBase64StringForImage(imagePath);
                        producto.Imagen = imgBase64String;
                    }
                    catch (Exception)
                    {
                        producto.Imagen = null;
                    }

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
                      
                        txtNombreProd.Text = producto.NombreProd;
                        dpFechaElaboracion.SelectedDate = producto.Fecha_elaboracion;
                        dpFechaVencimiento.SelectedDate = producto.Fecha_vencimiento;
                        txtPrecioVenta.Text = producto.Precio_venta.ToString();
                        txtPrecioCompra.Text = producto.Precio_compra.ToString();
                        txtStock.Text = producto.Stock.ToString();
                        cboFamiliaProducto.SelectedValue = producto.Familia.Id_familia;
                        cboProveedor.SelectedValue = producto.Proveedor.IDProv;
                        cboTipoProducto.SelectedValue = producto.Tipo_producto.Id_tipo_producto;
                        string imagen = YC.VerImagen(producto.Id_producto);
                        if (imagen=="")
                        {
                            BitmapImage bi3 = new BitmapImage();
                            bi3.BeginInit();
                            bi3.UriSource = new Uri("/SystemYuyitos;component/Imagenes/imgNoDisponible.png", UriKind.Relative);
                            bi3.EndInit();
                            pbImagen.Source = bi3;
                        }
                        else
                        {

                            byte[] binaryData = Convert.FromBase64String(imagen);

                            BitmapImage bi = new BitmapImage();
                            bi.BeginInit();
                            bi.StreamSource = new MemoryStream(binaryData);
                            bi.EndInit();

                            pbImagen.Source = bi;
                        }
                        

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
                if (txtNombreProd.Text == "" || dpFechaElaboracion.SelectedDate == null || dpFechaVencimiento.SelectedDate == null || txtPrecioVenta.Text == "" || txtPrecioCompra.Text == "" || txtStock.Text == ""
                   || cboFamiliaProducto.SelectedIndex < 0 || cboProveedor.SelectedIndex < 0 || cboTipoProducto.SelectedIndex < 0)
                {
                    MessageBox.Show("No puede dejar campos sin llenar", "ERROR");
                    return;
                }
                else
                {
                    Producto prod = new Producto();
                    prod.Id_producto = txtBuscarProd.Text;
                    prod.NombreProd = txtNombreProd.Text;
                    prod.Fecha_elaboracion = dpFechaElaboracion.SelectedDate.Value;
                    prod.Fecha_vencimiento = dpFechaVencimiento.SelectedDate.Value;
                    prod.Precio_venta = int.Parse(txtPrecioVenta.Text);
                    prod.Precio_compra = int.Parse(txtPrecioCompra.Text);
                    prod.Stock = int.Parse(txtStock.Text);
                    prod.Id_familia = (int)cboFamiliaProducto.SelectedValue;
                    prod.Id_proveedor = (int)cboProveedor.SelectedValue;
                    prod.Id_tipo_prod = (int)cboTipoProducto.SelectedValue;

                    if (YC.ModificarProducto(prod))
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
            txtNombreProd.Text = "";
            txtPrecioCompra.Text = "";
            txtPrecioVenta.Text = "";
            txtStock.Text = "";
            txtBuscarProd.Text = "";
            dpFechaElaboracion.SelectedDate = null;
            dpFechaVencimiento.SelectedDate = null;
            cboFamiliaProducto.SelectedItem = null;
            cboProveedor.SelectedItem = null;
            cboTipoProducto.SelectedItem = null;
            pbImagen.Source = null;

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
                txtBuscarProd.Text = producto.Id_producto;

            }
            catch (Exception)
            {
                return;
            }
             
            
        }

        private void btnSeleccionar_Click(object sender, RoutedEventArgs e)
        {

            ofdSeleccionar.Filter = "Imagenes|*.jpg; *.png";
            ofdSeleccionar.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            ofdSeleccionar.Title = "Seleccionar imagen";
            if (ofdSeleccionar.ShowDialog().Value==true)
            {
                string imagePath = @""+ofdSeleccionar.FileName;
                string imgBase64String = GetBase64StringForImage(imagePath);

                byte[] binaryData = Convert.FromBase64String(imgBase64String);

                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.StreamSource = new MemoryStream(binaryData);
                bi.EndInit();

                pbImagen.Source = bi;
            }
            else
            {
                pbImagen.Source = null;
            }

        }

        protected static string GetBase64StringForImage(string imgPath)
        {
            byte[] imageBytes = System.IO.File.ReadAllBytes(imgPath);
            string base64String = Convert.ToBase64String(imageBytes);
            return base64String;
        }

    }
}
