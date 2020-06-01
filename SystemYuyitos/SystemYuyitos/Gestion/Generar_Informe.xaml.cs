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
    /// Lógica de interacción para Generar_Informe.xaml
    /// </summary>
    public partial class Generar_Informe : MetroWindow
    {

        public static Generar_Informe ventanaInformes;

        public static Generar_Informe getInstance()
        {
            if (ventanaInformes == null)
            {
                ventanaInformes = new Generar_Informe();
            }

            return ventanaInformes;
        }

        public Generar_Informe()
        {
            InitializeComponent();
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            Menu.getInstance().Show();
            ventanaInformes = null;
            this.Close();  

        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Menu.getInstance().Show();
            ventanaInformes = null;
        }
    }
}
