using ComponentBasedGame.Helper;
using ComponentBasedGame.Model.GameObjects;
using Raylib_cs;
using System.Numerics;

namespace ComponentBasedGame.Model.Components
{
    internal class SpawnerComponent : BaseComponent
    {
        private float _spawnTimeSpan;
        private float _elapsedTime;

        private bool _canSpawn = false;
        public SpawnerComponent(GameObject owner, float spawnTimeSpan) : base(owner)
        {
            _spawnTimeSpan = spawnTimeSpan;
        }

        public override void Init()
        {

        }

        public override void Update(float frameTime)
        {
           if (_canSpawn == false)
            {
                _elapsedTime += frameTime;
                if (_elapsedTime >= _spawnTimeSpan)
                {
                    _canSpawn = true;
                    _elapsedTime = 0;
                }
            }

           if (_canSpawn)
            {

                var player = Game.Instance.GetFirstObjectFromType(GameObjectType.Player);
                var destination = new Vector2(Owner.Position.X, Owner.Position.Y);
                if (player is not  null)
                {
                    destination = PositionHelper.CalculateDirection(player.Position,Owner.Position);
                }

                var img = Raylib.LoadImage("Resources/Texture/PlayerSheet.png");
                img = Raylib.ImageFromImage(img, new Rectangle(0, 0, 32, 32));
                Game.Instance.AddObject(new CloseCombatEnemy(Owner.Position, 100,3,destination,Raylib.LoadTextureFromImage(img)));
                Raylib.UnloadImage(img);
                _canSpawn = false;
            }
        }
    }
}
