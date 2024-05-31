using ComponentBasedGame.Model.GameObjects;

namespace ComponentBasedGame.Model.Components
{
    internal interface IComponent
    {
        GameObject Owner { get; }
        Task Update(float frameTime);
    }
}