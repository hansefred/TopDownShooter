using ComponentBasedGame.Helper;
using ComponentBasedGame.Model.GameObjects;

namespace ComponentBasedGame.Model.Components
{
    internal class FollowGameObjectComponent : BaseComponent
    {
        private readonly MovingComponent _movingComponent;
        private readonly GameObject _target;

        public FollowGameObjectComponent(GameObject Owner, MovingComponent movingComponent, GameObject target): base(Owner)
        {
            _movingComponent = movingComponent;
            _target = target;
        }

        public override Task Update(float frameTime)
        {
           var direction = PositionHelper.CalculateDirection(_target.Position,Owner.Position);
           _movingComponent.SetDirection(direction);

            Owner.Rotation = PositionHelper.CalculateRotation(_target.Position, Owner.Position);

            return Task.CompletedTask;
        }

    }
}
