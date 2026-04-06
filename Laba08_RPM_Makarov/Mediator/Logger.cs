using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba08_RPM_Makarov.Mediator
{
    public class Logger : Colleague
    {
        public void WriteMessage(string message)
        {
            string timestamp = DateTime.Now.ToString("HH:mm:ss");
            Console.WriteLine($"[{timestamp}] [LOG] {message}");
        }

        public void WriteError(string message)
        {
            string timestamp = DateTime.Now.ToString("HH:mm:ss");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[{timestamp}] [ERROR] {message}");
            Console.ResetColor();
        }

        public void WriteSuccess(string message)
        {
            string timestamp = DateTime.Now.ToString("HH:mm:ss");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[{timestamp}] [SUCCESS] {message}");
            Console.ResetColor();
        }
    }
}
