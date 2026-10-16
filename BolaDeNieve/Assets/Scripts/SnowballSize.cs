using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballSize : MonoBehaviour {

    private Rigidbody rigidBody;

    public float size = 1;
    public float minSize = 0.4f;
    public float maxSize = 2.5f;

    public float growSpeed = 0.25f;
    public float meltSpeed = 0.35f;
    public float minSpeedToGrow = 1;

    public AudioSource snowAudio = null;
    public AudioSource meltAudio = null;

    private bool onSnow = false;
    private bool onLava = false;

    void Start () {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update () {
        bool isMoving = rigidBody.velocity.magnitude > minSpeedToGrow;
        bool isGrowing = onSnow && isMoving && size < maxSize;

        if (isGrowing)
        {
            size += growSpeed * Time.deltaTime;
        }

        if (onLava)
        {
            size -= meltSpeed * Time.deltaTime;
        }

        size = Mathf.Clamp(size, minSize, maxSize);

        transform.localScale = new Vector3(size, size, size);
        rigidBody.mass = size;

        if (snowAudio != null)
        {
            if (isGrowing && !snowAudio.isPlaying)
                snowAudio.Play();
            if (!isGrowing && snowAudio.isPlaying)
                snowAudio.Stop();
        }

        if (meltAudio != null)
        {
            if (onLava && !meltAudio.isPlaying)
                meltAudio.Play();
            if (!onLava && meltAudio.isPlaying)
                meltAudio.Stop();
        }
    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("SnowZone"))
            onSnow = true;
        if (other.gameObject.CompareTag("LavaZone"))
            onLava = true;
    }

    private void OnTriggerExit (Collider other)
    {
        if (other.gameObject.CompareTag("SnowZone"))
            onSnow = false;
        if (other.gameObject.CompareTag("LavaZone"))
            onLava = false;
    }
}
