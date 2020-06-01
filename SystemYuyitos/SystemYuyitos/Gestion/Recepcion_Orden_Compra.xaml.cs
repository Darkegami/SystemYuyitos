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
    /// Lógica de interacción para Recepcion_Orden_Compra.xaml
    /// </summary>
    public partial class Recepcion_Orden_Compra : MetroWindow
    {
        public static Recepcion_Orden_Compra ventanaRecepcionOrden;
        private YuyitosCollection YC = new YuyitosCollection();

        public Recepcion_Orden_Compra()
        {
            InitializeComponent();
            this.cargarGrillaRecepcion();
        }

        public void cargarGrillaRecepcion()
        {
            dgGrillaRecepcion.ItemsSource = null;
            dgGrillaRecepcion.ItemsSource = YC.ListaRecepcionCompra();
        }

        public static Recepcion_Orden_Compra getInstance()
        {
            if (ventanaRecepcionOrden  == null)
            {
                ventanaRecepcionOrden = new Recepcion_Orden_Compra();
            }

            return ventanaRecepcionOrden;
        }

        private void cargarGrillaProducto(string id_orden)
        {
            dgGrillaProducto.ItemsSource = null;
            dgGrillaProducto.ItemsSource = YC.ListaDetalleOrden(id_orden);
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            Menu.getInstance().Show();
            ventanaRecepcionOrden = null;
            this.Close();
        }

        private void dgGrillaProducto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public void cargarNroOrden(OrdenCompra ordenCompra)
        {
            txtIdOrden.Text = ordenCompra.Id_orden_pedido;
        }

        private void btnListarOrdenes_Click(object sender, RoutedEventArgs e)
        {
            Lista_Orden_Compra.getInstance().Show();
        }

        private void txtIdOrden_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.cargarGrillaProducto(txtIdOrden.Text);
        }

        private void btnConfirmarRecepcion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtIdOrden.Text.Trim() == "" || txtComentarios.Text.Trim() == "" || txtRutAdmin.Text.Trim() == "" || dpFechaRecepcion.SelectedDate == null)
                {
                    MessageBox.Show("No puede dejar campos sin rellenar", "ERROR");
                    return;
                }
                else
                {
                    if (dpFechaRecepcion.SelectedDate.Value < DateTime.Now.AddDays(-1))
                    {
                        MessageBox.Show("La fecha de recepcion no puede ser antes de la fecha de hoy", "ERROR FECHA RECEPCION");
                        return;
                    }
                    else
                    {
                        if (YC.LaOrdenFueEntregada(txtIdOrden.Text))
                        {
                            MessageBox.Show("Ingrese una orden que no haya sido entregada", "ERROR");
                            return;
                        }
                        else
                        {
                            if (YC.LaOrdenNoFueEntregada(txtIdOrden.Text))
                            {
                                if (YC.ComprobarExistenciaDetalleOrden(txtIdOrden.Text))
                                {
                                    if (YC.ComprobarExistenciaAdministrador(txtRutAdmin.Text))
                                    {
                                        RecepcionCompra recepcion = new RecepcionCompra();
                                        recepcion.Comentarios = txtComentarios.Text;
                                        recepcion.Fecha_recepcion = dpFechaRecepcion.SelectedDate.Value;
                                        recepcion.Id_recepcion_compra = string.Format("{0:yyyyMMddHHmm}", DateTime.Now);
                                        recepcion.Id_estado_recepcion = 1;
                                        recepcion.Id_orden_compra = txtIdOrden.Text;
                                        recepcion.Rut_administrador = txtRutAdmin.Text;
                                        if (YC.ConfirmarRecepcion(recepcion))
                                        {
                                            MessageBox.Show("La recepcion de la orden de compra fue confirmada correctamente", "RECEPCION CONFIRMADA");
                                            this.cargarGrillaRecepcion();
                                            return;
                                        }
                                        else
                                        {
                                            MessageBox.Show("Ha ocurrido un error, contacte a un tecnico a la brevedad", "ERROR");
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("El rut de administrador no coincide con ninguno de nuestros registros", "ERROR");
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("La orden ingresada no contiene productos en su detalle","ERROR");
                                    return;
                                }
                               
                            }
                            else
                            {
                                MessageBox.Show("Ingrese una orden de compra que ya este creada", "ERROR");
                                return;
                            }

                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        private void btnDenegarRecepcion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtIdOrden.Text.Trim() == "" || txtComentarios.Text.Trim() == "" || txtRutAdmin.Text.Trim() == "" || dpFechaRecepcion.SelectedDate == null)
                {
                    MessageBox.Show("No puede dejar campos sin rellenar", "ERROR");
                    return;
                }
                else
                {
                    if (dpFechaRecepcion.SelectedDate.Value < DateTime.Now.AddDays(-1))
                    {
                        MessageBox.Show("La fecha de recepcion no puede ser antes de la fecha de hoy", "ERROR FECHA RECEPCION");
                        return;
                    }
                    else
                    {
                        if (YC.LaOrdenFueEntregada(txtIdOrden.Text.Trim()))
                        {
                            MessageBox.Show("Ingrese una orden que no haya sido entregada", "ERROR");
                            return;
                        }
                        else
                        {
                            if (YC.LaOrdenNoFueEntregada(txtIdOrden.Text.Trim()))
                            {
                                if (YC.ComprobarExistenciaDetalleOrden(txtIdOrden.Text.Trim()))
                                {
                                    if (YC.ComprobarExistenciaAdministrador(txtRutAdmin.Text.Trim()))
                                    {
                                        RecepcionCompra recepcion = new RecepcionCompra();
                                        recepcion.Comentarios = txtComentarios.Text;
                                        recepcion.Fecha_recepcion = dpFechaRecepcion.SelectedDate.Value;
                                        recepcion.Id_recepcion_compra = string.Format("{0:yyyyMMddHHmm}", DateTime.Now);
                                        recepcion.Id_estado_recepcion = 2;
                                        recepcion.Id_orden_compra = txtIdOrden.Text;
                                        recepcion.Rut_administrador = txtRutAdmin.Text;
                                        if (YC.DenegarRecepcion(recepcion))
                                        {
                                            MessageBox.Show("La recepcion de la orden de compra fue denegada correctamente", "RECEPCION DENEGADA");
                                            this.cargarGrillaRecepcion();
                                            return;
                                        }
                                        else
                                        {
                                            MessageBox.Show("Ha ocurrido un error, contacte a un tecnico a la brevedad", "ERROR");
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("El rut de administrador no coincide con ninguno de nuestros registros","ERROR");
                                        return;
                                    }
                                    
                                }
                                else
                                {
                                    MessageBox.Show("La orden ingresada no contiene productos en su detalle", "ERROR");
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Ingrese una orden de compra que ya este creada", "ERROR");
                                return;
                            }

                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Menu.getInstance().Show();
            ventanaRecepcionOrden = null;
        }
    }
}
