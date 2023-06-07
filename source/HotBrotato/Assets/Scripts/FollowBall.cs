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
    public Vector3 offset = new Vector3(0, 3, 0);
    // Start is called before the first frame update

    // color change variables
    private MeshRenderer ballRenderer;
    private float cooldownTimer;
    private float cooldownDuration = 5.0f;
    private bool isCooldownActive = false;

    private Color startColor = Color.red;
    private Color endColor = Color.green;
    // end color change variables

    void Start()
    {

        currPlayer = player1;
        currTarget = player2;

        ballRenderer = GetComponent<MeshRenderer>();
        ResetCooldown();
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetButton("Throw"))
        //{
        //    GameObject temp = currPlayer;
        //    currPlayer = currTarget;
        //    currTarget = temp;
        //    Debug.Log("THROWING");

        //}
        if (Input.GetButton("Throw") && !isCooldownActive)
        {
            GameObject temp = currPlayer;
            currPlayer = currTarget;
            currTarget = temp;
            Debug.Log("THROWING");
            StartCooldown();
        }
        else if (isCooldownActive)
        {
            cooldownTimer -= Time.deltaTime;

            // Calculate the color based on the remaining cooldown time
            float t = 1 - (cooldownTimer / cooldownDuration);
            Color currentColor = Color.Lerp(startColor, endColor, t);

            // Apply the color to the ball renderer
            ballRenderer.material.color = currentColor;

            if (cooldownTimer <= 0.0f)
            {
                isCooldownActive = false;
            }
        }

        Vector3 fromBallToPlayer = currPlayer.transform.position + offset - transform.position;
        fromBallToPlayer.Normalize();
        //transform.Translate(transform.position + fromBallToPlayer * Time.deltaTime * movementSpeed, Space.World);
        transform.position += fromBallToPlayer * Time.deltaTime * movementSpeed;
     
    }

    public void StartCooldown()
    {
        isCooldownActive = true;
        cooldownTimer = cooldownDuration;
    }

    public bool IsCooldownActive()
    {
        Debug.Log("COOLING DOWN");
        return isCooldownActive;
    }

    public void ResetCooldown()
    {
        isCooldownActive = false;
        cooldownTimer = 0.0f;
        ballRenderer.material.color = startColor;
    }
}
