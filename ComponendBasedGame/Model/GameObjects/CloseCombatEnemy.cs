using ComponentBasedGame.Helper;
using ComponentBasedGame.Model.Components;
using Raylib_cs;
using System.Numerics;

namespace ComponentBasedGame.Model.GameObjects
{
    internal class CloseCombatEnemy : GameObject
    {

        public CloseCombatEnemy(Vector2 position, float speed, float scale, Vector2 destionation, Texture2D texture, GameObject? target):base(position,0,scale)
        {
            Type = GameObjectType.Enemy;

            AddComponent(new DrawComponent(this, texture, new Color(255, 255, 255, 255)));
            var movingComp = new MovingComponent(this, speed, destionation);
            AddComponent(movingComp);
            if (target is not null)
            {
                AddComponent(new FollowGameObjectComponent(this, movingComp, target));
            }

            AddComponent(new ColliderComponent(this, [GameObjectType.PlayerBullet],new Rectangle(0,0,32,32)));
            AddComponent(new DestroyableComponent(this, 1));
            
        }
    }
}
