using Entitas;
using UnityEngine;
public class EnemyReplacePositionSystem : IExecuteSystem
{
    private Contexts _context;
    private IGroup<GameEntity> _group;
    public EnemyReplacePositionSystem(Contexts context)
    {
        _context = context;
        _group = context.game.GetGroup(GameMatcher.AllOf(GameMatcher.Enemy, GameMatcher.Move));
    }

    public void Execute()
    {
        var enemyMoveSpeed = _context.game.gameSetup.value.enemyMoveSpeed;
        foreach(var entity in _group)
        {
            entity.ReplacePosition(-Vector3.forward * enemyMoveSpeed);
        }
    }
}
