using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSnowball : MonoBehaviour {

    private Rigidbody rigidBody;

    public float ballSpeed = 800;
    public float jumpForce = 3;
    public float maxSpeed = 8;

    private bool isTouchingGround = false;

    void Start () {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update () {
        float hmove = Input.GetAxis("Horizontal");
        float vmove = Input.GetAxis("Vertical");

        Vector3 ballMove = new Vector3(hmove, 0.0f, vmove);
        rigidBody.AddForce(ballMove * Time.deltaTime * ballSpeed);

        Vector3 horizontalSpeed = new Vector3(rigidBody.velocity.x, 0.0f, rigidBody.velocity.z);
        if (horizontalSpeed.magnitude > maxSpeed)
        {
            horizontalSpeed = horizontalSpeed.normalized * maxSpeed;
            rigidBody.velocity = new Vector3(horizontalSpeed.x, rigidBody.velocity.y, horizontalSpeed.z);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isTouchingGround)
        {
            rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isTouchingGround = false;
        }
    }

    private void OnCollisionStay (Collision collision)
    {
        isTouchingGround = true;
    }

    private void OnCollisionExit (Collision collision)
    {
        isTouchingGround = false;
    }
}