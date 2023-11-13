using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TP_PNET;
using TP_PNET.Vista;

namespace TP_PNET
{
    class ControladorPermiso
    {
        static MensajesDeSisema msj = new MensajesDeSisema();

        /// <summary>
        /// Lista de permisos del sistema informando Código, Nombre y descripción del permisos.
        /// Utiliza un valor booleano que pide o no que se pulse una tecla para continuar
        /// </summary>
        /// <param name="listaPermisos">Lista de grupos</param>
        /// <param name="pideKey">si es TRUE pide confirmación al terminar de mostrar la lista en pantalla</param>
        /// <returns></returns>
        public bool ListarPermisos(List<ModeloPermiso>listaPermisos, bool pideKey)
        {
            Console.WriteLine("\n");

            msj.Menu("=== Lista de Permisos ===");

            Console.WriteLine();

            foreach (ModeloPermiso permiso in listaPermisos)
            {
                Console.WriteLine(permiso.ToString());
            }
            if (pideKey)
            {
                msj.Info("Presione una tecla para continuar...");
                Console.ReadKey();
            }
            return true;

        }

        /// <summary>
        /// Alta de permisos del sistema. Genera ID automáticamente
        /// </summary>
        /// <param name="listaPermisos">Lista de Permisos</param>
        /// <returns>TRUE</returns>
        public bool AltaPermiso(List<ModeloPermiso> listaPermisos)
        {
            string nombre,descripcion,error;
            int codigo=0;
            Console.WriteLine("\n");

            msj.Menu("=== Alta de Permiso ===");

            Console.WriteLine();

            try
            {
                // si la lista está vacía le asigna al primer código el 1, si ya tiene valores incrementa el valor máximo.
                _ = listaPermisos.Any() ? codigo = listaPermisos.Max(p => p.Codigo) + 1 : codigo = 1;

                msj.Exito("Código agregado exitosamente.");

            }
            catch (Exception ex)
            {
                msj.Error("Ocurrió un error al agregar el código del permiso: ");
                error = ex.ToString();
                msj.Error(error);
            }

            do
            {
                Console.Write("Ingrese el nombre del permiso: ");
                nombre = Console.ReadLine();
            } while (string.IsNullOrEmpty(nombre));
            
            ;
            do
            {
                Console.Write("Ingrese la descripción del permiso: ");
                descripcion = Console.ReadLine();
            } while (string.IsNullOrEmpty(descripcion));


            ModeloPermiso permiso = new ModeloPermiso(codigo, nombre, descripcion);

            try
            {
                listaPermisos.Add(permiso);
                msj.Exito("Permiso agregado exitosamente! Presione una tecla para continuar.");
            }
            catch (Exception ex)
            {
                msj.Error("Ocurrió un error al agregar el permiso: ");
                error = ex.Message;
                msj.Error(error + "Presione una tecla para continuar.");
            }
            return true;
        }

        /// <summary>
        /// Modifica los datos del permiso del sistema. Permite cambiar todos los datos menos el ID. 
        /// </summary>
        /// <param name="listaPermisos">Lista de Permisos</param>
        /// <returns>Lista de permisos</returns>
        public List<ModeloPermiso> ModificarPermiso(List<ModeloPermiso> listaPermisos)
        {
            bool ok;
            int codigoModificar;

            Console.WriteLine("\n");

            msj.Menu("=== Modificar Permiso ===");
            
            ListarPermisos(listaPermisos, false);

            do
            {
                Console.Write("Ingrese el código del permiso a modificar: ");
                ok = int.TryParse(Console.ReadLine(), out codigoModificar);

            } while (!ok);
            
            // busca el código dentro de la lista
            ModeloPermiso permisoModificar = listaPermisos.Find(p => p.Codigo == codigoModificar);
            
            // si encontró el código setea el nuevo nombre y/o la descripción
            if (permisoModificar != null)
            {
                Console.Write("Ingrese el nuevo nombre del permiso: ");
                string nuevoNombre = Console.ReadLine();

                if (nuevoNombre != "") permisoModificar.Nombre = nuevoNombre;
                else msj.Error("No se han modificado nombre del permiso!");

                Console.Write("Ingrese la nueva descripción del permiso: ");
                string nuevaDescripcion = Console.ReadLine();

                if (nuevaDescripcion != "") permisoModificar.Descripcion = nuevaDescripcion;
                else msj.Error("No se han modificado descripción del permiso!");

                Console.WriteLine();

                if (nuevoNombre == "" && nuevaDescripcion == "") msj.Error("No se han modificado los datos del permiso!");
                else msj.Exito("Permiso modificado exitosamente.");

                Console.WriteLine();
            }
            else
            {
                msj.Error("No se encontró un permiso con el código ingresado.");
            }

            return listaPermisos;
        }

        /// <summary>
        /// Elimina el usuario del sistema
        /// </summary>
        /// <param name="listaPermisos">Lista de Grupos</param>
        /// <param name="listaUsuarios">Lista de Usuarios</param>
        /// <param name="listaGrupos">Lista de Usuarios</param>
        /// <returns>True</returns>
        public List<ModeloPermiso> EliminarPermiso(List<ModeloPermiso> listaPermisos, List<ModeloUsuario> listaUsuarios, List<ModeloGrupo> listaGrupos)
        {
            int codigoEliminar;
            bool ok = false;
            Console.WriteLine("\n");

            msj.Menu("=== Eliminar Permiso ===");

            ListarPermisos(listaPermisos, false);
            
            do
            {
                Console.WriteLine();
                Console.Write("Ingrese el código del permiso a eliminar: ");
                ok = int.TryParse(Console.ReadLine(), out codigoEliminar);
            } while (!ok);
            
            ModeloPermiso permisoEliminar = listaPermisos.Find(p => p.Codigo == codigoEliminar);

            if (permisoEliminar != null)
            {
                // Verificar si el permiso está siendo utilizado por algún usuario o grupo
                bool permisoEnUso = false;

                permisoEnUso = listaUsuarios.Any(usuario => usuario.ListaPermisos.Contains(permisoEliminar));

                permisoEnUso = listaGrupos.Any(grupo => grupo.ListaPermisos.Contains(permisoEliminar));

                if (!permisoEnUso)
                {
                    listaPermisos.Remove(permisoEliminar);
                    
                    msj.Exito("Permiso eliminado exitosamente.");
                }
                else
                {
                    msj.Error("No se puede eliminar el permiso porque está siendo utilizado por un usuario o grupo.");
                }
            }
            else
            {
                msj.Error("No se encontró un permiso con el código ingresado.");
            }
            Console.ReadKey();
            return listaPermisos;
        }

    }
}
