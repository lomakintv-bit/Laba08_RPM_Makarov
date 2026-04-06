using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laba08_RPM_Makarov.Mediator;

namespace Laba08_RPM_Makarov.State
{
    public class ErrorState : IDocumentState
    {
        public void Print(Document document)
        {
            Console.WriteLine($"[FSM: Error] Печать документа '{document.Title}' невозможна из-за ошибки. Сначала сбросьте документ (Reset).");
        }

        public void AddToQueue(Document document)
        {
            Console.WriteLine($"[FSM: Error] Нельзя добавить документ '{document.Title}' в очередь из-за ошибки. Сначала сбросьте документ.");
        }

        public void CompletePrinting(Document document)
        {
            Console.WriteLine($"[FSM: Error] Невозможно завершить печать - документ в состоянии ошибки.");
        }

        public void FailPrinting(Document document)
        {
            Console.WriteLine($"[FSM: Error] Документ '{document.Title}' уже в состоянии ошибки.");
        }

        public void Reset(Document document)
        {
            Console.WriteLine($"[FSM: Error -> New] Документ '{document.Title}' сброшен и готов к повторной печати.");
            document.SetState(new NewState());
        }
    }
}
