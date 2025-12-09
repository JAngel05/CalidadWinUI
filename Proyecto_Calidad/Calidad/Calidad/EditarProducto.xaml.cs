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
    public sealed partial class EditarProducto : Window
    {
        private Producto _productoOriginal;
        public EditarProducto()
        {
            InitializeComponent();
        }
        public void CargarDatos(Producto producto)
        {
            _productoOriginal = producto;
            txtID.Text = producto.ID;
            txtNombre.Text = producto.Nombre;
            txtCategoria.Text = producto.Categoria;
            txtMarca.Text = producto.Marca;
            txtPrecio.Text = producto.Precio;
            txtStock.Text = producto.Stock;


  
            foreach (ComboBoxItem item in cmbEstado.Items)
            {
                if (item.Content.ToString() == producto.Estado)
                {
                    cmbEstado.SelectedItem = item;
                    break;
                }
            }
        }
        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            string nombre = txtNombre.Text;
            string categoria = txtCategoria.Text;
            string marca = txtMarca.Text;
            string precioText = txtPrecio.Text;
            string stock = txtStock.Text;
            if (string.IsNullOrEmpty(nombre))
            {
                ErrorMessageNombre.Text = "Por favor, complete este campo.";
            }
            if (string.IsNullOrEmpty(categoria))
            {
                ErrorMessageCategoria.Text = "Por favor, complete este campo.";
            }
            if (string.IsNullOrEmpty(marca))
            {
                ErrorMessageMarca.Text = "Por favor, complete este campo.";
            }
            if (string.IsNullOrEmpty(precioText))
            {
                ErrorMessagePrecio.Text = "Por favor, complete este campo.";
            }
            if (string.IsNullOrEmpty(stock))
            {
                ErrorMessageStock.Text = "Por favor, complete este campo.";
            }
        }
        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
