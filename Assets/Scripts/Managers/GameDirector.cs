using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    [Header("Managers")]
    public EnemyManager enemyManager;
    public LevelManager levelManager;
    public void LevelCompleted()
    {
       enemyManager.StopEnemies();
    }
    private void Start()
    {
        RestartLevel();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            RestartLevel();
        }
    }
    private void RestartLevel()
    {
        levelManager.hideDoor();
        enemyManager.RestartEnemyManager();
    }
}
