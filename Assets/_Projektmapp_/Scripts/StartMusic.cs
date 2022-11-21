using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMusic : MonoBehaviour
{

    public AudioSource _audioSource;
    public bool _turnOnMusic = false;

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Hands")
        {
            Debug.Log("Radio Started");
            _audioSource.Play();
        }
    }
}
