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
    /// Lógica de interacción para Proveedor.xaml
    /// </summary>
    public partial class AdminProv : MetroWindow
    {
        private YuyitosCollection _coleccion = new YuyitosCollection();

        public AdminProv()
        {
            InitializeComponent();
            
        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {

            string iDProv = txtIdProveedor.Text;

            int telefono = 0;
            if (int.TryParse(txtTelefonoProv.Text, out telefono) == false)
            {
                MessageBox.Show("El Télefono debe ser números", "¡Error!");
                return;
            }

            string nombre = txtNombreProv.Text;
            string sucursal = txtSucursal.Text;
            string direccion = txtDireccionProv.Text;
          

            Proveedor prove = new Proveedor();
            prove.IDProv = iDProv;
            prove.NombreProv = nombre;
            prove.Sucursal = sucursal;
            prove.Telefono = telefono;
            prove.Direccion = direccion;

            if (_coleccion.GuardarProveedor(prove))
            {
                MessageBox.Show("Guardado Correctamente");
            }
            else
            {
                MessageBox.Show("El Proveedor ya existe");
            }

            CargarGrilla();
        }

        private void CargarGrilla()
        {
            dgProveedor.ItemsSource = null;
            dgProveedor.ItemsSource = _coleccion.proveedores;
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            string iDProv = txtIdProveBuscar.Text;
            if(iDProv.Trim() == "")
            {
                MessageBox.Show("Debes ingresar un Proveedor");
                    return;
            }
            Proveedor prov = _coleccion.BuscarProveedor(iDProv);

            if(prov == null)
            {
                MessageBox.Show("No se ha encontrado el Proveedor", "¡Error!");
                return;
            }

            txtNombreProv.Text = prov.NombreProv;
            txtTelefonoProv.Text = prov.Telefono.ToString();
            txtSucursal.Text = prov.Sucursal;
            txtDireccionProv.Text = prov.Direccion;


        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            string iDProv = txtIdProveedor.Text;
            if(iDProv.Trim() == "")
            {
                MessageBox.Show("Debes ingresar un Proveedor", "¡Atención!");
                return;
            }
            if (_coleccion.EliminarProveedor(iDProv))
            {
                MessageBox.Show("Eliminado Correctamente");
                CargarGrilla();
            }
            else
            {
                MessageBox.Show("No se ha encontrado la patente", "¡Error!");
            }
        }

        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            string iDProv = txtIdProveedor.Text;

            int telefono = 0;
            if (int.TryParse(txtTelefonoProv.Text, out telefono) == false)
            {
                MessageBox.Show("El Télefono debe ser números", "¡Error!");
                return;
            }

            string nombre = txtNombreProv.Text;
            string sucursal = txtSucursal.Text;
            string direccion = txtDireccionProv.Text;
        


            Proveedor prove = _coleccion.BuscarProveedor(iDProv);
            if(prove == null)
            {
                MessageBox.Show("No se ha encontrado el Proveedor", "¡Error!");
                return;
            }

            prove.IDProv = iDProv;
            prove.NombreProv = nombre;
            prove.Sucursal = sucursal;
            prove.Telefono = telefono;
            prove.Direccion = direccion;

            MessageBox.Show("Modificado Correctamente");

            CargarGrilla();
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Close();
        }

        private void BtnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtIdProveedor.Text = string.Empty;
            txtNombreProv.Text = string.Empty;
            txtSucursal.Text = string.Empty;
            txtDireccionProv.Text = string.Empty;
            txtTelefonoProv.Text = string.Empty;
            txtIdProveBuscar.Text = string.Empty;
        }
    }
    
}
