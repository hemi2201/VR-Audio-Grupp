using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioExample1 : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        // Ex1();
    }

    // Update is called once per frame
    void Update()
    {
        // Ex2();
        // Ex3();
        // Ex4();
        Ex5();
    }

    private void Ex1()
    {
        audioSource.Play();
    }

    private void Ex2()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.Play();
        }

        
    }

    private void Ex3()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.Play();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            audioSource.Pause();
        }
    }

    private void Ex4()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.Play();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            audioSource.Pause();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            audioSource.Stop();
        }
    }

    private void Ex5()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.PlayOneShot(audioClip);
        }
    }
}
