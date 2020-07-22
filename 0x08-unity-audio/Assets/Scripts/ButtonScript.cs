using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField]
    private AudioClip ButtonClick, ButtonOver;
    private AudioSource audiosrc;

    private void Start()
    {
        audiosrc = GetComponent<AudioSource>();
    }

    // Start roll over audio
    void BrOver()
    {
        audiosrc.PlayOneShot(ButtonOver);
    }

    // start click sound
    void BClick()
    {
        audiosrc.PlayOneShot(ButtonClick);
    }
}
