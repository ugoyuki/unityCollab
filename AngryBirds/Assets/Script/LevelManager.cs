using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager i { get; private set; }

    public GameObject CharacterPrefab;
    public GameObject ClearDialog;
    //public GameObject ScoreDialog;
    public Text scoreText;
    public int EnemyCount { get; private set; } = 0;

    private void Awake()
    {
        i = this;
        Instantiate(CharacterPrefab, transform.position, Quaternion.identity);
    }

    public void NextCharacter()
    {
        Instantiate(CharacterPrefab, transform.position, Quaternion.identity);
    }

    public void EnemyCountAdd()
    {
        EnemyCount++;
    }

    public void EnemyDie()
    {
        EnemyCount--;

        if(EnemyCount == 0)
        {
            ClearDialog.SetActive(true);
        }
    }
}
