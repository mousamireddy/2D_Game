using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundscript : MonoBehaviour
{
    // Start is called before the first frame update
    public static AudioClip GunSound;
    static AudioSource audioSource;
    void Start()
    {
        GunSound = Resources.Load<AudioClip>("gunsound");
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public static void PlaySound(string clip)
    {
        switch (clip)
        {

            case "gunsound":
                audioSource.PlayOneShot(GunSound);
                break;
            
        }
    }
}
