using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_PNET;
using TP_PNET.Vista;
using TP_PNET.Controlador;
using System.Collections;

namespace TP_PNET
{
    class Program
    {
        //static List<ModeloPermiso> listaPermisos = new List<ModeloPermiso>();
        //static List<ModeloGrupo> listaGrupos = new List<ModeloGrupo>();
        //static List<ModeloUsuario> listaUsuarios = new List<ModeloUsuario>();
                
        static MensajesDeSisema msj = new MensajesDeSisema();

        
        static void Main()
        {

            List<ModeloPermiso> listaPermisos = new List<ModeloPermiso>();
            List<ModeloGrupo> listaGrupos = new List<ModeloGrupo>();
            List<ModeloUsuario> listaUsuarios = new List<ModeloUsuario>();

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

            while (!salir)
            {
                           
                VistaPrincipal principal = new VistaPrincipal();
                salir = principal.menuPrincipal(listaPermisos,listaGrupos,listaUsuarios, salir);

                
            }
        }

        
        //static void MenuPermiso()
        //{
        //    bool volver = false;

        //    ControladorPermiso Permiso = new ControladorPermiso();

        //    while (!volver)
        //    {
        //        Console.Clear();
        //        Console.WriteLine("=== Menú Permiso ===");
        //        Console.WriteLine("L. Listar Permisos");
        //        Console.WriteLine("A. Alta de Permiso");
        //        Console.WriteLine("M. Modificar Permiso");
        //        Console.WriteLine("E. Eliminar Permiso");
        //        Console.WriteLine("V. Volver");
        //        Console.WriteLine();

        //        msj.Info("Seleccione una opción del menú: ");

        //        ConsoleKeyInfo tecla = Console.ReadKey(true);

        //        switch (tecla.Key)
        //        {
        //            case ConsoleKey.L:
        //                Permiso.ListarPermisos(listaPermisos, true);
        //                break;
        //            case ConsoleKey.A:
        //                Permiso.AltaPermiso(listaPermisos);
        //                break;
        //            case ConsoleKey.M:
        //                Permiso.ModificarPermiso(listaPermisos);
        //                break;
        //            case ConsoleKey.E:
        //                Permiso.EliminarPermiso(listaPermisos, listaUsuarios, listaGrupos);
        //                break;
        //            case ConsoleKey.V:
        //                volver = true;
        //                break;
        //            default:
        //                ;
        //                break;
        //        }
        //    }
        //}

        //static void MenuGrupo()
        //{
        //    bool volver = false;
        //    ControladorGrupo grupo = new ControladorGrupo();
        //    MensajesDeSisema mensaje = new MensajesDeSisema();

        //    while (!volver)
        //    {
        //        Console.Clear();
        //        Console.WriteLine("=== Menú Grupo ===");
        //        Console.WriteLine("L. Listar Grupos");
        //        Console.WriteLine("A. Alta de Grupo");
        //        Console.WriteLine("M. Modificar Grupo");
        //        Console.WriteLine("E. Eliminar Grupo");
        //        Console.WriteLine("V. Volver");
        //        Console.WriteLine();

        //        msj.Info("Seleccione una opción del menú: ");

        //        ConsoleKeyInfo tecla = Console.ReadKey(true);

        //        switch (tecla.Key)
        //        {
        //            case ConsoleKey.L:
        //                grupo.ListarGrupos(listaGrupos, true);
        //                break;
        //            case ConsoleKey.A:
        //                grupo.AltaGrupo(listaGrupos, listaPermisos);
        //                break;
        //            case ConsoleKey.M:
        //                grupo.ModificarGrupo(listaGrupos, listaPermisos);
        //                break;
        //            case ConsoleKey.E:
        //                grupo.EliminarGrupo(listaGrupos, listaUsuarios);
        //                break;
        //            case ConsoleKey.V:
        //                volver = true;
        //                break;
        //            default:
        //                mensaje.Error("Opción inválida. Por favor, seleccione una opción válida.");
        //                break;
        //        }
        //    }
        //}

        //static void MenuUsuario()
        //{
        //    bool volver = false;
        //    ControladorUsuario usuario = new ControladorUsuario();
        //    MensajesDeSisema mensaje = new MensajesDeSisema();

        //    while (!volver)
        //    {
        //        Console.Clear();
        //        Console.WriteLine("=== Menú Usuario ===");
        //        Console.WriteLine("L. Listar Usuarios");
        //        Console.WriteLine("A. Alta de Usuario");
        //        Console.WriteLine("M. Modificar Usuario");
        //        Console.WriteLine("E. Eliminar Usuario");
        //        Console.WriteLine("V. Volver");
        //        Console.WriteLine();

        //        msj.Info("Seleccione una opción del menú: ");

        //        ConsoleKeyInfo tecla = Console.ReadKey(true);

        //        switch (tecla.Key)
        //        {
        //            case ConsoleKey.L:
        //                usuario.ListarUsuarios(listaUsuarios, true);
        //                break;
        //            case ConsoleKey.A:
        //                usuario.AltaUsuario(listaGrupos, listaPermisos, listaUsuarios);
        //                break;
        //            case ConsoleKey.M:
        //                usuario.ModificarUsuario(listaGrupos, listaPermisos, listaUsuarios);
        //                break;
        //            case ConsoleKey.E:
        //                usuario.EliminarUsuario(listaUsuarios);
        //                break;
        //            case ConsoleKey.V:
        //                volver = true;
        //                break;
        //            default:
        //                mensaje.Error("Opción inválida. Por favor, seleccione una opción válida.");
        //                break;
        //        }
        //    }
        //}


    }
}