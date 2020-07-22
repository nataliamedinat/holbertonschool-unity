using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField]
    private AudioClip walkgrass, walkrock;
    private AudioSource audiosrc;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        audiosrc = GetComponent<AudioSource>();
    }

    // start running on rock sound
    public void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audiosrc.PlayOneShot(walkrock);
             Debug.Log("estoy en rock");
        }
    }
}
