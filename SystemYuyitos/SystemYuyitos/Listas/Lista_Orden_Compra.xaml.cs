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
    public partial class Lista_Orden_Compra : MetroWindow
    {
        private YuyitosCollection YC = new YuyitosCollection();
        public static Lista_Orden_Compra ventanaListaOrden;

        public Lista_Orden_Compra()
        {
            InitializeComponent();
            this.cargarGrillaOrden();

        }

        public static Lista_Orden_Compra getInstance()
        {
            if (ventanaListaOrden == null)
            {
                ventanaListaOrden = new Lista_Orden_Compra();
            }

            return ventanaListaOrden;
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            Recepcion_Orden_Compra.getInstance().Show();
            ventanaListaOrden = null;
            this.Close();
        }

        private void cargarGrillaOrden()
        {
            dgGrillaOrden.ItemsSource = null;
            dgGrillaOrden.ItemsSource = YC.ListaOrdenCompra();
        }

        private void dgGrillaOrden_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OrdenCompra ordenCompra = new OrdenCompra();
            try
            {
                ordenCompra = (OrdenCompra)dgGrillaOrden.SelectedItem;
                Recepcion_Orden_Compra.getInstance().cargarNroOrden(ordenCompra);
                this.Close();

            }
            catch (Exception)
            {

                return;
            }
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Recepcion_Orden_Compra.getInstance().Show();
            ventanaListaOrden = null;
        }
    }
}
