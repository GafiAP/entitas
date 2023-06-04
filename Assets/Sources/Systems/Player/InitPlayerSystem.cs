using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
public class InitPlayerSystem : IInitializeSystem
{
    private Contexts _contexts;

    public InitPlayerSystem(Contexts contexts)
    {
        _contexts = contexts;
    }
    public void Initialize()
    {
        var entity = _contexts.game.CreateEntity();
        entity.AddResource(_contexts.game.gameSetup.value.pool.playerPrefab);
        entity.isMove = true;
        entity.isPlayer = true;
        entity.isShoot = true;
    }
}
