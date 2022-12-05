using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject wind;
    public List<ParticleSystem> windEffects;

    public delegate void OnGameStateChanged();
    public static OnGameStateChanged updateGameState;


    private void Start()
    {
        foreach (ParticleSystem wind in windEffects)
            StartCoroutine(startVFX(wind));
    }

    private IEnumerator startVFX(ParticleSystem wind)
    {
        float randomSeconds = Random.value * 5;
        yield return new WaitForSeconds(randomSeconds);
        wind.gameObject.SetActive(true);
    }

    public static void RestartGame()
    {
        Debug.Log("Lose!");
    }

    public static void GameWon()
    {
        Debug.Log("Win!");
    }
}
