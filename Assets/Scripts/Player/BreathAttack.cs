using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreathAttack : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Damage")
        {
            Debug.Log("Destroyed");
            other.gameObject.tag = "OnFire";
            GameManager.destructionCount++;

            if (GameManager.destructionCount >= 10)
            {
                GameManager.updateGameState = GameManager.GameWon;
                GameManager.updateGameState();
            }
        }
    }
}
