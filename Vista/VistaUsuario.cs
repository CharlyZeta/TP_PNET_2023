using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_PNET.Vista;
using TP_PNET;

namespace TP_PNET
{
    class VistaUsuario
    {
        public bool MenuUsuario(List<ModeloPermiso> listaPermisos,
                                List<ModeloGrupo> listaGrupos,
                                List<ModeloUsuario> listaUsuarios,
                                bool volver)
        {

            ControladorUsuario ControladorUsuario = new ControladorUsuario();
            MensajesDeSisema msj = new MensajesDeSisema();

            while (!volver)
            {
                Console.Clear();
                Console.WriteLine("=== Menú Usuario ===");
                Console.WriteLine("L. Listar Usuarios");
                Console.WriteLine("A. Alta de Usuario");
                Console.WriteLine("M. Modificar Usuario");
                Console.WriteLine("E. Eliminar Usuario");
                Console.WriteLine("V. Volver");
                Console.WriteLine();

                msj.Info("Seleccione una opción del menú: ");

                ConsoleKeyInfo tecla = Console.ReadKey(true);

                switch (tecla.Key)
                {
                    case ConsoleKey.L:
                        ControladorUsuario.ListarUsuarios(listaUsuarios, true);
                        break;
                    case ConsoleKey.A:
                        ControladorUsuario.AltaUsuario(listaGrupos, listaPermisos, listaUsuarios);
                        break;
                    case ConsoleKey.M:
                        ControladorUsuario.ModificarUsuario(listaGrupos, listaPermisos, listaUsuarios);
                        break;
                    case ConsoleKey.E:
                        ControladorUsuario.EliminarUsuario(listaUsuarios);
                        break;
                    case ConsoleKey.V:
                        volver = true;
                        break;
                    default:
                        msj.Error("Opción inválida. Por favor, seleccione una opción válida.");
                        break;
                }
            }
            return volver;
        }
    }
}
