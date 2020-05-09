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

        public static Generar_Informe ventana_Informes;
        public static Menu menu;
        public static Generar_Informe getInstance()
        {
            if (ventana_Informes == null)
            {
                ventana_Informes = new Generar_Informe();
            }
            return ventana_Informes;

           
        }

        public Generar_Informe()
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
