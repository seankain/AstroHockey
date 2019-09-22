using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public enum GameState
{
    GameOver,
    Playing,
    Demo
}

public class GameControl : MonoBehaviour
{
    public Text AnnouncementText;
    public Text PlayerOneScoreText;
    public Text PlayerTwoScoreText;
    public GameState CurrentState = GameState.Demo;
    private Scoring scoring;
    private List<Spawner> spawners;
    private float elapsed = 0;
    private float gameOverTime = 5;


    // Start is called before the first frame update
    void Start()
    {
        scoring = GetComponent<Scoring>();
        scoring.OnScoreUpdated +=()=>
        {
            UpdatePlayerTwoScore();
            UpdatePlayerOneScore();
        };
        spawners = FindObjectsOfType<Spawner>().ToList();
    }

    public void Transition()
    {
        if (CurrentState == GameState.GameOver)
        {
            CurrentState = GameState.Demo;
            Demo();
        }
        if (CurrentState == GameState.Demo)
        {
            CurrentState = GameState.Playing;

        }
    }

    private void UpdatePlayerTwoScore() {
        PlayerTwoScoreText.text = scoring.EnemyScore.ToString();
    }
    private void UpdatePlayerOneScore() {
        PlayerOneScoreText.text = scoring.PlayerScore.ToString();
    }

    private IEnumerator StartTransition(Action f)
    {
        AnnouncementText.text = string.Empty;
        yield return new WaitForSeconds(2);
        f.Invoke();
    }

    private void GameOver()
    {
        AnnouncementText.text = "Game Over";
        foreach (var spawner in spawners)
        {
            spawner.Despawn();
            spawner.ToggleActive(false);
        }
        
    }

    private void Demo()
    {
        AnnouncementText.text = "Press Space to Start";

    }

    private void StartPlay()
    {
        AnnouncementText.text = string.Empty;
        scoring.ResetScores();
        UpdatePlayerOneScore();
        UpdatePlayerTwoScore();
        foreach (var spawner in spawners)
        {
            spawner.ToggleActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentState == GameState.Demo)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                CurrentState = GameState.Playing;
                StartPlay();
            }
            return;
        }
        if (CurrentState == GameState.Playing)
        {
            if (scoring.PlayerScore >= 5 || scoring.EnemyScore >= 5)
            {
                CurrentState = GameState.GameOver;
                GameOver();
            }
            return;
        }
        if (CurrentState == GameState.GameOver)
        {
            elapsed += Time.deltaTime;
            if (elapsed >= gameOverTime)
            {
                CurrentState = GameState.Demo;
                Demo();
            }
        }
    }
}
