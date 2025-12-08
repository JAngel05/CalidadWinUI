using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Windows.System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Calidad
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EditarUser : Window
    {
        private Users _us;
        public EditarUser()
        {
            this.InitializeComponent();
        }
        public void CargarDatos(Users user)
        {
            _us = user;
            txtnoEmpleado.Text = user.noEmpleado;
            txtNombre.Text = user.nombre;
            txtApellidoP.Text = user.apellidoP;
            txtApellidoM.Text = user.apellidoM;
            passworBoxWithRevealmode.Password = user.contraseña;
            if (!string.IsNullOrEmpty(user.rol))
            {
                string rolA_Buscar = user.rol.Trim();

                foreach (object item in RbRol.Items)
                {
                    string opcionDelBoton = item.ToString();

                    if (opcionDelBoton.Equals(rolA_Buscar, StringComparison.OrdinalIgnoreCase))
                    {
                        RbRol.SelectedItem = item;
                        break;
                    }
                }
            }
        }
        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
        }
        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
