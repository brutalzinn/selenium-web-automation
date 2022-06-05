using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomator
{
    public static class LogTime
    {
        public static  DateTime DateTimeIniciado { get; private set; }
        public static DateTime DateTimeFinalizado { get; private set; }
        public static TimeSpan TempoExecucao { get; private set; }

        public static void Iniciar()
        {
            DateTimeIniciado = DateTime.Now;
        }

        public static void Finalizar()
        {
            DateTimeFinalizado = DateTime.Now;
            TempoExecucao = DateTimeFinalizado.Subtract(DateTimeIniciado);
        }

        public static void ToConsole(this object value, string label, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine("{0} {1} ", label, value);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
