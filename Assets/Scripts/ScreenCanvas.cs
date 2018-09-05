using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenCanvas : MonoBehaviour {

    PlayerController.Direction currentDirection;
    PlayerController player;

    EnemyController.EnemyEmotes currentEnemyEmo;

    public Text posTxt;
    public Text negTxt;
    public Text enemyEmo;
    public GameObject menu;

    bool bIsPaused;

    // Use this for initialization
    void Start () {
        player = FindObjectOfType<PlayerController>();
        bIsPaused = false;
        player.bIsPaused = false;
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
        DuringGame();

        if (Input.GetButtonDown("Cancel"))
        {
            if (bIsPaused)
            {
                Unpause();
            }
            else
            {
                Paused();
            }
        }
    }

    void DuringGame()
    {
        currentDirection = player.currentDirection;

        if (currentDirection == PlayerController.Direction.Down)
        {
            posTxt.text = "Fear";
            negTxt.text = "Pity";
        }
        else if (currentDirection == PlayerController.Direction.Up)
        {
            posTxt.text = "Joy";
            negTxt.text = "Sorrow";
        }
        else if (currentDirection == PlayerController.Direction.Left)
        {
            posTxt.text = "Surprise";
            negTxt.text = "Intimidate";
        }
        else if (currentDirection == PlayerController.Direction.Right)
        {
            posTxt.text = "Admiration";
            negTxt.text = "Anger";
        }


        if (player.currentEnemy == null)
        {
            enemyEmo.enabled = false;
        }
        else
        {
            currentEnemyEmo = player.currentEnemy.currentEnemyEmotes;
            enemyEmo.enabled = true;

            if (currentEnemyEmo == EnemyController.EnemyEmotes.Admire)
            {
                enemyEmo.text = "Admiration";
            }
            else if (currentEnemyEmo == EnemyController.EnemyEmotes.Anger)
            {
                enemyEmo.text = "Anger";
            }
            else if (currentEnemyEmo == EnemyController.EnemyEmotes.Conflicted)
            {
                enemyEmo.text = "Conflicted";
            }
            else if (currentEnemyEmo == EnemyController.EnemyEmotes.Confusion)
            {
                enemyEmo.text = "Confusion";
            }
            else if (currentEnemyEmo == EnemyController.EnemyEmotes.Dizzy)
            {
                enemyEmo.text = "Stunned";
            }
            else if (currentEnemyEmo == EnemyController.EnemyEmotes.Fear)
            {
                enemyEmo.text = "Fear";
            }
            else if (currentEnemyEmo == EnemyController.EnemyEmotes.Idea)
            {
                enemyEmo.text = "Focused";
            }
            else if (currentEnemyEmo == EnemyController.EnemyEmotes.Intimidation)
            {
                enemyEmo.text = "Intimidation";
            }
            else if (currentEnemyEmo == EnemyController.EnemyEmotes.Joy)
            {
                enemyEmo.text = "Joy";
            }
            else if (currentEnemyEmo == EnemyController.EnemyEmotes.Pity)
            {
                enemyEmo.text = "Pity";
            }
            else if (currentEnemyEmo == EnemyController.EnemyEmotes.Singing)
            {
                enemyEmo.text = "Humming";
            }
            else if (currentEnemyEmo == EnemyController.EnemyEmotes.Sorrow)
            {
                enemyEmo.text = "Sorrow";
            }
            else if (currentEnemyEmo == EnemyController.EnemyEmotes.Surprise)
            {
                enemyEmo.text = "Surprise";
            }
            else if (currentEnemyEmo == EnemyController.EnemyEmotes.Tired)
            {
                enemyEmo.text = "Tired";
            }
        }
    }

    void Paused()
    {
        bIsPaused = true;
        player.bIsPaused = true;
        Time.timeScale = 0;
        menu.SetActive(true);
    }

    public void Unpause()
    {
        bIsPaused = false;
        player.bIsPaused = false;
        Time.timeScale = 1;
        menu.SetActive(false);

    }
}
