using ComponentBasedGame.Model.GameObjects;

namespace ComponentBasedGame.Model.Components
{
    internal interface IComponent
    {
        public ComponentPriority ComponentPriority { get;}
        GameObject Owner { get; }
        Task Update(float frameTime);
    }

    internal enum ComponentPriority
    {
        Low, Medium, High
    }
}