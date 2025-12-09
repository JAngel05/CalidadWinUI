using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calidad
{
    public class Producto
    {
        public string ID { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public string Marca { get; set; }
        public string Precio { get; set; }
        public string Stock { get; set; }
        public string Estado { get; set; }


        public override string ToString()
        {
            return $"{Nombre} - {Categoria} (${Precio})";
        }
    }
}
