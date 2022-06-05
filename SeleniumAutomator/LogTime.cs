using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomator
{
    public class LogTime
    {
        public DateTime DateTimeIniciado { get; private set; }
        public DateTime DateTimeFinalizado { get; private set; }
        public TimeSpan TempoExecucao { get; private set; }

        public void Iniciar()
        {
            DateTimeIniciado = DateTime.Now;
        }

        public void Finalizar()
        {
            DateTimeFinalizado = DateTime.Now;
            TempoExecucao = DateTimeFinalizado.Subtract(DateTimeIniciado);
        }

        public void ToConsoleWriteLine(string label, object value, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine("{0} {1} ", label, value);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
