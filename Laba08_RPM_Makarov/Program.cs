using Laba08_RPM_Makarov.Mediator;

namespace Laba08_RPM_Makarov
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Система управления печатью";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=".PadRight(70, '='));
            Console.WriteLine("ЛАБОРАТОРНАЯ РАБОТА №8");
            Console.WriteLine("Паттерны: State (Состояние) + Mediator (Посредник)");
            Console.WriteLine("Система управления очередью печати документов");
            Console.WriteLine("=".PadRight(70, '='));
            Console.ResetColor();
            Console.WriteLine();

            // ===== ИНИЦИАЛИЗАЦИЯ КОМПОНЕНТОВ =====

            // Создаём коллег
            var printer = new Printer();
            var queue = new PrintQueue();
            var logger = new Logger();

            // Создаём посредника и связываем всех коллег
            var mediator = new PrintSystemMediator(printer, queue, logger);

            // Создаём диспетчера и связываем с посредником
            var dispatcher = new Dispatcher();
            dispatcher.SetMediator(mediator);

            // ===== ДЕМОНСТРАЦИЯ РАБОТЫ =====

            // Сценарий 1: Успешная печать нескольких документов
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n>>> СЦЕНАРИЙ 1: Успешная печать нескольких документов <<<");
            Console.ResetColor();

            var doc1 = new Document("Отчёт по проекту.pdf");
            var doc2 = new Document("Договор_2024.docx");
            var doc3 = new Document("Презентация.pptx");

            dispatcher.CommandAddDocument(doc1);
            dispatcher.CommandAddDocument(doc2);
            dispatcher.CommandAddDocument(doc3);

            Console.WriteLine($"\n[Статус очереди] Документов в очереди: {queue.Count}");

            // Запускаем печать всех документов
            dispatcher.CommandProcessQueue();
            dispatcher.CommandProcessQueue();
            dispatcher.CommandProcessQueue();

            // ===== СЦЕНАРИЙ 2: Ошибка принтера и восстановление =====
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\n>>> СЦЕНАРИЙ 2: Ошибка принтера и восстановление <<<");
            Console.ResetColor();

            var docError = new Document("Важный_документ_с_ошибкой.pdf");

            // Включаем симуляцию ошибки на принтере
            printer.SimulateFailure = true;
            Console.WriteLine("[Настройка] Принтер настроен на симуляцию ошибки.");

            dispatcher.CommandAddDocument(docError);
            dispatcher.CommandProcessQueue();  // Попытка печати - должна вызвать ошибку

            // Документ теперь в состоянии Error, сбрасываем его
            Console.WriteLine($"\n[Состояние документа] {docError.GetStateName()}");
            dispatcher.CommandResetDocument(docError);

            // Выключаем симуляцию ошибки и печатаем заново
            printer.SimulateFailure = false;
            Console.WriteLine("[Настройка] Принтер восстановлен, ошибка отключена.");

            dispatcher.CommandAddDocument(docError);
            dispatcher.CommandProcessQueue();  // Повторная печать - должна быть успешной

            // ===== СЦЕНАРИЙ 3: Проверка финального состояния =====
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\n>>> СЦЕНАРИЙ 3: Проверка финального состояния <<<");
            Console.ResetColor();

            var docFinal = new Document("Финальный_документ.pdf");
            dispatcher.CommandAddDocument(docFinal);
            dispatcher.CommandProcessQueue();

            // Попытка выполнить недопустимые операции над напечатанным документом
            Console.WriteLine($"\n[Проверка ограничений] Документ в состоянии: {docFinal.GetStateName()}");
            docFinal.AddToQueue();     // Должно быть запрещено
            docFinal.Print();          // Должно быть запрещено
            docFinal.Reset();          // Должно быть запрещено

            // ===== ИТОГОВАЯ ИНФОРМАЦИЯ =====
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n" + "=".PadRight(70, '='));
            Console.WriteLine("ДЕМОНСТРАЦИЯ ЗАВЕРШЕНА");
            Console.WriteLine("=".PadRight(70, '='));
            Console.ResetColor();

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
