using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalReached : MonoBehaviour
{
    public static int Counter;

    private AudioSource goalAudio;
    public AudioClip goalClip;

    // Start is called before the first frame update
    void Start()
    {
        goalAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        goalAudio.PlayOneShot(goalClip);
        Counter++;
        Debug.Log(Counter);
    }
}
