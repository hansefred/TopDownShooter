using System.Numerics;

namespace ComponentBasedGame.Helper
{
    static internal class PositionHelper
    {

        public static float CalculateRotation (Vector2 destination, Vector2 position)
        {
            return Convert.ToSingle(Math.Atan2(destination.Y - position.Y,destination.X- position.X)) * (180 / (float) Math.PI);
        }

        public static Vector2 CalculateDirection(Vector2 destination, Vector2 position)
        {
            float deltaX = destination.X - position.X;
            float deltaY = destination.Y - position.Y;

            var direction = new Vector2(deltaX, deltaY);
            direction = Vector2.Normalize(direction);
            return direction;
        }
    }
}
