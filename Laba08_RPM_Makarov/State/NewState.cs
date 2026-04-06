using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laba08_RPM_Makarov.Mediator;

namespace Laba08_RPM_Makarov.State
{
    public class NewState : IDocumentState
    {
        public void Print(Document document)
        {
            // Запрос на печать через посредника
            document.Mediator?.Notify(document, "RequestPrint", document);
        }

        public void AddToQueue(Document document)
        {
            // Добавление в очередь через посредника
            document.Mediator?.Notify(document, "AddToQueue", document);
        }

        public void CompletePrinting(Document document)
        {
            Console.WriteLine($"[FSM: New] Невозможно завершить печать - документ ещё не печатается.");
        }

        public void FailPrinting(Document document)
        {
            Console.WriteLine($"[FSM: New] Невозможно зафиксировать ошибку - документ ещё не печатается.");
        }

        public void Reset(Document document)
        {
            Console.WriteLine($"[FSM: New] Документ уже в состоянии New, сброс не требуется.");
        }
    }
}
