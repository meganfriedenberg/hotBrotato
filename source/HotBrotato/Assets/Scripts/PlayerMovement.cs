using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float movementSpeed = 150.0f;
    public Vector3 rotationSpeed = new Vector3(0, 720, 0);
    public float rotationSmoothness = 5.0f;

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal1");
        float verticalInput = Input.GetAxis("Vertical1");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        if (horizontalInput > 0 || verticalInput > 0)
        {
            movementDirection.Normalize();
        }

        m_Rigidbody.MovePosition(transform.position + movementDirection * Time.deltaTime * movementSpeed);

        // Rotate the player smoothly towards the movement direction
        if (movementDirection.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movementDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSmoothness * Time.deltaTime);
        }
    }
}
