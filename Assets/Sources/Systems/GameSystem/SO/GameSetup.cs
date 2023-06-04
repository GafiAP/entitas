using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas.CodeGeneration.Attributes;
[CreateAssetMenu]
[Game,Unique]
public class GameSetup : ScriptableObject
{

    public ObjectPool pool;
    public float playerMoveSpeed = 5f;
    public float enemyMoveSpeed = 10f;
    public float bulletSpeed = 20f;
    public float enemySpawnTime = 5f;
}
