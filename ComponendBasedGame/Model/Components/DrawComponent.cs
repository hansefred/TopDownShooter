using ComponentBasedGame.Model.GameObjects;
using Raylib_cs;
using System.Numerics;


namespace ComponentBasedGame.Model.Components
{
    internal class DrawComponent : BaseComponent
    {
        Texture2D _texture;
        Color _transperencyValue;

        public DrawComponent(GameObject owner, Texture2D texture, Color transperencyValue) : base(owner)
        {
            _texture = texture;
            _transperencyValue = transperencyValue;
        }

        public override Task Update(float frameTime)
        {
            var position = Owner.Position;
            position.X += _texture.Width / 2;
            position.Y += _texture.Height / 2;

            Raylib.DrawTexturePro(_texture,
                new Rectangle(0, 0, new Vector2(_texture.Width, _texture.Height)),
                new Rectangle(Owner.Position.X, Owner.Position.Y, new Vector2(_texture.Width * Owner.Scale, _texture.Height * Owner.Scale)),
                new Vector2(_texture.Width / 2, _texture.Height / 2) * Owner.Scale,
                Owner.Rotation,
                _transperencyValue);


            return Task.CompletedTask;

        }
    }
}
