using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzikKontrol : MonoBehaviour
{
    public static MuzikKontrol instance;
    AudioSource audioSource;
    private void Awake()
    {
        Singleton();
        audioSource = GetComponent<AudioSource>();
    }

    void Singleton()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }
    public void MuzikCal(bool play)
    {
        if (play)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}
