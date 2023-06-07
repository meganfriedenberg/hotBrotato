using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player1;
    public Rigidbody m_Rigidbody;
    public float movementSpeed = 150.0f;
    public float driftFactor = 0.8f; // Controls the amount of drifting

    private Vector3 previousChaseDirection;
    private bool isFrozen = true;
    private float freezeTimer = 3.0f;

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void LateUpdate()
    {
        if (isFrozen)
        {
            freezeTimer -= Time.deltaTime;
            if (freezeTimer <= 0.0f)
            {
                isFrozen = false;
            }
            else
            {
                return; // Don't perform any movement while frozen
            }
        }

        Vector3 playerPos = player1.transform.position;
        Vector3 fromAItoPlayer = playerPos - transform.position;
        fromAItoPlayer.Normalize();

        // Check if the player changed direction
        if (Vector3.Dot(fromAItoPlayer, previousChaseDirection) < 0)
        {
            // Apply drifting effect
            Vector3 driftDirection = previousChaseDirection * driftFactor;
            fromAItoPlayer += driftDirection;
        }

        // Normalize the resulting direction vector
        fromAItoPlayer.Normalize();

        // Update the previous chase direction
        previousChaseDirection = fromAItoPlayer;

        m_Rigidbody.MovePosition(transform.position + fromAItoPlayer * Time.deltaTime * movementSpeed);

        // Rotate the monster to face the player
        transform.LookAt(playerPos);
    }
}
