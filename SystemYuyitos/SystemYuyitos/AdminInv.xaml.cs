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
        public AdminInv()
        {
            InitializeComponent();
            this.cargarGrilla();
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
                    prod.IdProducto = txtCodigo.Text;
                    prod.NombreProd = txtNombreProd.Text;
                    prod.PrecioVenta = 1;
                    prod.IdTipoProducto = 1;
                    prod.Cantidad = 1;
                    prod.FechaElaboracion = dpFecha.SelectedDate.Value;
                    prod.FechaVencimiento = dpFecha_venc.SelectedDate.Value;
                    prod.FechaIngreso = DateTime.Today;

                    if (YC.IngresarProducto(prod))
                    {
                        MessageBox.Show("La orden ha sido ingresada exitosamente", "ORDEN AGREGADA");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error, contacte a un tecnico a la brevedad", "ERROR");
                    }

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
            Menu menu = new Menu();
            menu.Show();
            this.Close();
        }

        private void BtnLimpiar_Click(object sender, RoutedEventArgs e)
        {
           
            

        }
    }
}
