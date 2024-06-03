using ComponentBasedGame.Model.Commands;
using ComponentBasedGame.Model.GameObjects;
using Raylib_cs;

namespace ComponentBasedGame.Model.Components
{
    internal class ColliderComponent : BaseComponent
    {
        private List<GameObjectType> _collideWith;
        private Rectangle _bounds;

        public Rectangle Bounds { get => _bounds; }
        public ColliderComponent(GameObject owner, List<GameObjectType> collideWith, Rectangle bounds) : base(owner)
        {
            _collideWith = collideWith;
            _bounds = bounds;
        }

        public override async Task Update(float frameTime)
        {
            _bounds.Position = Owner.Position;


            for (int i = 0; i < _collideWith.Count; i++)
            {
                var checkEntities = Game.Instance.GetObjectFromType(_collideWith[i]);
                for (int a = 0; a < checkEntities.Count(); a++)
                {
                    var collider = checkEntities.ElementAt(a).Components.FirstOrDefault(o => o.GetType() == typeof(ColliderComponent));
                    if (collider is not null && collider is ColliderComponent foreignComp)
                    {
                        //Need to check Position
                        var foreignBounds = foreignComp.Bounds;
                        foreignBounds.Position = checkEntities.ElementAt(a).Position;

                        if (Raylib.CheckCollisionRecs(_bounds,foreignBounds))
                        {
                            await Game.Instance.EventBus.PublishAsync(new CollideWithEvent(Owner, foreignComp.Owner)); 
                        }
                    }
                }
            }
        }
    }
}
