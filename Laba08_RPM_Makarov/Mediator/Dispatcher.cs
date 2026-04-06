using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba08_RPM_Makarov.Mediator
{
    public class Dispatcher : Colleague
    {
        public void CommandProcessQueue()
        {
            Console.WriteLine("\n[Диспетчер] Отправлена команда на обработку очереди печати.");
            Mediator?.Notify(this, "ProcessQueue");
        }

        public void CommandAddDocument(Document document)
        {
            Console.WriteLine($"[Диспетчер] Отправлена команда на добавление документа '{document.Title}' в очередь.");
            document.AddToQueue();
        }

        public void CommandResetDocument(Document document)
        {
            Console.WriteLine($"[Диспетчер] Отправлена команда на сброс документа '{document.Title}'.");
            document.Reset();
        }
    }
}
