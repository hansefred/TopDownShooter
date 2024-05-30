using ComponentBasedGame.Model.GameObjects;

namespace ComponentBasedGame.Model.Components
{
    internal interface IComponent
    {
        GameObject Owner { get; }
        void Init();
        void Update(float frameTime);
    }
}