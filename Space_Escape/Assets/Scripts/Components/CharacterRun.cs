using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterRun : CharacterComponents
{
    [SerializeField] private float runSpeed = 1f;

    protected override void HandleInputs()
    {
        if(Keyboard.current.leftShiftKey.IsPressed())
        {
            Run();
        }
        else
        {
            StopRun();
        }
    }

    private void Run()
    {
        if(controller.NormalMovement)
            mover.MoveSpeed = runSpeed;
    }

    private void StopRun()
    {
        mover.ResetSpeed();
    }
}
