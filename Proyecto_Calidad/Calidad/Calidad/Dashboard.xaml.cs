using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public sealed partial class Dashboard : Window
    {
        public ObservableCollection<Producto> ProductosFiltrados = new ObservableCollection<Producto>();

        public Dashboard()
        {
            this.InitializeComponent();
            if (MainWindow.Productos.Count == 0)
            {
                MainWindow.Productos.Add(new Producto { Nombre = "Laptop Gamer", Categoria = "Cómputo", Marca = "Dell", Precio = "15000", Stock = "5", Estado = "Disponible" });
                MainWindow.Productos.Add(new Producto { Nombre = "Mouse RGB", Categoria = "Accesorios", Marca = "Razer", Precio = "500", Stock = "20", Estado = "Disponible" });
                MainWindow.Productos.Add(new Producto { Nombre = "Monitor 24'' 75Hz", Categoria = "Monitores", Marca = "Samsung", Precio = "3200", Stock = "8", Estado = "Disponible" });
                MainWindow.Productos.Add(new Producto { Nombre = "Teclado Mecánico", Categoria = "Accesorios", Marca = "HyperX", Precio = "1450", Stock = "15", Estado = "Disponible" });
                MainWindow.Productos.Add(new Producto { Nombre = "Disco SSD 1TB", Categoria = "Almacenamiento", Marca = "Kingston", Precio = "950", Stock = "30", Estado = "Disponible" });
                MainWindow.Productos.Add(new Producto { Nombre = "Impresora WiFi", Categoria = "Impresión", Marca = "HP", Precio = "4200", Stock = "0", Estado = "Agotado" });
            }

            ActualizarLista();
        }

        private void ActualizarLista()
        {
            ProductosFiltrados.Clear();
            foreach (var p in MainWindow.Productos)
            {
                ProductosFiltrados.Add(p);
            }
            listaProductos.ItemsSource = ProductosFiltrados;
        }

        private void txtBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filtro = txtBuscar.Text.ToLower();
            var resultados = MainWindow.Productos.Where(p =>
                p.Nombre.ToLower().Contains(filtro) ||
                p.Marca.ToLower().Contains(filtro)
            );

            ProductosFiltrados.Clear();
            foreach (var p in resultados) ProductosFiltrados.Add(p);
        }

        private void AgregarBtn_Click(object sender, RoutedEventArgs e)
        {
            AddProducto ventana = new AddProducto();
            ventana.Closed += (s, args) => ActualizarLista();
            ventana.Activate();
        }

        private void EditarBtn_Click(object sender, RoutedEventArgs e)
        {
            Button boton = sender as Button;
            Producto productoSeleccionado = boton.Tag as Producto;

            if (productoSeleccionado != null)
            {
                EditarProducto ventana = new EditarProducto();
                ventana.CargarDatos(productoSeleccionado);

                ventana.Closed += (s, args) =>
                {
                    listaProductos.ItemsSource = null;
                    listaProductos.ItemsSource = ProductosFiltrados;
                };
                ventana.Activate();
            }
        }

        private void EliminarBtn_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button boton && boton.Tag is Producto productoSeleccionado)
            {
                Eliminar ventana = new Eliminar();
                ventana.CargarDatos(productoSeleccionado);
                ventana.Closed += (s, args) =>
                {

                    listaProductos.ItemsSource = null;
                    listaProductos.ItemsSource = ProductosFiltrados;
                };
                ventana.Activate();
            }
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
    }
}

