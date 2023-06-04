using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GameFeature : Feature
{
    public GameFeature(Contexts contexts)
    {
        //Initialize
        Add(new InitPlayerSystem(contexts));
        Add(new InitEnemySystem(contexts));
        Add(new InitScoreSystem(contexts));

        //Initialize & Execute
        Add(new InputSystem(contexts));

        //Execute
        Add(new PlayerReplacePositionSystem(contexts));
        Add(new EnemyReplacePositionSystem(contexts));
        Add(new BulletReplacePositionSystem(contexts));
        Add(new MoveSystem(contexts));
        Add(new SpawnerSystem(contexts));

        //Event
        Add(new GameEventSystems(contexts));
        //Reactive
        Add(new ViewSystem(contexts));
        Add(new BulletSystem(contexts));
        Add(new DestroySystem(contexts));
        Add(new CollisionSystem(contexts));
    }
}
