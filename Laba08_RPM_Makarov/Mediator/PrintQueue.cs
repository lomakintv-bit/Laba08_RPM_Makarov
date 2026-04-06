using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba08_RPM_Makarov.Mediator
{
    public class PrintQueue : Colleague
    {
        private readonly Queue<Document> _queue = new();

        public bool IsEmpty => _queue.Count == 0;
        public int Count => _queue.Count;

        public void EnqueueItem(Document document)
        {
            _queue.Enqueue(document);
            Mediator?.Notify(this, "Enqueued", document);
        }

        public Document? DequeueItem()
        {
            if (_queue.Count == 0) return null;
            return _queue.Dequeue();
        }

        public void Clear()
        {
            _queue.Clear();
        }
    }
}
