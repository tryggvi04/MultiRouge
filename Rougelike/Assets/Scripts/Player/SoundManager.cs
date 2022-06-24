using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    [SerializeField]
    private AudioSource aliveMusic;
    [SerializeField]
    private AudioSource deadMusic;
    [SerializeField]
    private Health healthScript;

    private bool swapMusic = true;

    void Awake()
    {
        aliveMusic.Play();
    }

    void Update()
    {
        if (healthScript.Dead && swapMusic)
        {
            swapMusic = false;
            aliveMusic.Stop();
            deadMusic.Play();
        }
    }

}
