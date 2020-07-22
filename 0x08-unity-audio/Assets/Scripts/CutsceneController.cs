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
        player.GetComponent<PlayerController>().enabled = true;
        timer.SetActive(true);
        cutCam.SetActive(false);
    }

    private void Update()
    {
        if (transform.position == new Vector3(0f, 2.5f, -6.25f))
        {
            Transitions();
        }
    }
}
