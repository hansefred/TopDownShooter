using ComponentBasedGame.Helper;
using ComponentBasedGame.Model.Components;
using Raylib_cs;
using System.Numerics;

namespace ComponentBasedGame.Model.GameObjects
{
    internal class Shot : GameObject
    {
        public Shot(GameObjectType type, Vector2 destination, Vector2 position, float speed, float scale, Texture2D texture)
        {
            Type = type;
            Position = position;
            Scale = scale;

            Vector2 direction = PositionHelper.CalculateDirection(destination, position);

            AddComponent(new DrawComponent(this, texture, new Color(255, 255, 255, 255)));
            AddComponent(new MovingComponent(this, speed, direction));
        }


    }
}
