using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player1;
    public Rigidbody m_Rigidbody;
    public float movementSpeed = 150.0f;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = player1.transform.position;
        Vector3 fromAItoPlayer = playerPos - transform.position;
        fromAItoPlayer.Normalize();
        m_Rigidbody.MovePosition(transform.position + fromAItoPlayer * Time.deltaTime * movementSpeed);
        //Debug.Log(player1.transform.position);
    }
}
