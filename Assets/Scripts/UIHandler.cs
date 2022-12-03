using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIHandler : MonoBehaviour
{
    public TextMeshProUGUI startMessage;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("RemoveStartMessage", 3f);
    }

    private void RemoveStartMessage()
    {
        startMessage.SetText("");
    }
}
