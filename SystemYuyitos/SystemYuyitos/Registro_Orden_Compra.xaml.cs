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
    public partial class Registro_Orden_Compra : MetroWindow
    {
        private YuyitosCollection YC = new YuyitosCollection();
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

        private void btnIngresarProducto_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCrearOrden_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dpFechaEntrega.SelectedDate == null || txtRutAdmin.Text =="")
                {
                    MessageBox.Show("Ingrese la informacion correctamente", "ERROR");
                    return;
                }
                else
                {
                    if (dpFechaEntrega.SelectedDate.Value < DateTime.Now.AddDays(-1))
                    {
                        MessageBox.Show("La fecha de entrega no puede ser antes de la fecha de hoy", "ERROR FECHA RETIRO");
                        return;
                    }
                    OrdenCompra ordenCompra = new OrdenCompra();
                    ordenCompra.Rut_administrador = txtRutAdmin.Text;
                    ordenCompra.Id_orden_pedido = 1;
                    ordenCompra.Fecha_orden = DateTime.Now;
                    ordenCompra.Fecha_entrega = dpFechaEntrega.SelectedDate.Value;
                    ordenCompra.Valor_final = 0;
                    ordenCompra.Id_estado_orden = 1;
                    if (YC.CrearOrdenCompra(ordenCompra))
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

                throw;
            }
        }
    }
}
