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

namespace SystemYuyitos
{
    /// <summary>
    /// Lógica de interacción para Menu.xaml
    /// </summary>
    public partial class Menu : MetroWindow
    {
        public Menu()
        {
            InitializeComponent();
        }
        private void btnInventario(object sender, RoutedEventArgs e)
        {
            AdminInv inv = new AdminInv();
            inv.Show();
            this.Close();
        }

        private void btnProveedor(object sender, RoutedEventArgs e)
        {
            AdminProv prov = new AdminProv();
            prov.Show();
            this.Close();
        }

        private void btnInformes(object sender, RoutedEventArgs e)
        {
            Generar_Informe ventanaInforme = new Generar_Informe();
            ventanaInforme.Show();
            this.Close();

        }

        private void btnOrden(object sender, RoutedEventArgs e)
        {
            Registro_Orden_Compra ventanaOrden = new Registro_Orden_Compra();
            ventanaOrden.Show();
            this.Close();

        }

        private void btnRecepcion(object sender, RoutedEventArgs e)
        {
            Recepcion_Orden_Compra ventanaRecepcion = new Recepcion_Orden_Compra();
            ventanaRecepcion.Show();
            this.Close();

        }
    }
}

