using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager i { get; private set; }

    public GameObject CharacterPrefab;

    private void Awake()
    {
        i = this;
        Instantiate(CharacterPrefab, transform.position, Quaternion.identity);
    }

    public void NextCharacter()
    {
        Instantiate(CharacterPrefab, transform.position, Quaternion.identity);
    }
}
