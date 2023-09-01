using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sounds : MonoBehaviour
{
    public static AudioClip gunsound;
    static AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gunsound = Resources.Load<AudioClip>("fire");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public static void PlaySound(string clip)
    {
        switch (clip)
        {

            case "fire":
                audioSource.PlayOneShot(gunsound);
                break;
        }
    }
}
