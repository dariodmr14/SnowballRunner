using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject snowball;
    private Vector3 distance;

    void Start () {
        distance = transform.position - snowball.transform.position;
    }

    void LateUpdate () {
        transform.position = snowball.transform.position + distance * snowball.transform.localScale.x;
    }
}