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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using MahApps.Metro.Behaviours;
using MahApps.Metro.Controls.Dialogs;

namespace SystemYuyitos
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnIngresar_Click(object sender, RoutedEventArgs e)
        {
            if (txtUsuario.Text != string.Empty)
            {
                if (pbContrasenia.Password != string.Empty)
                {
                    if (txtUsuario.Text == "admin")
                    {
                        if (pbContrasenia.Password == "admin")
                        {
                            Menu menu = new Menu();
                            menu.Show();
                            this.Close();

                        }
                        else
                        {
                            MessageBox.Show( "Contraseña Incorrecta", "¡Error!"); 
                        }

                    }
                    else

                    {
                        MessageBox.Show("Usuario Incorrecto", "¡Error!");
                    }
                }
                else
                {
                    MessageBox.Show("Debe ingresar Contraseña", "¡Atención!");
                }

            }
            else
            {
                MessageBox.Show("Debe ingresar Usuario", "¡Atención!");
            }
        }
    }
}
