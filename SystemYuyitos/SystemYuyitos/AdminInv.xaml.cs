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
    /// Lógica de interacción para AdminInv.xaml
    /// </summary>
    public partial class AdminInv : MetroWindow
    {
        private YuyitosCollection _coleccion = new YuyitosCollection();
        public AdminInv()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string nombreProd = txtNombreProd.Text;
            string codigo = txtCodigo.Text;
            string categoria = txtCategoria.Text;
            int precio = 0;
            if (int.TryParse(txtPrecio.Text, out precio) == false)
            {
                MessageBox.Show("El Precio debe estar compuesto solo de Números", "¡Error!");
                return;
            }
            int total = 0;
            if (int.TryParse(txtTotal.Text, out total) == false)
            {
                MessageBox.Show("El Total debe estar compuesto solo de Números", "¡Error!");
                return;
            }
            DateTime fecha = DateTime.Parse(dpFecha.Text);
          

            Producto prod = new Producto();
            prod.NombreProd = nombreProd;
            prod.Codigo = codigo;
            prod.Categoria = categoria;
            prod.Precio = precio;
            prod.Total = total;
            prod.Fecha = fecha;

            if (_coleccion.GuardarProducto(prod))
            {
                MessageBox.Show("Guardado Correctamente");
            }
            else
            {
                MessageBox.Show("El Código ya existe", "¡Error!");
            }
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            dgProducto.ItemsSource = null;
            dgProducto.ItemsSource = _coleccion.productos;
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            string codigo = txtBuscarProd.Text;
            if (codigo.Trim() == "")
            {
                MessageBox.Show("Debes ingresar un Código", "¡Atención!");
                return;
            }
            Producto prod = _coleccion.BuscarProducto(codigo);

            if (prod == null)
            {
                MessageBox.Show("No se ha encontrado el Código", "¡Error!");
                return;
            }

            txtNombreProd.Text = prod.NombreProd;
            txtCategoria.Text = prod.Categoria;
            txtPrecio.Text = prod.Precio.ToString();
            txtTotal.Text = prod.Total.ToString();
            dpFecha.Text = prod.Fecha.ToString();
        }

        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            string nombreProd = txtNombreProd.Text;
            string codigo = txtCodigo.Text;
            string categoria = txtCategoria.Text;
            int precio = 0;
            if (int.TryParse(txtPrecio.Text, out precio) == false)
            {
                MessageBox.Show("El Precio debe estar compuesto solo de Números", "¡Error!");
                return;
            }
            int total = 0;
            if (int.TryParse(txtTotal.Text, out total) == false)
            {
                MessageBox.Show("El Total debe estar compuesto solo de Números", "¡Error!");
                return;
            }
            DateTime fecha = DateTime.Parse(dpFecha.Text);
   
        

            Producto prod = _coleccion.BuscarProducto(codigo);
            if (prod == null)
            {
                MessageBox.Show("No se ha encontrado el Producto", "¡Error!");
                return;
            }

            prod.NombreProd = nombreProd;
            prod.Codigo = codigo;
            prod.Categoria = categoria;
            prod.Precio = precio;
            prod.Total = total;
            prod.Fecha = fecha;

            MessageBox.Show("Modificado Correctamente");
            
            CargarGrilla();
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            string codigo = txtCodigo.Text;
            if (codigo.Trim() == "")
            {
                MessageBox.Show("Debes ingresar un Código", "¡Atención!");
                return;
            }
            if (_coleccion.EliminarProducto(codigo))
            {
                MessageBox.Show("Eliminado Correctamente");
                CargarGrilla();
            }
            else
            {
                MessageBox.Show("No se ha encontrado el Código", "¡Error!");
            }
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Close();
        }

        private void BtnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtNombreProd.Text = string.Empty;
            txtCodigo.Text = string.Empty;
            txtCategoria.Text = string.Empty;
            txtPrecio.Text = string.Empty;
            txtTotal.Text = string.Empty;
            txtBuscarProd.Text = string.Empty;
            dpFecha.Text = string.Empty;
            

        }
    }
}
