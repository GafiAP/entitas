using Entitas;
public class InitScoreSystem : IInitializeSystem
{
    private Contexts _contexts;
    public InitScoreSystem(Contexts contexts)
    {
        _contexts = contexts;
    }
    public void Initialize()
    {
        var entity = _contexts.game.CreateEntity();
        entity.AddScore(0);
    }
}