using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject wind;
    public List<ParticleSystem> windEffects;

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
}
