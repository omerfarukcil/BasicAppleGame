using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Player player;
    public Enemy enemyPrefeb;
    public List<Enemy> enemies;
    public int enemyCount;
    
    public void RestartEnemyManager()
    {
        DeleteEnemies();
        GenerateEnemies();
        player.transform.position =  new Vector3 (0,1.5f,-15);
        player.isAppleCollected = false;
        player.gameObject.SetActive(true);
    }

    private void GenerateEnemies()
    {
        CreateEnemies();
    }
    private void CreateEnemies()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            Enemy newEnemy = Instantiate(enemyPrefeb);
            var enemyPos = newEnemy.transform.position;
            enemyPos.z = UnityEngine.Random.Range(5f, -11f);
            enemyPos.x = UnityEngine.Random.Range(-6.1f, 7.3f);
            newEnemy.transform.position = new Vector3(enemyPos.x, 0, enemyPos.z);
            enemies.Add(newEnemy);
            newEnemy.StartEnemy(player);
        }
    }
    private void DeleteEnemies() 
    {
        foreach (var e in enemies)
        {
            Destroy(e.gameObject); 
        }
        enemies.Clear();
    }
    public void StopEnemies()
    {
        foreach (var e in enemies)
        {
            e.Stop();
        } 
    }
}
