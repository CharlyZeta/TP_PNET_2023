using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_PNET.Vista
{
    class MensajesDeSisema
    {

        /// <summary>
        /// Este método escribe en pantalla el mensaje de Error pasado por parámetro en color ROJO
        /// </summary>
        /// <param name="mensaje">String mensaje </param>
        /// <returns>True</returns>
        public bool Error(String mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(mensaje);
            Console.ResetColor();
            Console.ReadKey();

            Console.SetCursorPosition(0, Console.CursorTop - 1); // Retroceder una línea
            Console.Write(new string(' ', Console.WindowWidth)); // Borrar la línea anterior

            return true;
        }

        /// <summary>
        /// Este método escribe en pantalla el mensaje de Exito pasado por parámetro en color VERDE
        /// </summary>
        /// <param name="mensaje">String mensaje </param>
        /// <returns>True</returns>
        public bool Exito(String mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(mensaje);
            Console.ResetColor();
            Console.ReadKey();

            Console.SetCursorPosition(0, Console.CursorTop - 1); // Retroceder una línea
            Console.Write(new string(' ', Console.WindowWidth)); // Borrar la línea anterior

            return true;
        }


        /// <summary>
        /// Este método escribe en pantalla el mensaje de Información pasado por parámetro en color AMARILLO
        /// </summary>
        /// <param name="mensaje">String mensaje </param>
        /// <returns>True</returns>
        public bool Info(String mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(mensaje);
            Console.ResetColor();

            return true;
        }
        public bool Menu(String mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(mensaje);
            Console.ResetColor();
            //Console.ReadKey();
            return true;
        }

        public void saludo()
        {

            Console.Clear();
            Console.WriteLine("\n");
            Console.WriteLine("    ██╗░░░██╗████████╗███╗░░██╗  ░░░░░░  ████████╗██╗░░░██╗████████╗██╗");
            Console.WriteLine("    ██║░░░██║╚══██╔══╝████╗░██║  ░░░░░░  ╚══██╔══╝██║░░░██║╚══██╔══╝██║");
            Console.WriteLine("    ██║░░░██║░░░██║░░░██╔██╗██║  █████╗  ░░░██║░░░██║░░░██║░░░██║░░░██║");
            Console.WriteLine("    ██║░░░██║░░░██║░░░██║╚████║  ╚════╝  ░░░██║░░░██║░░░██║░░░██║░░░██║");
            Console.WriteLine("    ╚██████╔╝░░░██║░░░██║░╚███║  ░░░░░░  ░░░██║░░░╚██████╔╝░░░██║░░░██║");
            Console.WriteLine("    ░╚═════╝░░░░╚═╝░░░╚═╝░░╚══╝  ░░░░░░  ░░░╚═╝░░░░╚═════╝░░░░╚═╝░░░╚═╝");
            Console.WriteLine("\n");
            Console.WriteLine("              ╔═════════════════════════════════════════════╗");
            Console.WriteLine("              ║         Trabajo Práctico PNET 2023          ║░");
            Console.WriteLine("              ╠═════════════════ PROFESOR ══════════════════╣░");
            Console.WriteLine("              ║          Ing. Germán Balbastro              ║░");
            Console.WriteLine("              ╠══════════════════ ALUMNOS ══════════════════╣░");
            Console.WriteLine("              ║              Contursi Julieta               ║░");
            Console.WriteLine("              ║                 Garau Juan                  ║░");
            Console.WriteLine("              ║                Vegetti Lucas                ║░");
            Console.WriteLine("              ║               Mangoldt Pablo                ║░");
            Console.WriteLine("              ║               Maidana Gerardo               ║░");
            Console.WriteLine("              ╚═════════════════════════════════════════════╝░");
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
