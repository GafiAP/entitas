using Entitas;
using System.Collections.Generic;
using Entitas.Unity;
using UnityEngine;
public class CollisionSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    public CollisionSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Collision);
    }
    protected override bool Filter(GameEntity entity)
    {
        return entity.hasCollision;
    }
    protected override void Execute(List<GameEntity> entities)
    {
        foreach(var entity in entities)
        {
            var firstObject = entity.collision.firstObject;
            var secondObject = entity.collision.secondObject;

            var firstObjectEntity = _contexts.game.GetEntitiesWithView(firstObject).SingleEntity();
            var secondObjectEntity = _contexts.game.GetEntitiesWithView(secondObject).SingleEntity();

            if (firstObjectEntity.hasHealth)
            {
                firstObjectEntity.health.health -= 50;
                if(firstObjectEntity.health.health <= 0)
                {
                    firstObjectEntity.isDestroy = true;
                }
            }
            secondObjectEntity.isDestroy = true;
            
        }
    }

    

   
}