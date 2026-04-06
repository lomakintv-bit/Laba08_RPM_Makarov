using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laba08_RPM_Makarov.Mediator;

namespace Laba08_RPM_Makarov.State
{
    public class DoneState : IDocumentState
    {
        public void Print(Document document)
        {
            Console.WriteLine($"[FSM: Done] Документ '{document.Title}' уже напечатан. Нельзя напечатать повторно.");
        }

        public void AddToQueue(Document document)
        {
            Console.WriteLine($"[FSM: Done] Нельзя добавить напечатанный документ '{document.Title}' в очередь.");
        }

        public void CompletePrinting(Document document)
        {
            Console.WriteLine($"[FSM: Done] Документ '{document.Title}' уже завершён.");
        }

        public void FailPrinting(Document document)
        {
            Console.WriteLine($"[FSM: Done] Нельзя зафиксировать ошибку для уже напечатанного документа.");
        }

        public void Reset(Document document)
        {
            Console.WriteLine($"[FSM: Done] Нельзя сбросить уже напечатанный документ.");
        }
    }
}
