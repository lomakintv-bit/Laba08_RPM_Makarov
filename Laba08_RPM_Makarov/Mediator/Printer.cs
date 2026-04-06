using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba08_RPM_Makarov.Mediator
{
    public class Printer : Colleague
    {
        public bool SimulateFailure { get; set; } = false;

        public void StartPrint(Document document)
        {
            Console.WriteLine($"[Принтер] Начало физической печати документа '{document.Title}'...");

            if (SimulateFailure)
            {
                Console.WriteLine($"[Принтер] ПРОИЗОШЛА ОШИБКА при печати документа '{document.Title}'!");
                SimulateFailure = false;  // Сбрасываем флаг для следующей печати
                Mediator?.Notify(this, "PrintFailed", document);
            }
            else
            {
                Console.WriteLine($"[Принтер] Успешная печать документа '{document.Title}'.");
                Mediator?.Notify(this, "PrintSuccess", document);
            }
        }
    }
}
