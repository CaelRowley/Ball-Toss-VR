using UnityEngine;
using System.Collections;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeedX;
    public float rotationSpeedY;
    public float rotationSpeedZ;

    void Update()
    {
        transform.Rotate(rotationSpeedX * Time.deltaTime, rotationSpeedY * Time.deltaTime, rotationSpeedZ * Time.deltaTime);
    }
}
