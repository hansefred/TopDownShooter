using ComponentBasedGame.Helper;
using ComponentBasedGame.Model.Components;
using Raylib_cs;
using System.Numerics;

namespace ComponentBasedGame.Model.GameObjects
{
    internal class CloseCombatEnemy : GameObject
    {

        public CloseCombatEnemy(Vector2 position, float speed, float scale, Vector2 destionation, Texture2D texture):base(position,0,scale)
        {
            Type = GameObjectType.Enemy;

            AddComponent(new DrawComponent(this, texture, new Color(255, 255, 255, 255)));
            AddComponent(new MovingComponent(this, speed, destionation));
        }
    }
}
