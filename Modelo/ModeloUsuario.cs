using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_PNET
{
    class ModeloUsuario
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
            return $"Usuario {Codigo}, Nombre: {Nombre}, Password: {Password}, Email: {Email}\n-- Grupo:\n {Grupo}\n-- Permisos:\n {string.Join(" ", ListaPermisos)}\n" +
                $"------------------------------------------------";
        }
    }
}
