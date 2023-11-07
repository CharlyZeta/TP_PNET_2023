using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TP_Contursi_Garau_Vegetti_Mangoldt_Maidana;
using TP_Contursi_Garau_Vegetti_Mangoldt_Maidana.Vista;
using TP_PNET.Controlador;

namespace TP_PNET.Controlador
{
    class ControladorPermiso
    {
        public bool ListarPermisos(List<ModeloPermiso>listaPermisos)
        {
            Console.WriteLine("=== Lista de Permisos ===");

            foreach (ModeloPermiso permiso in listaPermisos)
            {
                Console.WriteLine(permiso.ToString());
            }
            Console.ReadKey();
            return true;

        }
        public List<ModeloPermiso> AltaPermiso(List<ModeloPermiso> listaPermisos)
        {
            Console.WriteLine("=== Alta de Permiso ===");

            int codigo=0;

            //Console.Write("Ingrese el código del permiso: ");
            //int codigo = Convert.ToInt32(Console.ReadLine());
            try
            {
                // si la lista está vací le asigna al primer código el 1, si ya tiene valores incrementa el valor máximo.
                _ = listaPermisos.Any() ? codigo = listaPermisos.Max(p => p.Codigo) + 1 : codigo = 1;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Código {0} agregado exitosamente.", codigo);
                Console.ResetColor();
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ocurrió un error al agregar el código del permiso: " + ex.Message);
                Console.ResetColor();
            }

            Console.Write("Ingrese el nombre del permiso: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese la descripción del permiso: ");
            string descripcion = Console.ReadLine();

            
            ModeloPermiso permiso = new ModeloPermiso(codigo, nombre, descripcion);
            try
            {
                listaPermisos.Add(permiso);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Permiso agregado exitosamente! Presione una tecla para continuar.");
                Console.ResetColor();
                Console.ReadKey();
            }
            catch (Exception ex)
            {   
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("Ocurrió un error al agregar el permiso: " + ex.Message);
                Console.WriteLine("Presione una tecla para continuar.");
                Console.ResetColor();
                Console.ReadKey();
            }

            return listaPermisos;
        }

        public List<ModeloPermiso> ModificarPermiso(List<ModeloPermiso> listaPermisos)
        {
            bool ok;
            int codigoModificar;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=== Modificar Permiso ===");
            Console.ResetColor();

            ListarPermisos(listaPermisos);
            

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

                if (nuevoNombre!="") permisoModificar.Nombre = nuevoNombre;
                else Console.WriteLine("No se han modificado nombre del permiso!");

                Console.Write("Ingrese la nueva descripción del permiso: ");
                string nuevaDescripcion = Console.ReadLine();

                if(nuevaDescripcion!="") permisoModificar.Descripcion = nuevaDescripcion;
                else Console.WriteLine("No se han modificado descripción del permiso!");

                Console.WriteLine();
                if (nuevoNombre == "" && nuevaDescripcion == "") Console.WriteLine("No se han modificado los datos del permiso!");
                else Console.WriteLine("Permiso modificado exitosamente.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red; 
                Console.WriteLine("No se encontró un permiso con el código ingresado.");
                Console.ResetColor();
            }
            Console.ReadKey();
            return listaPermisos;
        }
        public List<ModeloPermiso> EliminarPermiso(List<ModeloPermiso> listaPermisos, List<ModeloUsuario> listaUsuarios, List<ModeloGrupo> listaGrupos)
        {
            Console.WriteLine("=== Eliminar Permiso ===");

            ListarPermisos(listaPermisos);
            
            int codigoEliminar;
            bool ok=false;
            do
            {
                Console.WriteLine();
                Console.Write("Ingrese el código del permiso a eliminar: ");
                ok = int.TryParse(Console.ReadLine(), out codigoEliminar);
            } while (!ok);
            
            //int codigoEliminar = Convert.ToInt32(Console.ReadLine());       // VALIDAR Y CORREGIR

            ModeloPermiso permisoEliminar = listaPermisos.Find(p => p.Codigo == codigoEliminar);

            if (permisoEliminar != null)
            {
                // Verificar si el permiso está siendo utilizado por algún usuario o grupo
                bool permisoEnUso = false;

                permisoEnUso = listaUsuarios.Any(usuario => usuario.ListaPermisos.Contains(permisoEliminar));

                //foreach (ModeloUsuario usuario in listaUsuarios)
                //{
                //    if (usuario.ListaPermisos.Contains(permisoEliminar))
                //    {
                //        permisoEnUso = true;
                //        break;
                //    }
                //}

                permisoEnUso = listaGrupos.Any(grupo => grupo.ListaPermisos.Contains(permisoEliminar));

                //foreach (ModeloGrupo grupo in listaGrupos)
                //{
                //    if (grupo.ListaPermisos.Contains(permisoEliminar))
                //    {
                //        permisoEnUso = true;
                //        break;
                //    }
                //}

                if (!permisoEnUso)
                {
                    listaPermisos.Remove(permisoEliminar);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Permiso eliminado exitosamente.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No se puede eliminar el permiso porque está siendo utilizado por un usuario o grupo.");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No se encontró un permiso con el código ingresado.");
                Console.ResetColor();
            }
            Console.ReadKey();
            return listaPermisos;
        }

    }
}
