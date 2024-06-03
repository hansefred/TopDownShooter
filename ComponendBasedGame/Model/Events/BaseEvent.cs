using ComponentBasedGame.Model.GameObjects;
using libc.eventbus.Types;

namespace ComponentBasedGame.Model.Events
{
    internal class BaseEvent : IEvent
    {
        public GameObject Source { get; }
        public BaseEvent(GameObject source)
        {
            Source = source;
        }

    }

}
