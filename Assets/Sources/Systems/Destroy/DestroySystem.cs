using Entitas;
using System.Collections.Generic;
using Entitas.Unity;
public class DestroySystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    public DestroySystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Destroy);
    }
    protected override bool Filter(GameEntity entity)
    {
        return entity.isDestroy;
    }
    protected override void Execute(List<GameEntity> entities)
    {
        foreach(var entity in entities)
        {
            if (entity.hasView && entity.isPlayer)
            {
                
                var gameObject = entity.view.value;
                gameObject.Unlink();
                _contexts.game.gameSetup.value.pool._playerPool.Release(gameObject);

            }
            if (entity.hasView && entity.isBullet)
            {
                var gameObject = entity.view.value;
                gameObject.Unlink();
                _contexts.game.gameSetup.value.pool._bulletPool.Release(gameObject);
            }
            if (entity.hasView && entity.isEnemy)
            {
                var gameObject = entity.view.value;
                gameObject.Unlink();
                _contexts.game.gameSetup.value.pool._enemyPool.Release(gameObject);
                _contexts.game.ReplaceScore(_contexts.game.score.value + 20);
            }
            entity.Destroy();
        }
    }



    
}