using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using TP_PNET;
using TP_PNET.Vista;

namespace TP_PNET
{
    class VistaPrincipal
    {
        static MensajesDeSisema msj = new MensajesDeSisema();

        public bool menuPrincipal(List<ModeloPermiso> listaPermisos, List<ModeloGrupo> listaGrupos, List<ModeloUsuario> listaUsuarios, bool salir){

            VistaPermiso VistaPermiso = new VistaPermiso();
            VistaGrupo VistaGrupo = new VistaGrupo();
            VistaUsuario VistaUsuario = new VistaUsuario();

            Console.Clear();
            Console.WriteLine("======================");
            Console.WriteLine("=== Menú Principal ===");
            Console.WriteLine("P. Permiso");
            Console.WriteLine("G. Grupo");
            Console.WriteLine("U. Usuario");
            Console.WriteLine("S. Salir");
            Console.WriteLine();

            msj.Info("Seleccione una opción del menú: ");

            ConsoleKeyInfo tecla = Console.ReadKey(true);

            switch (tecla.Key)
            {
                case ConsoleKey.P:
                    VistaPermiso.MenuPermiso(listaPermisos,listaGrupos,listaUsuarios,false);
                    break;
                case ConsoleKey.G:
                    VistaGrupo.MenuGrupo(listaPermisos, listaGrupos, listaUsuarios, false);
                    break;
                case ConsoleKey.U:
                    VistaUsuario.MenuUsuario(listaPermisos, listaGrupos, listaUsuarios, false);
                    break;
                case ConsoleKey.S:
                    salir = true;
                    msj.saludo();
                    break;
                default:
                    msj.Error("Opción inválida. Por favor, seleccione una opción válida.");
                    break;
            }
            return salir;
        }
    }
}
