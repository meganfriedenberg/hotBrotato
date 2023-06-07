using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCooldown : MonoBehaviour
{
    private MeshRenderer ballRenderer;
    private float cooldownTimer;
    private float cooldownDuration = 5.0f;
    private bool isCooldownActive = false;

    private Color startColor = Color.red;
    private Color endColor = Color.green;

    private void Start()
    {
        ballRenderer = GetComponent<MeshRenderer>();
        ResetCooldown();
    }

    private void Update()
    {
        
        if(Input.GetButton("Throw") && !isCooldownActive)
        {
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
