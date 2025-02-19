﻿using ComponentBasedGame.Model.Events;
using ComponentBasedGame.Model.GameObjects;
using libc.eventbus.System;
using libc.eventbus.Types;
using Raylib_cs;
using System.Numerics;

namespace ComponentBasedGame.Model
{
    internal class Game : IEventHandler<GameObjectDestoryedEvent>
    {
        private static Game? _instance;
        private readonly List<GameObject> _gameObjects = new List<GameObject>();
        private EventBus _eventBus;
        private static readonly object _lock = new object();
        private List<GameObject> _markedForCleanup;

        public EventBus EventBus { get => _eventBus; }



        // Private constructor to prevent instantiation
        private Game()
        {
            _eventBus = new DefaultEventBus();
            _markedForCleanup = new();

            _eventBus.Subscribe<GameObjectDestoryedEvent, Game>(this);
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


        internal void AddObject(GameObject gameObject)
        {
            _gameObjects.Add(gameObject);
        }


        internal IEnumerable<GameObject> GetObjectFromType(GameObjectType type)
        {
            return _gameObjects.Where(x => x.Type == type);
        }

        internal GameObject? GetFirstObjectFromType(GameObjectType type)
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
            for (int i = 0; i < _gameObjects.Count; i++)
            {
                for (int j = 0; j < _gameObjects[i].Components.Count; j++)
                {
                    if (_gameObjects[i].Components[j].ComponentPriority == Components.ComponentPriority.High)
                    {
                        await _gameObjects[i].Components[j].Update(frameTime);
                    }
                }
            }

            for (int i = 0; i < _gameObjects.Count; i++)
            {
                for (int j = 0; j < _gameObjects[i].Components.Count; j++)
                {
                    if (_gameObjects[i].Components[j].ComponentPriority == Components.ComponentPriority.Medium)
                    {
                        await _gameObjects[i].Components[j].Update(frameTime);
                    }
                }
            }
            for (int i = 0; i < _gameObjects.Count; i++)
            {
                for (int j = 0; j < _gameObjects[i].Components.Count; j++)
                {
                    if (_gameObjects[i].Components[j].ComponentPriority == Components.ComponentPriority.Low)
                    {
                        await _gameObjects[i].Components[j].Update(frameTime);
                    }
                }
            }
        }

        public void Cleanup()
        {
            foreach (var destroyedEvent in _markedForCleanup)
            {
                _gameObjects.Remove(destroyedEvent);
            }
            _markedForCleanup.Clear();
        }

        public Task Handle(GameObjectDestoryedEvent ev)
        {
            _markedForCleanup.Add(_gameObjects.First(o => o == ev.Source));
            return Task.CompletedTask;
        }
    }
}
