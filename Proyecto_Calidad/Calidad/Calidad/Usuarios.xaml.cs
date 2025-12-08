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
using System.Collections.ObjectModel;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Calidad
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Usuarios : Window
    {
        public  ObservableCollection<Users> usersFil = new ObservableCollection<Users>();
        public Usuarios()
        {

            this.InitializeComponent();
            if (MainWindow.users.Count == 0)
            {
                MainWindow.users.Add(new Users { noEmpleado = "1001", nombre = "Ana", apellidoP = "García", apellidoM = "López", contraseña = "admin123", rol = "Administrador" });
                MainWindow.users.Add(new Users { noEmpleado = "1002", nombre = "Luis", apellidoP = "Martínez", apellidoM = "Sánchez", contraseña = "user456", rol = "Usuario" });
                MainWindow.users.Add(new Users { noEmpleado = "1003", nombre = "María", apellidoP = "Hernández", apellidoM = "Gómez", contraseña = "pass789", rol = "Usuario" });
            }

            ActualizarLista();

        }
        private void ActualizarLista()
        {
            usersFil.Clear();
            foreach (var u in MainWindow.users)
            {
                usersFil.Add(u);
            }
            ListaUsuarios.ItemsSource = usersFil;
        }
        private void UsuariosBtn_Click(object sender, RoutedEventArgs e)
        {
            Usuarios ventana = new Usuarios();
            ventana.Activate();
            this.Close();
        }
        private void ProductosBtn_Click(object sender, RoutedEventArgs e)
        {
            Dashboard ventana = new Dashboard();
            ventana.Activate();
            this.Close();
        }
        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            splitView.IsPaneOpen = !splitView.IsPaneOpen;
        }
        
        private void txtBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filtro = txtBuscar.Text.ToLower();
            var resultados = MainWindow.users.Where(u =>
                u.nombre.ToLower().Contains(filtro) ||
                u.apellidoP.ToLower().Contains(filtro) ||
                u.noEmpleado.ToLower().Contains(filtro)
            ).ToList();

            usersFil.Clear();
            foreach (var u in resultados) usersFil.Add(u);
        }
        private void AgregarBtn_Click(object sender, RoutedEventArgs e)
        {
            AgregarUser ventana = new AgregarUser();
            ventana.Closed += (s, args) => ActualizarLista();
            ventana.Activate();
            this.Close();
        }
        private void EditarBtn_Click(object sender, RoutedEventArgs e)
        {
            Button boton = sender as Button;
            Users userSelec = boton.Tag as Users;

            if (userSelec != null)
            {
                EditarUser ventana = new EditarUser();
                ventana.CargarDatos(userSelec);

                ventana.Closed += (s, args) =>
                {
                    ListaUsuarios.ItemsSource = null;
                    ListaUsuarios.ItemsSource = usersFil;
                };
                ventana.Activate();
            }
        }
        private void EliminarBtn_Click(object sender, RoutedEventArgs e)
        {
            Button boton = sender as Button;
            Users userSelec = boton.Tag as Users;

            if (userSelec != null)
            {
                EliminarUser ventana = new EliminarUser();
                ventana.CargarDatos(userSelec);

                ventana.Closed += (s, args) =>
                {
                    ListaUsuarios.ItemsSource = null;
                    ListaUsuarios.ItemsSource = usersFil;
                };
                ventana.Activate();
            }
        }
    }
}
