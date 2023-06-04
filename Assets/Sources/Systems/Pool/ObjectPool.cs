using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
public class ObjectPool : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject playerPrefab;
    public GameObject EnemyPrefab;
    public IObjectPool<GameObject> _bulletPool;
    public IObjectPool<GameObject> _playerPool;
    public IObjectPool<GameObject> _enemyPool;
    public void BulletPool()
    {
        _bulletPool = new ObjectPool<GameObject>(() =>
        {
            return Instantiate(bulletPrefab);
        }, bullet =>
        {
            bullet.gameObject.SetActive(true);
        }, bullet =>
        {
            bullet.gameObject.SetActive(false);
        }, bullet =>
        {
            Destroy(bullet.gameObject);
        }, false, 10, 20);
    }
    public void PlayerPool()
    {
        _playerPool = new ObjectPool<GameObject>(() =>
        {
            return Instantiate(playerPrefab);
        }, player =>
        {
            player.gameObject.SetActive(true);
        }, player =>
        {
            player.gameObject.SetActive(false);
        }, player =>
        {
            Destroy(player.gameObject);
        }, false, 10, 20);
    }
    public void EnemyPool()
    {
        _enemyPool = new ObjectPool<GameObject>(() =>
        {
            return Instantiate(EnemyPrefab);
        }, enemy =>
        {
            enemy.gameObject.SetActive(true);
        }, enemy =>
        {
            enemy.gameObject.SetActive(false);
        }, enemy =>
        {
            Destroy(enemy.gameObject);
        }, false, 10, 20);
    }

}
