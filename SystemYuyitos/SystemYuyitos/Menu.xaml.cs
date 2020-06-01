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
        public static Menu ventanaMenu;
        public Menu()
        {
            InitializeComponent();
        }
        public static Menu getInstance()
        {
            if (ventanaMenu == null)
            {
                ventanaMenu = new Menu();
            }

            return ventanaMenu;
        }

        private void btnInventario(object sender, RoutedEventArgs e)
        {
            AdminInv.getInstance().Show();
            ventanaMenu = null;
            this.Close();
        }

        private void btnProveedor(object sender, RoutedEventArgs e)
        {
            AdminProv.getInstance().Show();
            ventanaMenu = null;
            this.Close();
        }

        private void btnInformes(object sender, RoutedEventArgs e)
        {
            Generar_Informe.getInstance().Show();
            ventanaMenu = null;
            this.Close();

        }

        private void btnOrden(object sender, RoutedEventArgs e)
        {
            Registro_Orden_Compra.getInstance().Show();
            ventanaMenu = null;
            this.Close();

        }

        private void btnRecepcion(object sender, RoutedEventArgs e)
        {
            Recepcion_Orden_Compra.getInstance().Show();
            ventanaMenu = null;
            this.Close();

        }

    }
}

