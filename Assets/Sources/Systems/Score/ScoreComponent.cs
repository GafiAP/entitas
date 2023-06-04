using Entitas;
using Entitas.CodeGeneration.Attributes;
[Game, Unique,Event(EventTarget.Any)]
public class ScoreComponent : IComponent
{
    public int value;
}