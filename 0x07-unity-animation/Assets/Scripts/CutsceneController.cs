using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject timer;
    public GameObject player;
    public GameObject cutCam;

    public void Transitions ()
    {
        mainCamera.SetActive(true);
        player.GetComponent<CharacterController>().enabled = true;
        timer.SetActive(true);
        cutCam.SetActive(false);
    }
}
