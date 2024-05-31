using System.Numerics;
using ComponentBasedGame.Model.Components;
using Raylib_cs;

namespace ComponentBasedGame.Model.GameObjects
{
    internal class GameObject : IEquatable<GameObject>
    {
        List<IComponent> _components;
        public Guid ID { get; private set; } = Guid.NewGuid();
        public GameObjectType Type { get; set; }
        public List<IComponent> Components { get => _components; }
        public Vector2 Position { get; set; }
        public float Rotation { get; set; }
        public float Scale { get; set; }


        public GameObject()
        {
            Type = GameObjectType.None;
            Position = new();
            _components = new();

        }

        public GameObject(Vector2 position)
        {
            Position = position;
            _components = new();

        }

        public GameObject(Vector2 position, float rotation, float scale) : this(position)
        {
            Rotation = rotation;
            Scale = scale;

        }

        internal void AddComponent(IComponent drawComponent)
        {
            _components.Add(drawComponent);
        }

        public bool Equals(GameObject? other)
        {
            if (other is null)
                return false;

            if (other is GameObject otherObject)
            {
                if (otherObject.ID == ID)
                {
                    return true;
                }
            }

            return false;

        }
    }

    internal enum GameObjectType
    {
        None,
        Player,
        Enemy,
        PlayerBullet,
        EnemyBullet,
        Wall
    }
}
