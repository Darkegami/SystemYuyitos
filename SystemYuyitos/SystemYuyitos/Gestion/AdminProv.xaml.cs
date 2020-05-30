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
    /// Lógica de interacción para Proveedor.xaml
    /// </summary>
    public partial class AdminProv : MetroWindow
    {
        private YuyitosCollection YC = new YuyitosCollection();
        public static AdminProv ventanaProveedor;

        public AdminProv()
        {
            InitializeComponent();
            this.cargarGrilla();
            cboRegion.ItemsSource = null;
            cboRegion.ItemsSource = YC.ListaRegion();
        }

        public static AdminProv getInstance()
        {
            if (ventanaProveedor == null)
            {
                ventanaProveedor = new AdminProv();
            }

            return ventanaProveedor;
        }

        private void cargarGrilla()
        {
            dgProveedoor.ItemsSource = null;
            dgProveedoor.ItemsSource = YC.ListaProveedor();


        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtIdProveBuscar.Text == " ")
                {
                    MessageBox.Show("Ingrese la informacion correctamente", "ERROR");
                    return;
                }
                else
                {

                    Proveedor prov = new Proveedor();

                    prov.IDProv = 1;
                    prov.NombreProv = txtNombreProv.Text;
                    prov.Telefono = 1;
                    prov.Comuna.Id_comuna = cboComuna.SelectedIndex;
                    prov.Direccion = txtDireccionProv.Text;

                    cargarGrilla();
                    if (YC.IngresarProveedor(prov))
                    {
                        MessageBox.Show("El Proveedor ha sido ingresado exitosamente", "PROVEEDOR AGREGADO");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error, contacte a un tecnico a la brevedad", "ERROR");
                    }
                    
                }

             }catch (Exception error){
                MessageBox.Show("Ha ocurrido un error, contacte a un tecnico a la brevedad", "ERROR");
                return;
            }
          
         }


        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtIdProveBuscar.Text.Trim()=="")
                {
                    MessageBox.Show("No puede dejar campos sin rellenar", "ERROR");
                    return;
                }
                else
                {
                    Proveedor proveedor = YC.BuscarProveedor(int.Parse(txtIdProveBuscar.Text));
                    if (proveedor==null)
                    {
                        MessageBox.Show("La id de proveedor ingresada no se encuentra en la BD","ERROR");
                        return;
                    }
                    else
                    {
                        txtDireccionProv.Text = proveedor.Direccion;
                        txtNombreProv.Text = proveedor.NombreProv;
                        txtTelefonoProv.Text = proveedor.Telefono.ToString();
                        cboRegion.SelectedValue = proveedor.Region.Id_region;
                        cboComuna.ItemsSource = YC.ListaComuna(proveedor.Region.Id_region);
                        cboComuna.SelectedValue = proveedor.Comuna.Id_comuna;
                        
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }


        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
         
        }

        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            Menu.getInstance().Show();
            this.Close();
        }

        private void BtnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            
        }


        private void cboRegion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                cboComuna.ItemsSource = null;
                cboComuna.ItemsSource = YC.ListaComuna((int)cboRegion.SelectedValue);
            }
            catch (Exception)
            {

                return;
            }

        }

        private void dgProveedoor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Proveedor proveedor = (Proveedor)dgProveedoor.SelectedItem;
                txtDireccionProv.Text = proveedor.Direccion;
                txtNombreProv.Text = proveedor.NombreProv;
                txtTelefonoProv.Text = proveedor.Telefono.ToString();
                cboRegion.SelectedValue = proveedor.Region.Id_region;
                cboComuna.ItemsSource = YC.ListaComuna(proveedor.Region.Id_region);
                cboComuna.SelectedValue = proveedor.Comuna.Id_comuna;
                txtIdProveBuscar.Text = proveedor.IDProv.ToString();
            }
            catch (Exception)
            {

                return;
            }
        }
    }
    
}
