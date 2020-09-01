using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterDash : CharacterComponents
{
    [SerializeField] private float dashDistance = 5f;
    [SerializeField] private float dashDuration = 0.5f;

    private bool isDashing;
    private float dashTimer;
    private Vector2 dashOrigin;
    private Vector2 dashDestination;
    private Vector2 newPosition;

    protected override void Awake()
    {
        base.Awake();

        inputs.Crew.Dash.started += ctx => Dash();
    }

    protected override void HandleAbility()
    {
        base.HandleAbility();

        if(isDashing)
        {
            if(dashTimer < dashDuration)
            {
                newPosition = Vector2.Lerp(dashOrigin, dashDestination, dashTimer / dashDuration);
                controller.MovePosition(newPosition);
                dashTimer += Time.deltaTime;
            }
            else
            {
                StopDash();
            }
        }
    }

    private void Dash()
    {
        if(controller.NormalMovement)
        {
            Debug.Log("Dash");
            isDashing = true;
            dashTimer = 0f;
            dashOrigin = transform.localPosition;
            dashDestination = dashOrigin + controller.currentMovement.normalized * dashDistance;

            controller.NormalMovement = false;
        }
    }
    
    private void StopDash()
    {
        controller.NormalMovement = true;
    }
}
