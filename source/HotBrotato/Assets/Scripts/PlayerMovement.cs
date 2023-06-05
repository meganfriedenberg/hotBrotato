using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public float rotationSpeed = 720.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 facing = new Vector3(horizontalInput, 0, verticalInput);
        facing.Normalize();

        transform.Translate(facing * movementSpeed * Time.deltaTime, Space.World);

        if (facing != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(facing, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
