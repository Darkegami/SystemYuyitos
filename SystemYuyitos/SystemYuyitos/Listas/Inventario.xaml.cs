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
    public partial class Inventario : MetroWindow
    {

        private YuyitosCollection YC = new YuyitosCollection();
        public static Inventario ventanaInventario;

        public Inventario()
        {
            InitializeComponent();
            this.cargarGrilla();
        }

        public static Inventario getInstance()
        {
            if (ventanaInventario == null)
            {
                ventanaInventario = new Inventario();
            }

            return ventanaInventario;
        }

        private void cargarGrilla()
        {
            dgProducto.ItemsSource = null;
            dgProducto.ItemsSource = YC.ListaProducto();
        }


        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
           
        }


        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            Registro_Orden_Compra.getInstance().Show();
            ventanaInventario = null;
            this.Close();
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Registro_Orden_Compra.getInstance().Show();
            ventanaInventario = null;
        }
    }
}
