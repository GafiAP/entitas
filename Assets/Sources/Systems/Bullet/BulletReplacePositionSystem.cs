using Entitas;
using UnityEngine;
public class BulletReplacePositionSystem : IExecuteSystem
{
    private Contexts _context;
    private IGroup<GameEntity> _group;
    public BulletReplacePositionSystem(Contexts context)
    {
        _context = context;
        _group = _context.game.GetGroup(GameMatcher.AllOf( GameMatcher.Bullet,GameMatcher.Move));
    }

    public void Execute()
    {
        foreach(var e in _group)
        {
            e.ReplacePosition(Vector3.forward * _context.game.gameSetup.value.bulletSpeed);
            if(e.view.value.transform.position.z >= 20f)
            {
                e.isDestroy = true;
            }
        }
    }
}