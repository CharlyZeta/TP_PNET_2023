using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_PNET.Controlador;

namespace TP_PNET.Vista
{
    class VistaPermiso
    {
        static MensajesDeSisema msj = new MensajesDeSisema();
        public bool MenuPermiso(List<ModeloPermiso> listaPermisos, 
            List<ModeloGrupo> listaGrupos,
            List<ModeloUsuario> listaUsuarios, 
            bool volver)
        {
            volver = false;

            ControladorPermiso ControladorPermiso = new ControladorPermiso();

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

                msj.Info("Seleccione una opción del menú: ");

                ConsoleKeyInfo tecla = Console.ReadKey(true);

                switch (tecla.Key)
                {
                    case ConsoleKey.L:
                        ControladorPermiso.ListarPermisos(listaPermisos, true);
                        break;
                    case ConsoleKey.A:
                        ControladorPermiso.AltaPermiso(listaPermisos);
                        break;
                    case ConsoleKey.M:
                        ControladorPermiso.ModificarPermiso(listaPermisos);
                        break;
                    case ConsoleKey.E:
                        ControladorPermiso.EliminarPermiso(listaPermisos, listaUsuarios, listaGrupos);
                        break;
                    case ConsoleKey.V:
                        volver = true;
                        break;
                    default:
                        ;
                        break;
                }
            }
            return volver;

        }

    }
}
