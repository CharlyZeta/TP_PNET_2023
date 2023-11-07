using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_PNET;
using TP_PNET.Controlador;
using TP_Contursi_Garau_Vegetti_Mangoldt_Maidana;

namespace TP_PNET
{
    class Program
    {
        static List<ModeloPermiso> listaPermisos = new List<ModeloPermiso>();
        static List<ModeloGrupo> listaGrupos = new List<ModeloGrupo>();
        static List<ModeloUsuario> listaUsuarios = new List<ModeloUsuario>();

        static void Main(string[] args)
        {
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("=== Menú Principal ===");
                Console.WriteLine("P. Permiso");
                Console.WriteLine("G. Grupo");
                Console.WriteLine("U. Usuario");
                Console.WriteLine("S. Salir");
                Console.WriteLine();

                ConsoleKeyInfo tecla = Console.ReadKey();

                switch (tecla.KeyChar)
                {
                    case 'p':
                        MenuPermiso(listaPermisos);
                        break;
                    case 'P':
                        MenuPermiso(listaPermisos);
                        break;
                    case 'g':
                        MenuGrupo();
                        break;
                    case 'G':
                        MenuGrupo();
                        break;
                    case 'u':
                        MenuUsuario();
                        break;
                    case 'U':
                        MenuUsuario();
                        break;
                    case 's':
                        salir = true;
                        break;
                    case 'S':
                        salir = true;
                        break;
                    default:
                        MensajeOpcionInvalida();
                        break;
                }
            }
        }

        private static void MensajeOpcionInvalida()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
            Console.ResetColor();
        }

        static void MenuPermiso(List<ModeloPermiso>listaPermisos)
        {
            bool volver = false;

            ControladorPermiso Permiso = new ControladorPermiso();

            while (!volver)
            {
                Console.Clear();
                Console.WriteLine("=== Menú Permiso ===");
                Console.WriteLine("L. Listar Permisos");
                Console.WriteLine("A. Alta de Permiso");
                Console.WriteLine("M. Modificar Permiso");
                Console.WriteLine("E. Eliminar Permiso");
                Console.WriteLine("V. Volver");
                Console.WriteLine();

                //int opcionPermiso = Convert.ToInt32(Console.ReadLine());

                ConsoleKeyInfo tecla = Console.ReadKey();
                switch (tecla.KeyChar)
                //switch (opcionPermiso)
                {
                    case 'l':
                        Permiso.ListarPermisos(listaPermisos);
                        break;
                    case 'L':
                        Permiso.ListarPermisos(listaPermisos);
                        break;
                    case 'a':
                        Permiso.AltaPermiso(listaPermisos);
                        break;
                    case 'A':
                        Permiso.AltaPermiso(listaPermisos);
                        break;
                    case 'm':
                        Permiso.ModificarPermiso(listaPermisos);
                        break;
                    case 'M':
                        Permiso.ModificarPermiso(listaPermisos);
                        break;
                    case 'e':
                        Permiso.EliminarPermiso(listaPermisos, listaUsuarios, listaGrupos);
                        break;
                    case 'E':
                        Permiso.EliminarPermiso(listaPermisos, listaUsuarios, listaGrupos);
                        break;
                    case 'v':
                        volver = true;
                        break;
                    case 'V':
                        volver = true;
                        break;
                    default:
                        MensajeOpcionInvalida();
                        break;
                }
            }
        }

        static void MenuGrupo()
        {
            bool volver = false;
            ControladorGrupo grupo = new ControladorGrupo();

            while (!volver)
            {
                Console.Clear();
                Console.WriteLine("=== Menú Grupo ===");
                Console.WriteLine("L. Listar Grupos");
                Console.WriteLine("A. Alta de Grupo");
                Console.WriteLine("M. Modificar Grupo");
                Console.WriteLine("E. Eliminar Grupo");
                Console.WriteLine("V. Volver");
                Console.WriteLine();

                //int opcionGrupo = Convert.ToInt32(Console.ReadLine());
                
                ConsoleKeyInfo tecla = Console.ReadKey();
                
                switch (tecla.KeyChar)
                {
                    case 'l':
                        grupo.ListarGrupos(listaGrupos);
                        break;
                    case 'L':
                        grupo.ListarGrupos(listaGrupos);
                        break;
                    case 'a':
                        grupo.AltaGrupo(listaGrupos, listaPermisos);
                        break;
                    case 'A':
                        grupo.AltaGrupo(listaGrupos, listaPermisos);
                        break;
                    case 'm':
                        grupo.ModificarGrupo(listaGrupos, listaPermisos);
                        break;
                    case 'M':
                        grupo.ModificarGrupo(listaGrupos, listaPermisos);
                        break;
                    case 'e':
                        grupo.EliminarGrupo(listaGrupos, listaUsuarios);
                        break;
                    case 'E':
                        grupo.EliminarGrupo(listaGrupos, listaUsuarios);
                        break;
                    case 'v':
                        volver = true;
                        break;
                    case 'V':
                        volver = true;
                        break;
                    default:
                        MensajeOpcionInvalida();
                        break;
                }
            }
        }

        static void MenuUsuario()
        {
            bool volver = false;

            while (!volver)
            {
                Console.Clear();
                Console.WriteLine("=== Menú Usuario ===");
                Console.WriteLine("1. Listar Usuarios");
                Console.WriteLine("2. Alta de Usuario");
                Console.WriteLine("3. Modificar Usuario");
                Console.WriteLine("4. Eliminar Usuario");
                Console.WriteLine("5. Volver");
                Console.WriteLine();

                //int opcionUsuario = Convert.ToInt32(Console.ReadLine());

                ConsoleKeyInfo tecla = Console.ReadKey();

                //switch (opcionUsuario)
                //switch (tecla.KeyChar)
                //{
                //    case 1:
                //        ListarUsuarios();
                //        break;
                //    case 2:
                //        AltaUsuario();
                //        break;
                //    case 3:
                //        ModificarUsuario();
                //        break;
                //    case 4:
                //        EliminarUsuario();
                //        break;
                //    case 5:
                //        volver = true;
                //        break;
                //    default:
                //        MensajeOpcionInvalida();
                //        break;
                //}
            }
        }


    }
}