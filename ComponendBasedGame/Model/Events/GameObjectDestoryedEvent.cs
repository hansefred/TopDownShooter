using ComponentBasedGame.Model.GameObjects;

namespace ComponentBasedGame.Model.Events
{
    internal class GameObjectDestoryedEvent(GameObject source) : BaseEvent (source)
    {

    }
}
