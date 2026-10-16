using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    public float rotationSpeed = 60;

    void Update () {
        transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed, Space.World);
    }
}