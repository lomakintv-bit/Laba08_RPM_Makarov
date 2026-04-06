using Laba08_RPM_Makarov.State;

namespace Laba08_RPM_Makarov.Mediator
{
    public interface IMediator
    {
        void Notify(Colleague sender, string ev, Document? document = null);
    }
}