using ComponentBasedGame.Model.Commands;
using ComponentBasedGame.Model.Events;
using ComponentBasedGame.Model.GameObjects;
using libc.eventbus.Types;

namespace ComponentBasedGame.Model.Components
{
    internal class DestroyableComponent : BaseComponent, IEventHandler<CollideWithEvent>
    {
        private int _hitPoints;

        public DestroyableComponent(GameObject owner, int hitPoints) : base(owner)
        {
            _hitPoints = hitPoints;
            Game.Instance.EventBus.Subscribe<CollideWithEvent, DestroyableComponent>(this);
        }

        public Task Handle(CollideWithEvent ev)
        {
            if (ev.Source == Owner)
            {
                _hitPoints--;
            }

            return Task.CompletedTask;
        }

        public override Task Update(float frameTime)
        {
            if (_hitPoints == 0)
            {
                Game.Instance.EventBus.PublishAsync(new GameObjectDestoryedEvent(Owner));
            }

            return Task.CompletedTask;
        }
    }
}
