using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using System.Windows;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Calidad
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Eliminar : Window
    {
        private Producto _productoBorrar;
        public Eliminar()
        {
            this.InitializeComponent();

            var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
            var windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(hWnd);
            var appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);
            appWindow.Resize(new Windows.Graphics.SizeInt32 { Width = 800, Height = 850 });
        }
        public void CargarDatos(Producto producto)
        {
            _productoBorrar = producto;
            lblID.Text = producto.ID;
            lblNombre.Text = producto.Nombre;
            lblCategoria.Text = producto.Categoria;
            lblMarca.Text = producto.Marca;
            lblPrecio.Text = "$" + producto.Precio;
            lblStock.Text = producto.Stock;

        }
        private void Confirmar_Click(object sender, RoutedEventArgs e)
        {
        }
        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
