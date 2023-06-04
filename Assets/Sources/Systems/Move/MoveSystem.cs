using Entitas;
using UnityEngine;

public class MoveSystem : IExecuteSystem
{
    private Contexts _contexts;
    private IGroup<GameEntity> _group;
    public MoveSystem(Contexts contexts)
    {
        _contexts = contexts;
        _group = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Move,GameMatcher.View, GameMatcher.Position));
    }

    public void Execute()
    {
        if (_group != null)
        {
            foreach (var entity in _group)
            {
                var gameObject = entity.view.value;
                var position = entity.position.value;
                gameObject.transform.position += position * Time.deltaTime;

            }
        }
    }
}