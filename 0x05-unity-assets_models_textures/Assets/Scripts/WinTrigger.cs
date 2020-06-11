using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    public Text timerText;

    void OnTriggerEnter(Collider change)
    {
        if (change.name == "Player")
        {
            change.gameObject.GetComponent<Timer>().enabled = false;
            timerText.fontSize = 75;
            timerText.color = Color.green;
        }
    }
}
