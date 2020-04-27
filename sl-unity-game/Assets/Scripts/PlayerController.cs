using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class PlayerController : MonoBehaviour
{
    // Variables
    Vector3 velocity;
    Rigidbody myRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
    }

    // Move method
    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    // LookAt method
    public void LookAt(Vector3 lookPoint)
    {
        Vector3 heightCorrectedLookPoint = new Vector3(lookPoint.x, transform.position.y, lookPoint.z);
        transform.LookAt(heightCorrectedLookPoint);
    }

    // FixedUpdate calls independent of frame rate to avoid collision issues
    public void FixedUpdate()
    {
        myRigidBody.MovePosition(myRigidBody.position + velocity * Time.fixedDeltaTime);
    }
}
