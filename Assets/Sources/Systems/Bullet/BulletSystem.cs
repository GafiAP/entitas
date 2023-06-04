using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class BulletSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    public BulletSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }
    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Bullet);
    }
    protected override bool Filter(GameEntity entity)
    {
        return entity.isBullet;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            var playerEntity = _contexts.game.GetGroup(GameMatcher.Player).GetSingleEntity();
            entity.isMove = true;
            entity.view.value.transform.position = playerEntity.view.value.transform.position;
        }
    }

}