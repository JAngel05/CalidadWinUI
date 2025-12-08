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

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Calidad
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AgregarUser : Window
    {
        public AgregarUser()
        {
            this.InitializeComponent();
        }
        public void AgregarUsuario_Click(object sender, RoutedEventArgs e)
        {
            string noEmpleado = txtnoEmpleado.Text;
            string nombre = txtNombre.Text;
            string apellidoP = txtApellidoP.Text;
            string apellidoM = txtApellidoM.Text;
            string contraseña = txtContraseña.Text;
            string rol = ((RadioButton)RbRol.SelectedItem).Content.ToString();
            Users nuevoUsuario = new Users
            {
                noEmpleado = noEmpleado,
                nombre = nombre,
                apellidoP = apellidoP,
                apellidoM = apellidoM,
                contraseña = contraseña,
                rol = rol
            };
            MainWindow.users.Add(nuevoUsuario);
            this.Close();
        }
        public void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Usuarios ventana = new Usuarios();
            ventana.Activate();
            this.Close();
        }
        public void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            AgregarUser ventana = new AgregarUser();
            ventana.Activate();
            this.Close();
        }
    }
}
