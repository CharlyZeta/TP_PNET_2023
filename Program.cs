using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_PNET;
using TP_PNET.Vista;
using System.Collections;


namespace TP_PNET
{
    class Program
    {
        static MensajesDeSisema msj = new MensajesDeSisema();
        static List<ModeloPermiso> listaPermisos = new List<ModeloPermiso>();
        static List<ModeloGrupo> listaGrupos = new List<ModeloGrupo>();
        static List<ModeloUsuario> listaUsuarios = new List<ModeloUsuario>();
        
        static void Main()
        {
            DataInitializer data = new DataInitializer();

            data.DataInit(listaPermisos,listaGrupos,listaUsuarios); // se cargan datos de prueba.

            bool salir = false;

            while (!salir)
            {
                VistaPrincipal principal = new VistaPrincipal();

                salir = principal.menuPrincipal(listaPermisos,listaGrupos,listaUsuarios, salir); // se accede al menu principal
            }
        }
    }
}