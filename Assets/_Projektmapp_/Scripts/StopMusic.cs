using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMusic : MonoBehaviour
{
    public AudioSource _audioSource;
    public bool _isPlaying;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Hands")
        {
            Debug.Log("Radio Stopped");
            _audioSource.Stop();
        }

       
    }
}
