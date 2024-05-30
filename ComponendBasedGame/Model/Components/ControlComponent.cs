using ComponentBasedGame.Model.GameObjects;
using Raylib_cs;

namespace ComponentBasedGame.Model.Components
{
    internal class ControlComponent : BaseComponent
    {
        private float _moveSpeed;
        private float _shootSpeed;
        private float _elapsedTimeSinceShoot = 0;

        private bool _canShoot = true;


        public ControlComponent(GameObject owner, float moveSpeed, float shootSpeed) : base(owner)
        {
            _moveSpeed = moveSpeed;
            _shootSpeed = shootSpeed;
        }


        public override void Init()
        {

        }

        public override void Update(float frameTime)
        {

            var NewPosition = Owner.Position;
            if (Raylib.IsKeyDown(KeyboardKey.W))
            {
                NewPosition.Y = Owner.Position.Y - _moveSpeed * frameTime;
            }
            if (Raylib.IsKeyDown(KeyboardKey.S))
            {
                NewPosition.Y = Owner.Position.Y + _moveSpeed * frameTime;
            }
            if (Raylib.IsKeyDown(KeyboardKey.A))
            {
                NewPosition.X = Owner.Position.X - _moveSpeed * frameTime;
            }
            if (Raylib.IsKeyDown(KeyboardKey.D))
            {
                NewPosition.X = Owner.Position.X + _moveSpeed * frameTime;
            }
            Owner.Position = NewPosition;


            var mousePosition = Raylib.GetMousePosition();
            Owner.Rotation = Convert.ToSingle(Math.Atan2(mousePosition.Y - Owner.Position.Y, mousePosition.X - Owner.Position.X)) * (180 / (float)Math.PI);


            if (_canShoot == false)
            {
                _elapsedTimeSinceShoot += frameTime;
                if (_elapsedTimeSinceShoot >= _shootSpeed)
                {
                    _canShoot = true;
                    _elapsedTimeSinceShoot = 0;
                }
            }

            if (Raylib.IsMouseButtonDown(MouseButton.Left) && _canShoot)
            {
                var img = Raylib.LoadImage("Resources/Texture/PlayerSheet.png");
                img = Raylib.ImageFromImage(img, new Rectangle(0, 0, 32, 32));
                Raylib.UnloadImage(img);

                Game.Instance.AddObject(new Shot(GameObjectType.PlayerBullet,
                                Raylib.GetMousePosition(),
                                Owner.Position,
                                100, 3, Raylib.LoadTextureFromImage(img)));

                _canShoot = false;
            }
        }
    }
}
