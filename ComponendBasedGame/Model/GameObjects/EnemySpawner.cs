using ComponentBasedGame.Model.Components;
using System.Numerics;

namespace ComponentBasedGame.Model.GameObjects
{
    internal class EnemySpawner : GameObject
    {
        public EnemySpawner(Vector2 position, float spawnTime)
        {
            Position = position;

            AddComponent(new SpawnerComponent(this, spawnTime));
            
        }
    }
}
