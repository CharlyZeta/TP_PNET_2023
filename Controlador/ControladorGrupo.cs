using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_PNET.Vista;
using TP_PNET.Controlador;
using TP_PNET;


namespace TP_PNET.Controlador
{
    class ControladorGrupo
    {
        static MensajesDeSisema msj = new MensajesDeSisema();

        /// <summary>
        /// Lista de grupos del sistema informando Código, Nombre y la lista de permisos.
        /// Utiliza un valor booleano que pide o no que se pulse una tecla para continuar
        /// </summary>
        /// <param name="listaGrupos">Lista de grupos</param>
        /// <param name="pideKey">si es TRUE pide confirmación al terminar de mostrar la lista en pantalla</param>
        /// <returns></returns>
        public bool ListarGrupos(List<ModeloGrupo> listaGrupos, bool pideKey)
        {
            Console.WriteLine("\n");

            Console.WriteLine("=== Lista de Grupos ===");

            Console.WriteLine();

            foreach (ModeloGrupo grupo in listaGrupos)
            {
                Console.WriteLine(grupo.ToString());
            }
            if (pideKey)
            {
                msj.Info("Presione una tecla para continuar...");
                Console.ReadKey();
            }
            return true;
        }

        /// <summary>
        /// Alta de grupos del sistema. Genera ID automáticamente
        /// </summary>
        /// <param name="listaGrupos">Lista de grupos</param>
        /// <param name="listaPermisos">Lista de Permisos</param>
        /// <returns>TRUE</returns>
        public List<ModeloGrupo> AltaGrupo(List<ModeloGrupo> listaGrupos, List<ModeloPermiso> listaPermisos)
        {
            int codigo = 0;
            string error, nombre;
            Console.WriteLine("\n");

            Console.WriteLine("=== Alta de Grupo ===");

            Console.WriteLine();

            try
            {
                // si la lista está vacía le asigna al primer código el 1, si ya tiene valores incrementa el valor máximo.
                _ = listaGrupos.Any() ? codigo = listaGrupos.Max(p => p.Codigo) + 1 : codigo = 1;

                msj.Exito("Código agregado exitosamente.");
            }
            catch (Exception ex)
            {
                msj.Error("Ocurrió un error al agregar el código del grupo: ");
                error = ex.ToString();
                msj.Error(error);
            }

            do
            {
                Console.Write("Ingrese el nombre del grupo: ");
                nombre = Console.ReadLine();
            } while (string.IsNullOrEmpty(nombre));

            // Obtener la lista de permisos para el grupo
            List < ModeloPermiso > listaPermisosGrupo = new List<ModeloPermiso>();

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
                        msj.Error("No se encontró un permiso con el código ingresado.");
                    }
                }
            }

            ModeloGrupo grupo = new ModeloGrupo(codigo, nombre, listaPermisosGrupo);

            try
            {
                listaGrupos.Add(grupo);
            
            msj.Exito("Grupo agregado exitosamente.");
            }
            catch (Exception ex)
            {
                msj.Error("Ocurrió un error al agregar el grupo: ");
                error = ex.Message;
                msj.Error(error + "Presione una tecla para continuar.");
            }
            return listaGrupos;
        }


        /// <summary>
        /// Modifica los datos del grupo del sistema. Permite cambiar todos los datos menos el ID. Es obligatorio cargarle al menos un permiso y un grupo al usuario.
        /// </summary>
        /// <param name="listaGrupos">Lista de grupos</param>
        /// <param name="listaPermisos">Lista de Permisos</param>
        public bool ModificarGrupo(List<ModeloGrupo> listaGrupos, List<ModeloPermiso> listaPermisos)
        {
            bool ok;
            int codigoPermisoModificado, codigoModificar;
            string nuevoNombre;

            Console.WriteLine("\n");

            Console.WriteLine("=== Modificar Grupo ===");

            ListarGrupos(listaGrupos, false);
            do
            {
                Console.Write("Ingrese el código del grupo a modificar: ");
                ok = int.TryParse(Console.ReadLine(), out codigoModificar);
            }while (!ok);

            // busca el código dentro de la lista de grupos
            ModeloGrupo grupoModificar = listaGrupos.Find(g => g.Codigo == codigoModificar);

            if (grupoModificar != null)
            {
                do
                {
                    Console.Write("Ingrese el nuevo nombre del grupo: ");
                    nuevoNombre = Console.ReadLine();
                }while (string.IsNullOrEmpty(nuevoNombre)) ;
                
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
                            msj.Error("No se encontró un permiso con el código ingresado.");
                        }
                    }
                }

                grupoModificar.ListaPermisos = listaPermisosGrupoModificado;

                msj.Exito("Grupo modificado exitosamente.");
            }
            else
            {
                msj.Error("No se encontró un grupo con el código ingresado.");
            }

            return true;
        }


        /// <summary>
        /// Elimina el usuario del sistema
        /// </summary>
        /// <!----> 
        /// <param name="listaGrupos">Lista de Grupos</param>
        /// <param name="listaUsuarios">Lista de Usuarios</param>
        /// <returns>True</returns>
        public bool EliminarGrupo(List<ModeloGrupo> listaGrupos, List<ModeloUsuario> listaUsuarios)
        {
            int codigoEliminar;
            bool ok;
            Console.WriteLine("\n");

            Console.WriteLine("=== Eliminar Grupo ===");

            ListarGrupos(listaGrupos, false );

            do
            {
                Console.WriteLine();
                Console.Write("Ingrese el código del grupo a eliminar: ");
                ok = int.TryParse(Console.ReadLine(), out codigoEliminar);
            } while (!ok);

            ModeloGrupo grupoEliminar = listaGrupos.Find(g => g.Codigo == codigoEliminar);

            if (grupoEliminar != null)
            {
                // Verifica si el grupo está siendo utilizado por algún usuario
                bool grupoEnUso = false;

                grupoEnUso = listaUsuarios.Any(u => u.Grupo == grupoEliminar);

                if (!grupoEnUso)
                {
                    listaGrupos.Remove(grupoEliminar);

                    msj.Exito("Grupo eliminado exitosamente.");
                }
                else
                {
                    msj.Error("No se puede eliminar el grupo porque está siendo utilizado por un usuario.");
                }
            }
            else
            {
                msj.Error("No se encontró un grupo con el código ingresado.");
            }
            Console.ReadKey();
            return true;
        }
    }
}
