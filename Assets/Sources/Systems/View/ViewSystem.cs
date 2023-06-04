using Entitas;
using System.Collections.Generic;
using UnityEngine;
using Entitas.Unity;
public class ViewSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    public ViewSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Resource);
    }
    protected override bool Filter(GameEntity entity)
    {
        return entity.hasResource;
    }
    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            if (entity.resource.value == _contexts.game.gameSetup.value.pool.bulletPrefab)
            {
                var gameObject = _contexts.game.gameSetup.value.pool._bulletPool.Get();
                entity.AddView(gameObject);
                gameObject.Link(entity);
                
            }
            if (entity.resource.value == _contexts.game.gameSetup.value.pool.playerPrefab)
            {
                var gameObject = _contexts.game.gameSetup.value.pool._playerPool.Get();
                entity.AddView(gameObject);
                gameObject.Link(entity);
            }
            if (entity.resource.value == _contexts.game.gameSetup.value.pool.EnemyPrefab)
            {
                
                var gameObject = _contexts.game.gameSetup.value.pool._enemyPool.Get();
                entity.AddView(gameObject);
                gameObject.Link(entity);
                entity.view.value.transform.position = _contexts.game.gameSetup.value.pool.EnemyPrefab.transform.position;
            }

        }
    }




}