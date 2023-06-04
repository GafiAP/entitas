using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameSetup gameSetup;
    private GameFeature gameFeature;
    // Start is called before the first frame update
    void Start()
    {
        var contexts = Contexts.sharedInstance;
        contexts.game.SetGameSetup(gameSetup);
        contexts.game.gameSetup.value.pool.BulletPool();
        contexts.game.gameSetup.value.pool.PlayerPool();
        contexts.game.gameSetup.value.pool.EnemyPool();
        gameFeature = new GameFeature(contexts);
        gameFeature.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        gameFeature.Execute();
    }
}
