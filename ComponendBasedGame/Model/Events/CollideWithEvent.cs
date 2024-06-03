using ComponentBasedGame.Model.Events;
using ComponentBasedGame.Model.GameObjects;

namespace ComponentBasedGame.Model.Commands
{
    internal class CollideWithEvent: BaseEvent 
    {
        public GameObject Foreign { get;}

        public CollideWithEvent(GameObject source, GameObject foreign) : base(source) 
        {
            Foreign = foreign;
        }
    }
}
