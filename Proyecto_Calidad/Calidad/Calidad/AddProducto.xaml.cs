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

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Calidad
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddProducto : Window
    {
        public AddProducto()
        {
            InitializeComponent();
        }
        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            string nombre = txtNombre.Text;
            string categoria = txtCategoria.Text;
            string marca = txtMarca.Text;
            string precioText = txtPrecio.Text;
            string stock = txtStock.Text;
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(categoria) || string.IsNullOrEmpty(marca)
                || string.IsNullOrEmpty(precioText) || string.IsNullOrEmpty(stock))
            {
                ErrorMessageNombre.Text = "Por favor, complete este campo.";
                ErrorMessageCategoria.Text = "Por favor, complete este campo.";
                ErrorMessageMarca.Text = "Por favor, complete este campo.";
                ErrorMessagePrecio.Text = "Por favor, complete este campo.";
                ErrorMessageStock.Text = "Por favor, complete este campo.";
            }
        }
        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
