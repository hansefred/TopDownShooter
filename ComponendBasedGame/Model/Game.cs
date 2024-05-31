using ComponentBasedGame.Model.GameObjects;
using libc.eventbus.System;
using Raylib_cs;
using System.Numerics;

namespace ComponentBasedGame.Model
{
    internal class Game
    {
        private static Game? _instance;
        private readonly List<GameObject> _gameObjects = new List<GameObject>();
        private EventBus _eventBus;
        private static readonly object _lock = new object();

        public EventBus EventBus    {get => _eventBus; }



        // Private constructor to prevent instantiation
        private Game()
        {
            _eventBus = new DefaultEventBus();
        }

        public static Game Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Game();
                    }
                    return _instance;
                }
            }
        }


        internal void AddObject (GameObject gameObject)
        {
            _gameObjects.Add(gameObject);
        }


        internal IEnumerable<GameObject> GetObjectFromType(GameObjectType type)
        {
            return _gameObjects.Where(x => x.Type == type);
        }

        internal GameObject? GetFirstObjectFromType (GameObjectType type)
        {
            return _gameObjects.FirstOrDefault(x => x.Type == type);
        }


        public void Init()
        {
            Raylib.InitWindow(1280, 720, "Hello, Raylib-CsLo");
            Raylib.SetTargetFPS(60);
            Instance.AddObject(new Player());
            Instance.AddObject(new EnemySpawner(new Vector2(100, 100), 10));
        }

        public async Task Update(float frameTime)
        {
            for(int i = 0; i < _gameObjects.Count; i++)
            {
                for(int j = 0; j < _gameObjects[i].Components.Count; j++)
                {
                   await _gameObjects[i].Components[j].Update(frameTime);
                }
            }
        }

    }
}
