using ComponentBasedGame.Model.Components;
using Raylib_cs;
using System.Numerics;

namespace ComponentBasedGame.Model.GameObjects
{
    internal class Player : GameObject
    {

        public Player()
        {
            Position = new Vector2 (500, 500);
            Rotation = 0;
            Scale = 3;
            Type = GameObjectType.Player;

            var img = Raylib.LoadImage("Resources/Texture/PlayerSheet.png");
            img = Raylib.ImageFromImage(img, new Rectangle(0, 0, 32, 32));
            AddComponent(new DrawComponent(this, Raylib.LoadTextureFromImage(img), new Color(255, 255, 255, 255)));
            AddComponent(new ControlComponent(this, 100, 1));
            AddComponent(new ColliderComponent(this, [GameObjectType.Enemy],new Rectangle(0,0, 32, 32)));
            AddComponent(new DestroyableComponent(this, 1));
            Raylib.UnloadImage(img);

        }

    }
}
