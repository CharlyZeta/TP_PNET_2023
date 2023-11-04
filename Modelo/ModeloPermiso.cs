using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Contursi_Garau_Vegetti_Mangoldt_Maidana
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
            return $"Código: {Codigo}, Nombre: {Nombre}, Descripción: {Descripcion}";
        }
    }
}
