using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour
{
    public static int fallenCounter;

    // Destoys the wheel
    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
        fallenCounter++;
    }
}
