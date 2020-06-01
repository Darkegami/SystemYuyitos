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
    public partial class AdminInv : MetroWindow
    {

        private YuyitosCollection YC = new YuyitosCollection();
        public static AdminInv ventanaInventario;
        public AdminInv()
        {
            InitializeComponent();
            this.cargarGrilla();
        }

        public static AdminInv getInstance()
        {
            if (ventanaInventario == null)
            {
                ventanaInventario = new AdminInv();
            }

            return ventanaInventario;
        }

        private void cargarGrilla()
        {
            dgProducto.ItemsSource = null;
            dgProducto.ItemsSource = YC.ListaProducto();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dpFecha_ingreso.SelectedDate == null || txtCodigo.Text == "")
                {
                    MessageBox.Show("Ingrese la informacion correctamente", "ERROR");
                    return;
                }
                else
                {
                    if (dpFecha_ingreso.SelectedDate.Value < DateTime.Now.AddDays(-1))
                    {
                        MessageBox.Show("La fecha de Ingreso no puede ser antes de la fecha de hoy", "ERROR FECHA RETIRO");
                        return;
                    }
                    Producto prod = new Producto();

                    prod.Id_producto = txtCodigo.Text;
                    prod.NombreProd = txtNombreProd.Text;
                    prod.Precio_venta = 1;

                    if (YC.IngresarProducto(prod))
                    {
                        MessageBox.Show("El Producto ha sido ingresado exitosamente", "PRODUCTO AGREGADO");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error, contacte a un tecnico a la brevedad", "ERROR");
                    }
                    cargarGrilla();

                }

            }
            catch (Exception error)
            {

                MessageBox.Show("Ha ocurrido un error, contacte a un tecnico a la brevedad", "ERROR");
                return;
            }
        }
    


        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
     
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            Menu.getInstance().Show();
            ventanaInventario = null;
            this.Close();
        }

        private void BtnLimpiar_Click(object sender, RoutedEventArgs e)
        {
           
            

        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Menu.getInstance().Show();
            ventanaInventario = null;
        }
    }
}
