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
    public sealed partial class EliminarUser : Window
    {
        private Users _DeleteUs;
        public EliminarUser()
        {
            this.InitializeComponent();

            var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
            var windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(hWnd);
            var appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);
            appWindow.Resize(new Windows.Graphics.SizeInt32 { Width = 600, Height = 650 });
        }

        public void CargarDatos(Users user)
        {
            _DeleteUs = user;
            lblNoEmpleado.Text = user.noEmpleado.ToString();
            lblNombre.Text = user.nombre.ToString();
            lblApellidoP.Text = user.apellidoP.ToString();
            lblApellidoM.Text = user.apellidoM.ToString();
        }
        private void Confirmar_Click(object sender, RoutedEventArgs e)
        {
        }
        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
