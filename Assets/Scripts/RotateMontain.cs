using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMontain : MonoBehaviour
{
    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rotates the mountain in the start screen
        transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * speed);
    }
}
