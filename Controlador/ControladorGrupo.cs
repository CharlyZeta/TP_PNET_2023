using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Contursi_Garau_Vegetti_Mangoldt_Maidana.Vista;
using TP_Contursi_Garau_Vegetti_Mangoldt_Maidana.Controlador;
using TP_Contursi_Garau_Vegetti_Mangoldt_Maidana;
using System.Diagnostics.Eventing.Reader;

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
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ocurrió un error al agregar el código del grupo: " + ex.Message);
                Console.ResetColor();
                Console.WriteLine();
                Console.ReadKey();
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
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No se encontró un permiso con el código ingresado.");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.ReadKey();
                    }
                }
            }

            ModeloGrupo grupo = new ModeloGrupo(codigo, nombre, listaPermisosGrupo);
            listaGrupos.Add(grupo);
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Grupo agregado exitosamente.");
            Console.ResetColor();
            Console.WriteLine();
            Console.ReadKey();

            return true;
        }

        public bool ModificarGrupo(List<ModeloGrupo> listaGrupos, List<ModeloPermiso> listaPermisos)
        {
            bool ok;
            int codigoPermisoModificado;

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
                    do
                    {
                        Console.Write("Ingrese el código del permiso a agregar al grupo (0 para finalizar): ");
                        ok = int.TryParse(Console.ReadLine(), out codigoPermisoModificado);
                    } while (!ok);
                    

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
                            Console.ForegroundColor= ConsoleColor.Red;
                            Console.WriteLine("No se encontró un permiso con el código ingresado.");
                            Console.ResetColor();
                        }
                    }
                }

                grupoModificar.ListaPermisos = listaPermisosGrupoModificado;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Grupo modificado exitosamente.");
                Console.ResetColor();
                Console.ReadKey();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No se encontró un grupo con el código ingresado.");
                Console.ResetColor();
                Console.ReadKey();
            }

            return true;
        }

        public bool EliminarGrupo(List<ModeloGrupo> listaGrupos, List<ModeloUsuario> listaUsuarios)
        {
            Console.WriteLine("=== Eliminar Grupo ===");

            ListarGrupos(listaGrupos);

            Console.Write("Ingrese el código del grupo a eliminar: ");
            
            int codigoEliminar;
            bool ok;

            do
            {
                Console.WriteLine();
                Console.Write("Ingrese el código del grupo a eliminar: ");
                ok = int.TryParse(Console.ReadLine(), out codigoEliminar);
            } while (!ok);

            ModeloGrupo grupoEliminar = listaGrupos.Find(g => g.Codigo == codigoEliminar);

            if (grupoEliminar != null)
            {
                // Verificar si el grupo está siendo utilizado por algún usuario
                bool grupoEnUso = false;

                grupoEnUso = listaUsuarios.Any(u => u.Grupo == grupoEliminar);

                //foreach (ModeloUsuario usuario in listaUsuarios)
                //{
                //    if (usuario.Grupo == grupoEliminar)
                //    {
                //        grupoEnUso = true;
                //        break;
                //    }
                //}

                if (!grupoEnUso)
                {
                    listaGrupos.Remove(grupoEliminar);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Grupo eliminado exitosamente.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No se puede eliminar el grupo porque está siendo utilizado por un usuario.");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No se encontró un grupo con el código ingresado.");
                Console.ResetColor();
            }

            return true;
        }
    }
}
