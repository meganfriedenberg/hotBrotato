using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBall : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject currPlayer;
    public GameObject currTarget;

    public bool currMoving = false;
    public float movementSpeed = 150.0f;
    public Vector3 offset = new Vector3(0, 4, 0);
    // Start is called before the first frame update
    void Start()
    {

        currPlayer = player1;
        currTarget = player2;
        Debug.Log(player1.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if(!currMoving)
        {
            Debug.Log("CURR POS");
            Debug.Log(transform.position);
            Vector3 fromBallToPlayer = currPlayer.transform.position + offset - transform.position;
            fromBallToPlayer.Normalize();
            //transform.Translate(transform.position + fromBallToPlayer * Time.deltaTime * movementSpeed, Space.World);
            transform.position += fromBallToPlayer * Time.deltaTime * movementSpeed;
        }
        else
        {

        }
    }
}
