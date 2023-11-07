using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Contursi_Garau_Vegetti_Mangoldt_Maidana.Vista;
using TP_Contursi_Garau_Vegetti_Mangoldt_Maidana.Controlador;
using TP_Contursi_Garau_Vegetti_Mangoldt_Maidana;

namespace TP_PNET.Controlador
{
    class ControladorGrupo
    {
        public bool ListarGrupos(List<ModeloGrupo> listaGrupos)
        {
            Console.WriteLine("=== Lista de Grupos ===");

            foreach (ModeloGrupo grupo in listaGrupos)
            {
                Console.WriteLine(grupo.ToString());
            }
            Console.ReadKey();
            return true;
        }

        public bool AltaGrupo(List<ModeloGrupo> listaGrupos, List<ModeloPermiso> listaPermisos)
        {
            int codigo = 0;
            Console.WriteLine("=== Alta de Grupo ===");

            //Console.Write("Ingrese el código del grupo: ");            
            //int codigo = Convert.ToInt32(Console.ReadLine());

            try
            {
                // si la lista está vacía le asigna al primer código el 1, si ya tiene valores incrementa el valor máximo.
                _ = listaGrupos.Any() ? codigo = listaGrupos.Max(p => p.Codigo) + 1 : codigo = 1;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Código {0} agregado exitosamente.", codigo);
                Console.ResetColor();
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ocurrió un error al agregar el código del grupo: " + ex.Message);
                Console.ResetColor();
            }


            Console.Write("Ingrese el nombre del grupo: ");
            string nombre = Console.ReadLine();

            // Obtener la lista de permisos para el grupo
            List<ModeloPermiso> listaPermisosGrupo = new List<ModeloPermiso>();

            bool agregarMasPermisos = true, ok;
            int codigoPermiso = 0;

            while (agregarMasPermisos)
            {
                do
                {
                    Console.Write("Ingrese el código del permiso a agregar al grupo (0 para finalizar): ");
                    ok = int.TryParse(Console.ReadLine(), out codigoPermiso);
                    
                } while (!ok);
                

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
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("No se encontró un permiso con el código ingresado.");
                        Console.ResetColor();
                    }
                }
            }

            ModeloGrupo grupo = new ModeloGrupo(codigo, nombre, listaPermisosGrupo);
            listaGrupos.Add(grupo);
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Grupo agregado exitosamente.");
            Console.ResetColor();

            return true;
        }

        public bool ModificarGrupo(List<ModeloGrupo> listaGrupos, List<ModeloPermiso> listaPermisos)
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

            return true;
        }

        public bool EliminarGrupo(List<ModeloGrupo> listaGrupos, List<ModeloUsuario> listaUsuarios)
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

            return true;
        }
    }
}
