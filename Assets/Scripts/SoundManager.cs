using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip lumenCollected,nextLevel;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        lumenCollected = Resources.Load<AudioClip>("lumenCollected");
        nextLevel = Resources.Load<AudioClip>("nextLevel");
        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound (string effect)
    {
        switch(effect)
        {
            case "lumen":
                audioSrc.PlayOneShot(lumenCollected);
                break;
            case "next":
                audioSrc.PlayOneShot(nextLevel);
                break;

        }
    }
}
