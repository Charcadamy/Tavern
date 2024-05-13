using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinUIImage : MonoBehaviour
{
    public float rotationSpeed = 100f; // Adjust the speed as needed

    void Update()
    {
        // Rotate around the Z-axis at rotationSpeed degrees per second
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}