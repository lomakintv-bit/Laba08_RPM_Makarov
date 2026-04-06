using System;
using Laba08_RPM_Makarov.State;

namespace Laba08_RPM_Makarov.Mediator
{
    public class Document : Colleague
    {
        public string Title { get; }
        public IDocumentState State { get; private set; }

        public Document(string title)
        {
            Title = title;
            State = new NewState();
        }

        public void SetState(IDocumentState state) => State = state;

        public string GetStateName()
        {
            return State switch
            {
                NewState => "New",
                PrintingState => "Printing",
                DoneState => "Done",
                ErrorState => "Error",
                _ => "Unknown"
            };
        }

        public void Print() => State.Print(this);
        public void AddToQueue() => State.AddToQueue(this);
        public void CompletePrint() => State.CompletePrinting(this);
        public void FailPrint() => State.FailPrinting(this);
        public void Reset() => State.Reset(this);
    }
}