using libc.eventbus.Types;

namespace ComponentBasedGame.Model.Events
{
    record GameObjectDestoryedEvent (Guid ID) : IEvent
    {
    }
}
