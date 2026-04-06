using Laba08_RPM_Makarov.Mediator;

namespace Laba08_RPM_Makarov.State
{
    public interface IDocumentState
    {
        void Print(Document document);
        void AddToQueue(Document document);
        void CompletePrinting(Document document);
        void FailPrinting(Document document);
        void Reset(Document document);
    }
}