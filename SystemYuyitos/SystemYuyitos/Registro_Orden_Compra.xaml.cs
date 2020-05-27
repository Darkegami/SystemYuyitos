﻿using System;
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
            this.cargarGrilla();
            cboProveedor.ItemsSource= null;
            cboProveedor.ItemsSource = YC.ListaProveedor();

            cboFamilia.ItemsSource = null;
            cboFamilia.ItemsSource = YC.ListaFamilia();
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Close();
        }

        private void cargarGrilla()
        {
            dgGrillaOrden.ItemsSource = null;
            dgGrillaOrden.ItemsSource = YC.ListaOrdenCompra();
        }


        private void btnIngresarProducto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
            }
            catch (Exception)
            {

                throw;
            }
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
                    ordenCompra.Id_orden_pedido = string.Format("{0:yyyyMMddHHmm}", DateTime.Now);
                    ordenCompra.Fecha_orden = DateTime.Today; 
                    ordenCompra.Fecha_entrega = dpFechaEntrega.SelectedDate.Value;
                    ordenCompra.Valor_final = 1;
                    ordenCompra.Id_estado_orden = 1;
                    if (YC.CrearOrdenCompra(ordenCompra))
                    {
                        MessageBox.Show("La orden ha sido ingresada exitosamente", "ORDEN AGREGADA");
                        this.cargarGrilla();
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

        private void cboProveedor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cboProducto.ItemsSource = null;
            try
            {
                int id_proveedor = (int)cboProveedor.SelectedValue;
                int id_familia = (int)cboFamilia.SelectedValue;
                cboProducto.ItemsSource = YC.ObtenerProductoFiltrado(id_proveedor, id_familia);
            }
            catch (Exception)
            {

                return;
            }
        }

        private void cboFamilia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cboProducto.ItemsSource = null;
            try
            {
                int id_proveedor = (int)cboProveedor.SelectedValue;
                int id_familia = (int)cboFamilia.SelectedValue;
                cboProducto.ItemsSource = YC.ObtenerProductoFiltrado(id_proveedor, id_familia);
            }
            catch (Exception)
            {

                return;
            }
        }
    }
}
