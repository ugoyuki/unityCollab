using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private const float DIEVELOCITY = 5f;
    public int score;
    public GameObject scoreImage;

    // Start is called before the first frame update
    void Start()
    {
        LevelManager.i.EnemyCountAdd();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.sqrMagnitude > DIEVELOCITY)
        {
            LevelManager.i.scoreText.text = (int.Parse(LevelManager.i.scoreText.text) + score).ToString();
            Instantiate(scoreImage,transform.position, Quaternion.identity);
            Destroy(gameObject);
            LevelManager.i.EnemyDie();
        }
    }
}
