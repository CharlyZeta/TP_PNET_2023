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
                Console.WriteLine("1. Permiso");
                Console.WriteLine("2. Grupo");
                Console.WriteLine("3. Usuario");
                Console.WriteLine("4. Salir");

                ConsoleKeyInfo tecla = Console.ReadKey();

                switch (tecla.KeyChar)
                {
                    case '1':
                        MenuPermiso(listaPermisos);
                        break;
                    case '2':
                        MenuGrupo();
                        break;
                    case '3':
                        MenuUsuario();
                        break;
                    case '4':
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
                Console.WriteLine("1. Listar Permisos");
                Console.WriteLine("2. Alta de Permiso");
                Console.WriteLine("3. Modificar Permiso");
                Console.WriteLine("4. Eliminar Permiso");
                Console.WriteLine("5. Volver");

                //int opcionPermiso = Convert.ToInt32(Console.ReadLine());

                ConsoleKeyInfo tecla = Console.ReadKey();
                switch (tecla.KeyChar)
                //switch (opcionPermiso)
                {
                    case '1':
                        Permiso.ListarPermisos(listaPermisos);
                        break;
                    case '2':
                        Permiso.AltaPermiso(listaPermisos);
                        break;
                    case '3':
                        Permiso.ModificarPermiso(listaPermisos);
                        break;
                    case '4':
                        Permiso.EliminarPermiso(listaPermisos, listaUsuarios, listaGrupos);
                        break;
                    case '5':
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

            while (!volver)
            {
                Console.WriteLine("=== Menú Grupo ===");
                Console.WriteLine("1. Listar Grupos");
                Console.WriteLine("2. Alta de Grupo");
                Console.WriteLine("3. Modificar Grupo");
                Console.WriteLine("4. Eliminar Grupo");
                Console.WriteLine("5. Volver");

                int opcionGrupo = Convert.ToInt32(Console.ReadLine());

                //switch (opcionGrupo)
                //{
                //    case 1:
                //        ListarGrupos();
                //        break;
                //    case 2:
                //        AltaGrupo();
                //        break;
                //    case 3:
                //        ModificarGrupo();
                //        break;
                //    case 4:
                //        EliminarGrupo();
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

        static void MenuUsuario()
        {
            bool volver = false;

            while (!volver)
            {
                Console.WriteLine("=== Menú Usuario ===");
                Console.WriteLine("1. Listar Usuarios");
                Console.WriteLine("2. Alta de Usuario");
                Console.WriteLine("3. Modificar Usuario");
                Console.WriteLine("4. Eliminar Usuario");
                Console.WriteLine("5. Volver");

                int opcionUsuario = Convert.ToInt32(Console.ReadLine());

                //switch (opcionUsuario)
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