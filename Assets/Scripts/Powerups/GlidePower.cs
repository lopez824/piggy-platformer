using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlidePower : PiggyPower
{
    public override void activate()
    {
        EnablePlayerGlide();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            AudioSource playerSound = other.gameObject.GetComponent<AudioSource>();
            playerSound.PlayOneShot(AudioLibrary.library["grunt_1"]);
            activate();
        }
        Destroy(gameObject);
    }
}
