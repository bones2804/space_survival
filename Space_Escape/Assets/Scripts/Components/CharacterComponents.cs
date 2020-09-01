using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterComponents : MonoBehaviour
{
    protected Inputs_Master inputs;

    protected Vector2 move_Input;
    protected CharacterController controller;
    protected CharacterMovement mover;

    protected virtual void Awake()
    {
        inputs = new Inputs_Master();
        controller = GetComponent<CharacterController>();
        mover = GetComponent<CharacterMovement>();
    }

    private void OnEnable()
    {
        inputs.Crew.Enable();
    }

    private void OnDisable()
    {
        inputs.Crew.Disable();
    }

    protected virtual void Update()
    {
        HandleAbility();
    }

    protected virtual void HandleAbility()
    {
        HandleInputs();
        InternalInput();
    }

    protected virtual void HandleInputs()
    {

    }

    protected virtual void InternalInput()
    {
        move_Input = inputs.Crew.Move.ReadValue<Vector2>();
    }
}
