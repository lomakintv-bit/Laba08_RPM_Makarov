using Laba08_RPM_Makarov.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba08_RPM_Makarov.Mediator
{
    public class PrintSystemMediator : IMediator
    {
        private readonly Printer _printer;
        private readonly PrintQueue _queue;
        private readonly Logger _logger;

        public PrintSystemMediator(Printer printer, PrintQueue queue, Logger logger)
        {
            _printer = printer;
            _queue = queue;
            _logger = logger;

            // Подписываем коллег на посредника
            _printer.SetMediator(this);
            _queue.SetMediator(this);
            _logger.SetMediator(this);
        }

        public void Notify(Colleague sender, string ev, Document? document = null)
        {
            switch (ev)
            {
                // Событие от документа: "Добавить в очередь"
                case "AddToQueue" when document != null:
                    _queue.EnqueueItem(document);
                    break;

                // Событие от очереди: "Документ добавлен"
                case "Enqueued" when document != null:
                    _logger.WriteMessage($"Документ '{document.Title}' помещён в очередь. (Состояние: {document.GetStateName()})");
                    break;

                // Событие от документа: "Запрос на печать"
                case "RequestPrint" when document != null:
                    _logger.WriteMessage($"Получен запрос на печать документа '{document.Title}'.");
                    document.SetState(new PrintingState());
                    _logger.WriteMessage($"Документ '{document.Title}' переведён в состояние Printing.");
                    _printer.StartPrint(document);
                    break;

                // Событие от диспетчера: "Обработать очередь"
                case "ProcessQueue":
                    if (_queue.IsEmpty)
                    {
                        _logger.WriteMessage("Очередь пуста. Нет документов для печати.");
                        return;
                    }

                    var nextDoc = _queue.DequeueItem();
                    if (nextDoc != null)
                    {
                        _logger.WriteMessage($"Извлечён документ '{nextDoc.Title}' из очереди для печати.");
                        nextDoc.SetMediator(this);  // Убеждаемся, что документ знает посредника
                        nextDoc.Print();             // Запускаем цепочку State -> Mediator
                    }
                    break;

                // Событие от принтера: "Успешная печать"
                case "PrintSuccess" when document != null:
                    _logger.WriteSuccess($"Документ '{document.Title}' успешно напечатан.");
                    document.CompletePrint();
                    _logger.WriteMessage($"Документ '{document.Title}' переведён в состояние {document.GetStateName()}.");
                    break;

                // Событие от принтера: "Ошибка печати"
                case "PrintFailed" when document != null:
                    _logger.WriteError($"Ошибка при печати документа '{document.Title}'.");
                    document.FailPrint();
                    _logger.WriteMessage($"Документ '{document.Title}' переведён в состояние {document.GetStateName()}.");
                    break;

                default:
                    _logger.WriteError($"Получено неизвестное событие: {ev}");
                    break;
            }
        }
    }
}
