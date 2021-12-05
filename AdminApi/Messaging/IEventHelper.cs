using AdminApi.Entities;

namespace AdminApi.Messaging
{
    public interface IEventHelper
    {
        public void Raise(User user, UserEvent.State state);
    }
}