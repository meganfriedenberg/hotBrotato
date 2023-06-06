using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody m_Rigidbody;
    public float movementSpeed = 150.0f;
    public Vector3 rotationSpeed = new Vector3(0, 720, 0);

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 facing = new Vector3(horizontalInput, 0, verticalInput);
        facing.Normalize();

        m_Rigidbody.MovePosition(transform.position + facing * Time.deltaTime * movementSpeed);

    }
}
