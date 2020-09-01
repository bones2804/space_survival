using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : CharacterComponents
{
    [SerializeField] private float walkSpeed = 1f;

    public float MoveSpeed { get; set; }

    protected override void Awake()
    {
        base.Awake();
        ResetSpeed();
    }

    protected override void HandleAbility()
    {
        base.HandleAbility();
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        var movement = move_Input.magnitude > 1 ? move_Input.normalized : move_Input;

        controller.SetMovement(movement * MoveSpeed);
    }

    public void ResetSpeed()
    {
        MoveSpeed = walkSpeed;
    }
}
