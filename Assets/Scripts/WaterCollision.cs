using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCollision : MonoBehaviour
{
    public AudioClip splashOne;
    private AudioSource sound;

    private void Awake()
    {
        sound = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Piggy")
        {
            sound.PlayOneShot(splashOne);
        }
    }
}
