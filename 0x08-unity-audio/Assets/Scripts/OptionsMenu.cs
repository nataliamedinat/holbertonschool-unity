using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Toggle invertedMode;

    void Start()
    {
        if (PlayerPrefs.GetInt("invertedY") == 1)
            invertedMode.isOn = true;
        else
            invertedMode.isOn = false;
    }

    public void Back()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("Last"));
    }

    public void Apply()
    {
        if (invertedMode.isOn == true)
            PlayerPrefs.SetInt("invertedY", 1);
        else
            PlayerPrefs.SetInt("invertedY", 0);
        Back();
    }
}
