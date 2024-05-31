using libc.eventbus.Types;

namespace ComponentBasedGame.Model.Commands
{
    internal record CollideWithEvent(Guid self, Guid foreign) : IEvent;
}
