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
        private YuyitosCollection YC = new YuyitosCollection();
        public static AdminProv ventanaProveedor;

        public AdminProv()
        {
            InitializeComponent();
            this.cargarGrilla();
            
        }

        public static AdminProv getInstance()
        {
            if (ventanaProveedor == null)
            {
                ventanaProveedor = new AdminProv();
            }

            return ventanaProveedor;
        }

        private void cargarGrilla()
        {
            dgProveedoor.ItemsSource = null;
            dgProveedoor.ItemsSource = YC.ListaProveedor();


        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtIdProveedor.Text == " ")
                {
                    MessageBox.Show("Ingrese la informacion correctamente", "ERROR");
                    return;
                }
                else
                {

                    Proveedor prov = new Proveedor();

                    prov.IDProv = 1;
                    prov.NombreProv = txtNombreProv.Text;
                    prov.Telefono = 1;
                    prov.Id_comuna = cbComuna.SelectedIndex;
                    prov.Direccion = txtDireccionProv.Text;

                    cargarGrilla();
                    if (YC.IngresarProveedor(prov))
                    {
                        MessageBox.Show("El Proveedor ha sido ingresado exitosamente", "PROVEEDOR AGREGADO");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error, contacte a un tecnico a la brevedad", "ERROR");
                    }
                    
                }

             }catch (Exception error){
                MessageBox.Show("Ha ocurrido un error, contacte a un tecnico a la brevedad", "ERROR");
                return;
            }
          
         }


        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
           


        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
         
        }

        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            Menu.getInstance().Show();
            this.Close();
        }

        private void BtnLimpiar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
    
}
