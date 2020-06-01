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
                if (txtDireccionProv.Text==""|| txtNombreProv.Text =="" ||txtTelefonoProv.Text==""||cboComuna.SelectedIndex<0||cboRegion.SelectedIndex<0)
                {
                    MessageBox.Show("No puede dejar campos sin rellenar", "ERROR");
                    return;
                }
                else
                {
                    Proveedor proveedor = new Proveedor();
                    proveedor.Id_comuna = (int)cboComuna.SelectedValue;
                    proveedor.Direccion = txtDireccionProv.Text;
                    proveedor.NombreProv = txtNombreProv.Text;
                    try
                    {
                        proveedor.Telefono = int.Parse(txtTelefonoProv.Text);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ingrese solo numeros en el campo telefono","ERROR");
                        return;
                    }
                    if (YC.IngresarProveedor(proveedor))
                    {
                        MessageBox.Show("Se ha ingresado el proveedor exitosamente","PROVEEDOR INGRESADO");
                        this.cargarGrilla();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error, contacte a un tecnico a la brevedad", "ERROR");
                        return;
                    }

                }

             }catch (Exception error){

                throw;
             }
          
         }


        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtIdProveBuscar.Text == "")
                {
                    MessageBox.Show("Ingrese la id de proveedor antes de buscar", "ERROR");
                    return;
                }
                else
                {
                    int v_id_proveedor = 0;
                    try
                    {
                        v_id_proveedor = int.Parse(txtIdProveBuscar.Text);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ingrese solo numeros en el campo de id de proveedor", "ERROR");
                        return;

                    }
                    Proveedor proveedor = YC.BuscarProveedor(v_id_proveedor);
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
            try
            {
                if (txtIdProveBuscar.Text == "")
                {
                    MessageBox.Show("Ingrese la id de proveedor antes de eliminar", "ERROR");
                    return;
                }
                else
                {
                    int v_id_proveedor = 0;
                    try
                    {
                        v_id_proveedor = int.Parse(txtIdProveBuscar.Text);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ingrese solo numeros en el campo de id de proveedor","ERROR");
                        return;
                    }
                    if (YC.EliminarProveedor(v_id_proveedor))
                    {
                        MessageBox.Show("Se ha eliminado el proveedor exitosamente","PROVEEDOR ELIMINADO");
                        this.cargarGrilla();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("El proveedor que intenta elimina no existe o tiene registros en otra tabla", "ERROR");
                        return;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtIdProveBuscar.Text == "")
                {
                    MessageBox.Show("Ingrese la id de proveedor antes de modificar", "ERROR");
                    return;
                }
                if (txtDireccionProv.Text == "" || txtNombreProv.Text == "" || txtTelefonoProv.Text == "" || cboComuna.SelectedIndex < 0 || cboRegion.SelectedIndex < 0)
                {
                    MessageBox.Show("No puede dejar campos sin rellenar", "ERROR");
                    return;
                }
                else
                {
                    Proveedor proveedor = new Proveedor();
                    try
                    {
                        proveedor.IDProv = int.Parse(txtIdProveBuscar.Text);
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Ingrese solo numeros en el campo de la id de proveedor","ERROR");
                        return;
                    }
                    proveedor.Id_comuna = (int)cboComuna.SelectedValue;
                    proveedor.Direccion = txtDireccionProv.Text;
                    proveedor.NombreProv = txtNombreProv.Text;
                    try
                    {
                        proveedor.Telefono = int.Parse(txtTelefonoProv.Text);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ingrese solo numeros en el campo telefono", "ERROR");
                        return;
                    }
                    if (YC.ModificarProveedor(proveedor))
                    {
                        MessageBox.Show("Se ha modificado el proveedor exitosamente", "PROVEEDOR MODIFICADO");
                        this.cargarGrilla();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error, contacte a un tecnico a la brevedad", "ERROR");
                        return;
                    }

                }

            }
            catch (Exception error)
            {
                throw;
            }
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            Menu.getInstance().Show();
            ventanaProveedor = null;
            this.Close();
        }

        private void BtnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtDireccionProv.Text = "";
            txtIdProveBuscar.Text = "";
            txtNombreProv.Text = "";
            txtTelefonoProv.Text = "";
            cboComuna.SelectedItem = null;
            cboRegion.SelectedItem = null;
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

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Menu.getInstance().Show();
            ventanaProveedor = null;
        }
    }
    
}
