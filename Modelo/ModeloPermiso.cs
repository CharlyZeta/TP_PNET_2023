using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_PNET
{
    internal class ModeloPermiso
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public ModeloPermiso(int codigo, string nombre, string descripcion)
        {
            Codigo = codigo;
            Nombre = nombre;
            Descripcion = descripcion;
        }

        public override string ToString()
        {
            return $"----Permiso Código: {Codigo}, Nombre: {Nombre}, Descripción: {Descripcion}\n";
        }
    }
}
