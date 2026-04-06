using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laba08_RPM_Makarov.Mediator;

namespace Laba08_RPM_Makarov.State
{
    public class PrintingState : IDocumentState
    {
        public void Print(Document document)
        {
            Console.WriteLine($"[FSM: Printing] Документ '{document.Title}' уже печатается.");
        }

        public void AddToQueue(Document document)
        {
            Console.WriteLine($"[FSM: Printing] Нельзя добавить документ '{document.Title}' в очередь - он уже печатается.");
        }

        public void CompletePrinting(Document document)
        {
            Console.WriteLine($"[FSM: Printing -> Done] Печать документа '{document.Title}' успешно завершена.");
            document.SetState(new DoneState());
        }

        public void FailPrinting(Document document)
        {
            Console.WriteLine($"[FSM: Printing -> Error] При печати документа '{document.Title}' произошла ошибка.");
            document.SetState(new ErrorState());
        }

        public void Reset(Document document)
        {
            Console.WriteLine($"[FSM: Printing] Нельзя сбросить документ '{document.Title}' во время печати.");
        }
    }
}
