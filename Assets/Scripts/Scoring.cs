using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    public delegate void ScoreUpdated();

    public ScoreUpdated OnScoreUpdated;

    const int EnemyKillPoints = 50;
    const int TetrisRowScore = 40;
    const int DoubleRowScore = 100;
    const int TripleRowScore = 300;
    const int QuadrupleRowScore = 1200;

    public int PlayerScore { get; private set; } = 0;
    public int EnemyScore { get; private set; } = 0;

    public int PlayerLives { get; private set; } = 3;

    private GameObject Player { get; set; }
    private bool playerDeathAssigned = false;
    private bool enemyDeathAssigned = false;
    private Spawner EnemySpawner { get; set; }
    private Spawner PlayerSpawner { get; set; }
    private Enemy Enemy { get; set; }
    private Goal PlayerGoal { get; set; }
    private Goal EnemyGoal { get; set; }


    public void ResetScores()
    {
        PlayerScore = 0;
        EnemyScore = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        //TODO: weird thing to get a hold on to get player but its the only unique thing right now
        var spawners = FindObjectsOfType<Spawner>();
        foreach (var spawner in spawners)
        {
            if (spawner.IsEnemySpawner)
            {
                EnemySpawner = spawner;
                EnemySpawner.OnSpawned += HandleEnemySpawn;
            }
            else
            {
                PlayerSpawner = spawner;
                PlayerSpawner.OnSpawned += HandlePlayerSpawn;
            }
        }

        var goals = FindObjectsOfType<Goal>();
        foreach (var goal in goals)
        {
            if (goal.IsPlayerOneGoal)
            {
                PlayerGoal = goal;
                PlayerGoal.OnScored += HandleEnemyScore;
            }
            else
            {
                EnemyGoal = goal;
                EnemyGoal.OnScored += HandlePlayerScore;
            }
        }
    }

    private void HandlePlayerScore()
    {
        PlayerScore++;
        if (OnScoreUpdated != null)
        {
            OnScoreUpdated.Invoke();
        }
    }

    private void HandleEnemyScore()
    {
        EnemyScore++;
        if (OnScoreUpdated != null)
        {
            OnScoreUpdated.Invoke();
        }
    }

    private void HandlePlayerSpawn(int instanceId)
    {
        //if (playerDeathAssigned) { return; }
        var player = FindObjectOfType<Controls>();
        player.GetComponent<Killable>().OnKilled += HandlePlayerDeath;
        //playerDeathAssigned = true;
    }

    private void HandleEnemySpawn(int instanceId)
    {
        //if (enemyDeathAssigned) { return; }
        var enemy = FindObjectOfType<Enemy>();
        enemy.GetComponent<Killable>().OnKilled += HandleEnemyDeath;
        //enemyDeathAssigned = true;
    }

    private void HandleEnemyDeath()
    {
        //Enemy.GetComponent<Killable>().OnKilled -= HandleEnemyDeath;
        //PlayerScore += EnemyKillPoints;
        //if (OnScoreUpdated != null)
        //{
        //    OnScoreUpdated.Invoke();
        //}
    }

    private void HandlePlayerDeath()
    {
        //Player.GetComponent<Killable>().OnKilled -= HandlePlayerDeath;
        //PlayerLives--;
        //if (OnScoreUpdated != null)
        //{
        //    OnScoreUpdated.Invoke();
        //}
    }
}
