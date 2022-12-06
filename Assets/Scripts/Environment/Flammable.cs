using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flammable : MonoBehaviour
{
    public GameObject fire;
    private bool onFire = false;

    private void OnTriggerEnter(Collider other)
    {
        if (onFire == false)
        {
            if (other.gameObject.tag == "Fire")
            {
                Debug.Log("Destroyed");
                onFire = true;
                fire.SetActive(true);
                GameManager.destructionCount++;

                if (GameManager.destructionCount >= 10)
                {
                    GameManager.updateGameState = GameManager.GameWon;
                    GameManager.updateGameState();
                }
            }
        }
    }
}
