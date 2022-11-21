using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource[] thunder;

    int randomThunderIndex; // Used to select random audiosource from array.

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("playRandomThunder", 3, 10);
    }

    private void Update()
    {
        randomThunderIndex = Random.Range(0, thunder.Length);
    }

    public void playRandomThunder()
    {
        thunder[randomThunderIndex].Play();
    }
}
