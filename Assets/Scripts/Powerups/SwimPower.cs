using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimPower : PiggyPower
{
    public override void activate()
    {
        EnablePlayerSwim();
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
