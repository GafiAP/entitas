using Entitas;
using UnityEngine;

public class InitEnemySystem : IInitializeSystem
{
    private Contexts _context;
    public InitEnemySystem(Contexts context)
    {
        _context = context;
    }

    public void Initialize()
    {
        var e = _context.game.CreateEntity();
        e.AddResource(_context.game.gameSetup.value.pool.EnemyPrefab);
        e.isMove = true;
        e.isEnemy = true;
        e.AddHealth(100);
    }
}