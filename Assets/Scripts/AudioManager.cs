using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    // Referencia al AudioSource del escenario principal
    public AudioSource mainAudioSource;

    void Awake()
    {
        // Asegúrate de que solo haya una instancia del objeto persistente
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}