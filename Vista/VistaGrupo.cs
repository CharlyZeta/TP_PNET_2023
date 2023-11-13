using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_PNET.Controlador;

namespace TP_PNET.Vista
{
    class VistaGrupo
    {
        public bool MenuGrupo(List<ModeloPermiso> listaPermisos,
                              List<ModeloGrupo> listaGrupos,
                              List<ModeloUsuario> listaUsuarios,
                              bool volver)
        {

            ControladorGrupo ControladorGrupo = new ControladorGrupo();
            MensajesDeSisema msj = new MensajesDeSisema();


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

                msj.Info("Seleccione una opción del menú: ");

                ConsoleKeyInfo tecla = Console.ReadKey(true);

                switch (tecla.Key)
                {
                    case ConsoleKey.L:
                        ControladorGrupo.ListarGrupos(listaGrupos, true);
                        break;
                    case ConsoleKey.A:
                        ControladorGrupo.AltaGrupo(listaGrupos, listaPermisos);
                        break;
                    case ConsoleKey.M:
                        ControladorGrupo.ModificarGrupo(listaGrupos, listaPermisos);
                        break;
                    case ConsoleKey.E:
                        ControladorGrupo.EliminarGrupo(listaGrupos, listaUsuarios);
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
