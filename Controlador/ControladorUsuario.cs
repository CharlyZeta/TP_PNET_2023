using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_PNET;
using TP_PNET.Vista;
using System.Text.RegularExpressions;

namespace TP_PNET
{
    class ControladorUsuario
    {
        static MensajesDeSisema msj = new MensajesDeSisema();
        /// <summary>
        /// Lista los usuarios del sistema informando Código, Nombre, Password, Email, Grupo y la lista de permisos asignados.
        /// Utiliza un valor booleano que pide o no que se pulse una tecla para continuar
        /// </summary>
        /// <param name="listaUsuarios">Lista de Usuarios</param>
        /// <param name="pideKey">si es TRUE pide confirmación al terminar de mostrar la lista en pantalla</param>
        /// <returns>True</returns>
        public bool ListarUsuarios(List<ModeloUsuario> listaUsuarios, bool pideKey)
        {
            Console.WriteLine("\n");

            msj.Menu("=== Lista de Usuarios ===");

            Console.WriteLine();

            foreach (ModeloUsuario usuario in listaUsuarios)
            {
                Console.WriteLine(usuario.ToString());
            }
            if (pideKey)
            {
                msj.Info("Presione una tecla para continuar...");
                Console.ReadKey();
            }
            
            return true;
        }
        /// <summary>
        /// Alta de usuarios del sistema. Genera ID automáticamente
        /// </summary>
        /// <param name="listaGrupos">Lista de grupos</param>
        /// <param name="listaPermisos">Lista de Permisos</param>
        /// <param name="listaUsuarios">Lista de Usuarios</param>
        /// <returns>TRUE</returns>
        public bool AltaUsuario(List<ModeloGrupo> listaGrupos,
                                List<ModeloPermiso> listaPermisos,
                                List<ModeloUsuario> listaUsuarios)
        {
            string nombre, error, password1, password2, email=null;
            int codigo=0, codigoGrupoUsuario;
            bool ok=false, emailValido=false;
            Regex passRegex = new Regex(@"^(?=.*[A-Za-z]{6,})(?=.*\d.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{6,}$");
            Regex emailRegex = new Regex(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$");

            Console.WriteLine("\n");
            
            msj.Menu("=== Alta de Usuario ===");
            
            Console.WriteLine() ;
            try
            {
                _ = listaUsuarios.Any() ? codigo = listaUsuarios.Max(p => p.Codigo) + 1 : codigo = 1;
                msj.Exito("Código agregado exitosamente.");
            } 
            catch (Exception ex)
            {
                msj.Error("Ocurrió un error al agregar el código del usuario: ");
                error = ex.ToString();
                msj.Error(error);
            }

            ok = false;
            // validamos que el nombre no esté vacío o tenga más de 3 carace
            do
            {
                Console.Write("Ingrese el nombre del usuario: ");
                nombre = Console.ReadLine();
                if (nombre.Length < 3)
                {
                    msj.Error($"El nombre debe tener al menos 3 letras!, tiene {nombre.Length} ");
                    Console.Write(new string(' ', Console.WindowWidth)); // Borrar la línea anterior
                }
                else
                {
                    msj.Exito("Lindo nombre!");
                    ok = true;
                }
            } while (!ok);

            // validar contraseña
            do
            {
                ok = false;

                Console.WriteLine("La contraseña del usuario debe contener al menos 6 letras, 2 numeros y 1 símbolo (@$!%*#?&)");
                Console.Write("Ingrese la contraseña: "); password1 = Console.ReadLine();
                Console.WriteLine();
                Console.Write("Ingrese nuevamente la contraseña: "); password2 = Console.ReadLine();
                Console.WriteLine();

                // Validar la contraseña con la expresión regular
                if (passRegex.IsMatch(password1) && (string.Compare(password1, password2, true)) == 0)
                {
                    ok = true;
                    msj.Exito("La contraseña es válida.");
                }
                else
                {
                    msj.Error("La contraseña no cumple con los requisitos.");
                }
                    
            } while (!ok);
            
            // validamos email
            while (!emailValido)
            {
                Console.Write("Ingrese el email del usuario: ");
                email = Console.ReadLine();
                if (emailRegex.IsMatch(email))
                {
                    emailValido = true;
                    msj.Exito("La dirección de correo electrónico es válida.\n");
                }
                else
                {
                    msj.Error("La dirección de correo electrónico no es válida.\n");
                }
            }

            ControladorGrupo m = new ControladorGrupo();
            m.ListarGrupos(listaGrupos, false);

            ModeloGrupo grupoUsuario;

            // Obtener el grupo para el usuario
            ok = false;
            do
            {
                Console.Write("Ingrese el código del grupo del usuario: ");
                ok = int.TryParse(Console.ReadLine(),out codigoGrupoUsuario);
                grupoUsuario = listaGrupos.Find(g => g.Codigo == codigoGrupoUsuario);

                if (grupoUsuario == null) msj.Error("Grupo no encontrado!");

            } while (grupoUsuario==null);
            


            if (grupoUsuario != null)
            {
                // Obtener la lista de permisos para el usuario
                List<ModeloPermiso> listaPermisosUsuario = new List<ModeloPermiso>();

                bool agregarMasPermisosUsuario = true;

                while (agregarMasPermisosUsuario)
                {
                    Console.Write("Ingrese el código del permiso a agregar al usuario (0 para finalizar): ");
                    int codigoPermisoUsuario = Convert.ToInt32(Console.ReadLine());//cambiar

                    if (codigoPermisoUsuario == 0)
                    {
                        agregarMasPermisosUsuario = false;
                    }
                    else
                    {
                        ModeloPermiso permisoEncontradoUsuario = listaPermisos.Find(p => p.Codigo == codigoPermisoUsuario);

                        if (permisoEncontradoUsuario != null)
                        {
                            listaPermisosUsuario.Add(permisoEncontradoUsuario);
                        }
                        else
                        {
                            msj.Error("No se encontró un permiso con el código ingresado.");
                        }
                    }
                }
            }

            ModeloUsuario usuario = new ModeloUsuario(codigo, nombre, password1, email, grupoUsuario,listaPermisos);

            listaUsuarios.Add(usuario);

            msj.Exito("Grupo agregado exitosamente.");

            return true;
        }

        /// <summary>
        /// Modifica los datos del usuario del sistema. Permite cambiar todos los datos menos el ID. Da la opción de ignorar cambios en parte de los datos. Es obligatorio cargarle al menos un permiso y un grupo al usuario.
        /// </summary>
        /// <param name="listaGrupos">Lista de grupos</param>
        /// <param name="listaPermisos">Lista de Permisos</param>
        /// <param name="listaUsuario">Lista de Usuarios</param>
        public void ModificarUsuario(List<ModeloGrupo> listaGrupos,
                                     List<ModeloPermiso> listaPermisos,
                                     List<ModeloUsuario> listaUsuario)
        {
            bool ok = false;
            int codigoPermisoUsuario = 0, codigoUsuario;

            ListarUsuarios(listaUsuario, false);

            do
            {
                Console.Write("Ingrese el código del usuario a modificar: ");

                ok = int.TryParse(Console.ReadLine(), out codigoUsuario);

            } while (!ok);

            msj.Menu("=== Modificación de Usuario ===");

            ModeloUsuario usuarioEncontrado = listaUsuario.Find(u => u.Codigo == codigoUsuario);

            if (usuarioEncontrado != null)
            {
                Console.Write("Ingrese el nuevo nombre del usuario (dejar vacío si no desea modificar): ");
                string nombreNuevo = Console.ReadLine();

                if (!string.IsNullOrEmpty(nombreNuevo))              
                    usuarioEncontrado.Nombre = nombreNuevo;
                

                Console.Write("Ingrese la nueva contraseña del usuario (dejar vacío si no desea modificar): ");
                string passwordNuevo = Console.ReadLine();

                if (!string.IsNullOrEmpty(passwordNuevo))
                    usuarioEncontrado.Password = passwordNuevo;


                Console.Write("Ingrese el nuevo email del usuario (dejar vacío si no desea modificar): ");
                string emailNuevo = Console.ReadLine();

                if (!string.IsNullOrEmpty(emailNuevo))
                    usuarioEncontrado.Email = emailNuevo;

                Console.Write("Ingrese el nuevo código del grupo del usuario (dejar vacío si no desea modificar): ");
                string codigoGrupoUsuarioNuevoString = Console.ReadLine();

                if (!string.IsNullOrEmpty(codigoGrupoUsuarioNuevoString))
                {
                    int codigoGrupoUsuarioNuevo = Convert.ToInt32(codigoGrupoUsuarioNuevoString);

                    ModeloGrupo grupoUsuarioNuevo = listaGrupos.Find(g => g.Codigo == codigoGrupoUsuarioNuevo);

                    if (grupoUsuarioNuevo != null)
                    {
                        usuarioEncontrado.Grupo = grupoUsuarioNuevo;
                    }
                    else
                    {
                        msj.Error("No se encontró un grupo con el código ingresado.");
                    }
                }

                // Obtiene la lista de permisos actual del usuario
                List<ModeloPermiso> listaPermisosUsuarioActual = usuarioEncontrado.ListaPermisos;

                // Obtiene la lista de permisos para el usuario
                List<ModeloPermiso> listaPermisosUsuarioNueva = new List<ModeloPermiso>();

                bool agregarMasPermisosUsuario = true;

                while (agregarMasPermisosUsuario)
                {
                    do
                    {
                        Console.Write("Ingrese el código del permiso a agregar al usuario (0 para finalizar): ");
                        //

                        ok = int.TryParse(Console.ReadLine(), out codigoPermisoUsuario);
                        
                    } while (!ok);
                    

                    if (codigoPermisoUsuario == 0)
                    {
                        agregarMasPermisosUsuario = false;
                    }
                    else
                    {
                        ModeloPermiso permisoEncontradoUsuario = listaPermisos.Find(p => p.Codigo == codigoPermisoUsuario);

                        if (permisoEncontradoUsuario != null)
                        {
                            listaPermisosUsuarioNueva.Add(permisoEncontradoUsuario);
                        }
                        else
                        {
                            msj.Error("No se encontró un permiso con el código ingresado.");
                        }
                    }
                }

                Console.WriteLine("El usuario cuenta con los siguientes permisos: ");
                listaPermisosUsuarioNueva.ForEach(permiso => Console.WriteLine($"ID: {permiso.Codigo},  {permiso.Nombre}"));

                // Reemplaza la lista de permisos actual del usuario con la nueva lista de permisos 
                usuarioEncontrado.ListaPermisos = listaPermisosUsuarioNueva;

                msj.Exito("Usuario modificado exitosamente.");
            }
            else
            {
                msj.Error("No se encontró un usuario con el código ingresado.");
            }
        }


        /// <summary>
        /// Elimina el usuario del sistema
        /// </summary>
        /// <param name="listaUsuarios">Lista de Usuarios</param>
        /// <returns>True</returns>
        public bool EliminarUsuario(List<ModeloUsuario> listaUsuarios)
        {
            bool ok = false;
            int codigoUsuarioEliminar;

            Console.WriteLine("\n");

            ListarUsuarios(listaUsuarios, false );

            msj.Menu("=== Eliminación de Usuario ===");

            Console.WriteLine("\n");

            do
            {
                Console.Write("Ingrese el código del usuario a eliminar: ");

                ok = int.TryParse(Console.ReadLine(), out codigoUsuarioEliminar);

            } while (!ok);

            ModeloUsuario usuarioEncontrado = listaUsuarios.Find(u => u.Codigo == codigoUsuarioEliminar);

            if (usuarioEncontrado != null)
            {
                listaUsuarios.Remove(usuarioEncontrado);

                msj.Exito("Usuario modificado exitosamente.");
            }
            else
            {
                msj.Error("No se encontró un usuario con el código ingresado.");
            }

            return true;
        }
    }

}
