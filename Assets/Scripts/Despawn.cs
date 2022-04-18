using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour
{
    public static int FallenCounter;
    private AudioSource despawnAudio;
    public AudioClip despawnClip;

    private void Start()
    {
        despawnAudio = GetComponent<AudioSource>();
    }

    // Destoys the wheel
    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
        FallenCounter++;

        if(FallenCounter > GoalReached.Counter)
        {
            despawnAudio.PlayOneShot(despawnClip);
        }
    }
}
