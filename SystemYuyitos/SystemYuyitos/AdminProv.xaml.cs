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

            
        }

        private void CargarGrilla()
        {
            dgProveedor.ItemsSource = null;
            
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
            Menu menu = new Menu();
            menu.Show();
            this.Close();
        }

        private void BtnLimpiar_Click(object sender, RoutedEventArgs e)
        {
        }
    }
    
}
