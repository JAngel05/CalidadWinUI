using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calidad
{
    public class Users
    {
        public string noEmpleado { get; set; }
        public string nombre { get; set; }
        public string apellidoP { get; set; }
        public string apellidoM { get; set; }
        public string contraseña { get; set; }
        public string rol { get; set; }
        public override string ToString()
        {
            return $"{noEmpleado} - {rol}";
        }
    }
}
