using Entitas;
using UnityEngine;
public class PlayerReplacePositionSystem : IExecuteSystem
{
    private Contexts _contexts;
    private IGroup<GameEntity> _group;
    public PlayerReplacePositionSystem(Contexts contexts)
    {
        _contexts = contexts;
        _group = _contexts.game.GetGroup(GameMatcher.Player);
    }

    public void Execute()
    {
        foreach(var entity in _group)
        {
            var input = _contexts.input.input.value;
            var moveSpeed = _contexts.game.gameSetup.value.playerMoveSpeed;
            entity.ReplacePosition(input * moveSpeed);
        }
    }
}