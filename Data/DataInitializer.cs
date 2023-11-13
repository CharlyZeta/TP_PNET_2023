using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_PNET;

namespace TP_PNET
{
    class DataInitializer
    {
        public void DataInit(List<ModeloPermiso> listaPermisos, List<ModeloGrupo> listaGrupos, List<ModeloUsuario> listaUsuarios)
        {

            //List<ModeloPermiso> listaPermisos = new List<ModeloPermiso>();
            //List<ModeloGrupo> listaGrupos = new List<ModeloGrupo>();
            //List<ModeloUsuario> listaUsuarios = new List<ModeloUsuario>();

            bool salir = false;

            ModeloPermiso permiso1 = new ModeloPermiso(1, "Permiso 1", "Permiso de acceso al sistema");
            ModeloPermiso permiso2 = new ModeloPermiso(2, "Permiso 2", "Permiso de carga de datos");
            ModeloPermiso permiso3 = new ModeloPermiso(3, "Permiso 2", "Permiso de edición de datos");
            listaPermisos.Add(permiso1);
            listaPermisos.Add(permiso2);
            listaPermisos.Add(permiso3);

            ModeloGrupo grupo1 = new ModeloGrupo(1, "Grupo 1", new List<ModeloPermiso> { permiso1 });
            ModeloGrupo grupo2 = new ModeloGrupo(2, "Grupo 2", new List<ModeloPermiso> { permiso1, permiso2 });
            listaGrupos.Add(grupo1);
            listaGrupos.Add(grupo2);

            ModeloUsuario usuario1 = new ModeloUsuario(1, "Gerardo", "pass123456", "gmmaidana@frsf.utn.edu.ar", grupo1, listaPermisos);
            ModeloUsuario usuario2 = new ModeloUsuario(2, "Marcelo", "pass234567", "mperez@frsf.utn.edu.ar", grupo2, listaPermisos);
            listaUsuarios.Add(usuario1);
            listaUsuarios.Add(usuario2);
        }
    }
}
