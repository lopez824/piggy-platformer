using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGoal : MonoBehaviour
{
    public UIHandler uiHandler;

    public IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("SnowCast");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            uiHandler.startMessage.SetText("Hooray! You reached the boat!!");
            StartCoroutine(LoadNextLevel());
        }
    }
}
