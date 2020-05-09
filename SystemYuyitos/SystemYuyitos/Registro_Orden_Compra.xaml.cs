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
    /// Lógica de interacción para Registro_Orden_Compra.xaml
    /// </summary>
    public partial class Registro_Orden_Compra : MetroWindow
    {
        public Registro_Orden_Compra()
        {
            InitializeComponent();
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Close();
        }
    }
}
