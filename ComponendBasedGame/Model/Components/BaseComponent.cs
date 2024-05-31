using ComponentBasedGame.Model.GameObjects;


namespace ComponentBasedGame.Model.Components
{
    abstract internal class BaseComponent : IComponent
    {
        private readonly GameObject _owner;

        protected BaseComponent(GameObject owner)
        {
            _owner = owner;
        }

        public GameObject Owner { get => _owner; }
        public abstract Task Update(float frameTime);


    }
}
