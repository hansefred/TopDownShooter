using ComponentBasedGame.Helper;
using ComponentBasedGame.Model.GameObjects;
using System.Numerics;

namespace ComponentBasedGame.Model.Components
{
    internal class MovingComponent : BaseComponent
    {
        private float _speed;
        private Vector2 _direction;

        public MovingComponent(GameObject owner, float speed, Vector2 direction) : base(owner)
        {
            _speed = speed;
            _direction = direction;
            ComponentPriority = ComponentPriority.High;
        }

        public override Task Update(float frameTime)
        {
            var newPosition = Owner.Position;
            newPosition.X = newPosition.X + ((_speed * frameTime) * _direction.X);
            newPosition.Y = newPosition.Y + ((_speed * frameTime) * _direction.Y);

            Owner.Position = newPosition;

            return Task.CompletedTask;
        }

        public void SetDirection(Vector2 direction)
        {
            _direction = direction;
        }
    }
}
