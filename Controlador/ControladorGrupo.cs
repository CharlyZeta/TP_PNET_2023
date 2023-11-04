using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Contursi_Garau_Vegetti_Mangoldt_Maidana.Vista;
using TP_Contursi_Garau_Vegetti_Mangoldt_Maidana.Controlador;


namespace TP_Contursi_Garau_Vegetti_Mangoldt_Maidana.Controlador
{
    internal class ControladorGrupo
    {
        static void ListarGrupos(List<ModeloGrupo> listaGrupos)
        {
            Console.WriteLine("=== Lista de Grupos ===");

            foreach (ModeloGrupo grupo in listaGrupos)
            {
                Console.WriteLine(grupo.ToString());
            }
        }

        static void AltaGrupo(List<ModeloGrupo> listaGrupos, List<ModeloPermiso> listaPermisos)
        {
            Console.WriteLine("=== Alta de Grupo ===");

            Console.Write("Ingrese el código del grupo: ");
            int codigo = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ingrese el nombre del grupo: ");
            string nombre = Console.ReadLine();

            // Obtener la lista de permisos para el grupo
            List<ModeloPermiso> listaPermisosGrupo = new List<ModeloPermiso>();

            bool agregarMasPermisos = true;

            while (agregarMasPermisos)
            {
                Console.Write("Ingrese el código del permiso a agregar al grupo (0 para finalizar): ");
                int codigoPermiso = Convert.ToInt32(Console.ReadLine());

                if (codigoPermiso == 0)
                {
                    agregarMasPermisos = false;
                }
                else
                {
                    ModeloPermiso permisoEncontrado = listaPermisos.Find(p => p.Codigo == codigoPermiso);

                    if (permisoEncontrado != null)
                    {
                        listaPermisosGrupo.Add(permisoEncontrado);
                    }
                    else
                    {
                        Console.WriteLine("No se encontró un permiso con el código ingresado.");
                    }
                }
            }

            ModeloGrupo grupo = new ModeloGrupo(codigo, nombre, listaPermisosGrupo);
            listaGrupos.Add(grupo);

            Console.WriteLine("Grupo agregado exitosamente.");
        }

        static void ModificarGrupo(List<ModeloGrupo> listaGrupos, List<ModeloPermiso> listaPermisos)
        {
            Console.WriteLine("=== Modificar Grupo ===");

            Console.Write("Ingrese el código del grupo a modificar: ");
            int codigoModificar = Convert.ToInt32(Console.ReadLine());

            ModeloGrupo grupoModificar = listaGrupos.Find(g => g.Codigo == codigoModificar);

            if (grupoModificar != null)
            {
                Console.Write("Ingrese el nuevo nombre del grupo: ");
                string nuevoNombre = Console.ReadLine();

                grupoModificar.Nombre = nuevoNombre;

                // Obtener la lista de permisos actualizada para el grupo
                List<ModeloPermiso> listaPermisosGrupoModificado = new List<ModeloPermiso>();

                bool agregarMasPermisosModificado = true;

                while (agregarMasPermisosModificado)
                {
                    Console.Write("Ingrese el código del permiso a agregar al grupo (0 para finalizar): ");
                    int codigoPermisoModificado = Convert.ToInt32(Console.ReadLine());

                    if (codigoPermisoModificado == 0)
                    {
                        agregarMasPermisosModificado = false;
                    }
                    else
                    {
                        ModeloPermiso permisoEncontradoModificado = listaPermisos.Find(p => p.Codigo == codigoPermisoModificado);

                        if (permisoEncontradoModificado != null)
                        {
                            listaPermisosGrupoModificado.Add(permisoEncontradoModificado);
                        }
                        else
                        {
                            Console.WriteLine("No se encontró un permiso con el código ingresado.");
                        }
                    }
                }

                grupoModificar.ListaPermisos = listaPermisosGrupoModificado;

                Console.WriteLine("Grupo modificado exitosamente.");
            }
            else
            {
                Console.WriteLine("No se encontró un grupo con el código ingresado.");
            }
        }

        static void EliminarGrupo(List<ModeloGrupo> listaGrupos, List<ModeloUsuario> listaUsuarios)
        {
            Console.WriteLine("=== Eliminar Grupo ===");

            Console.Write("Ingrese el código del grupo a eliminar: ");
            int codigoEliminar = Convert.ToInt32(Console.ReadLine());

            ModeloGrupo grupoEliminar = listaGrupos.Find(g => g.Codigo == codigoEliminar);

            if (grupoEliminar != null)
            {
                // Verificar si el grupo está siendo utilizado por algún usuario
                bool grupoEnUso = false;

                foreach (ModeloUsuario usuario in listaUsuarios)
                {
                    if (usuario.Grupo == grupoEliminar)
                    {
                        grupoEnUso = true;
                        break;
                    }
                }

                if (!grupoEnUso)
                {
                    listaGrupos.Remove(grupoEliminar);
                    Console.WriteLine("Grupo eliminado exitosamente.");
                }
                else
                {
                    Console.WriteLine("No se puede eliminar el grupo porque está siendo utilizado por un usuario.");
                }
            }
            else
            {
                Console.WriteLine("No se encontró un grupo con el código ingresado.");
            }
        }
    }
}
