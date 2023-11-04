using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Contursi_Garau_Vegetti_Mangoldt_Maidana
{
    internal class ModeloUsuario
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public ModeloGrupo Grupo { get; set; }
        public List<ModeloPermiso> ListaPermisos { get; set; }

        public ModeloUsuario(int codigo, string nombre, string password, string email, ModeloGrupo grupo, List<ModeloPermiso> listaPermisos)
        {
            Codigo = codigo;
            Nombre = nombre;
            Password = password;
            Email = email;
            Grupo = grupo;
            ListaPermisos = listaPermisos;
        }

         public override string ToString()
        {
            return $"Código: {Codigo}, Nombre: {Nombre}, Password: {Password}, Email: {Email}, Grupo: {Grupo}, Permisos: {string.Join(", ", ListaPermisos)}";
        }
    }
}
