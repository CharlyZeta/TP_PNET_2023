using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Contursi_Garau_Vegetti_Mangoldt_Maidana
{
    internal class ModeloGrupo
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public List<ModeloPermiso> ListaPermisos { get; set; }

        // Constructor
        public ModeloGrupo(int codigo, string nombre, List<ModeloPermiso> listaPermisos)
        {
            Codigo = codigo;
            Nombre = nombre;
            ListaPermisos = listaPermisos;
        }

        // Sobrescribir el método ToString
        public override string ToString()
        {
            return $"Código: {Codigo}, Nombre: {Nombre}, Permisos: {string.Join(", ", ListaPermisos)}";
        }
    }
}
