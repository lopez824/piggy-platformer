using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBoundsHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.updateGameState = GameManager.RestartGame;
            GameManager.updateGameState();
        }
    }
}
