using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
     private const float DIEVELOCITY = 5f;

    // Start is called before the first frame update
    void Start()
    {
        LevelManager.i.EnemyCountAdd();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.sqrMagnitude > DIEVELOCITY)
        {
            Destroy(gameObject);
            LevelManager.i.EnemyDie();
        }
    }
}
