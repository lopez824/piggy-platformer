using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject wind;
    public List<ParticleSystem> windEffects;
    public static Animator winPanelAnim;

    public delegate void OnGameStateChanged();
    public static OnGameStateChanged updateGameState;
    public static int destructionCount = 0;
    public static AudioSource sound;

    private void Start()
    {
        sound = GetComponent<AudioSource>();
        winPanelAnim = GameObject.FindGameObjectWithTag("Finish").GetComponent<Animator>();
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
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public static void GameWon()
    {
        Debug.Log("Win!");
        winPanelAnim.Play("WinUI");
    }

    public static void LoadNextLevel()
    {
        // TODO: Design Next level!
    }

    public static void PlayMainTheme()
    {
        sound.Stop();
        sound.clip = AudioLibrary.library["piggytheme"];
        sound.volume = 0.1f;
        sound.loop = true;
        sound.Play();
    }

    public static void PlaySadTheme()
    {
        sound.Stop();
        sound.clip = AudioLibrary.library["Flow_2"];
        sound.volume = 0.75f;
        sound.loop = true;
        sound.Play();
    }
}
