using ComponentBasedGame.Model.GameObjects;


namespace ComponentBasedGame.Model.Components
{
    abstract internal class BaseComponent : IComponent
    {
        private readonly GameObject _owner;

        protected BaseComponent(GameObject owner)
        {
            _owner = owner;
            ComponentPriority = ComponentPriority.Low;
        }

        public GameObject Owner { get => _owner; }
        public ComponentPriority ComponentPriority { get; protected set; }

        public abstract Task Update(float frameTime);


    }
}
