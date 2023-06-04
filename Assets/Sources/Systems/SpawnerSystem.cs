using Entitas;
using UnityEngine;
public class SpawnerSystem : IExecuteSystem
{
    private Contexts _contexts;
    private float timer = 0f;
    public SpawnerSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        SpawnEnemies();
    }
    private void SpawnEnemies()
    {
        timer += Time.deltaTime;
        if (timer > _contexts.game.gameSetup.value.enemySpawnTime)
        {
            var entity = _contexts.game.CreateEntity();
            entity.AddResource(_contexts.game.gameSetup.value.pool.EnemyPrefab);
            entity.isMove = true;
            entity.isEnemy = true;
            entity.AddHealth(100);
            timer = 0f;
        }
    }
}