using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWheel : MonoBehaviour
{
    public float speed = 20.0f;
    private int rotateDirection = 1;

    private AudioSource wheelSource;

    // Start is called before the first frame update
    void Start()
    {
        wheelSource = GetComponent<AudioSource>();
        wheelSource.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        RotateFromMiddle();
    }

    // Rotates the cog wheel from its center
    void RotateFromMiddle()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            wheelSource.Play();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Vector3 rotate = new Vector3(0, 0, -1);

            transform.Rotate(rotate * Time.deltaTime * speed * rotateDirection);
        }

        // Switches spin direction every time space is pressed
        if (Input.GetKeyUp(KeyCode.Space))
        {
            wheelSource.Stop();
            rotateDirection *= -1;
        }
    }
}
