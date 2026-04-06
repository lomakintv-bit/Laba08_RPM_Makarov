namespace Laba08_RPM_Makarov.Mediator
{
    public abstract class Colleague
    {
        public IMediator? Mediator { get; private set; }

        public void SetMediator(IMediator mediator)
        {
            Mediator = mediator;
        }
    }
}