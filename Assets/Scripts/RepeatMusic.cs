using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatMusic : MonoBehaviour
{
    public static RepeatMusic Instance;
    private AudioSource bgMusic;

    // Start is called before the first frame update
    void Start()
    {
        bgMusic = GetComponent<AudioSource>();

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
