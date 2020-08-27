using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public Crew_Controller[] crewmen;

    private int current = 0;

    private Inputs_Master input;

    private void Awake()
    {
        input = new Inputs_Master();
    }

    private void Update()
    {
        var crewmemeber = crewmen[current];
        crewmemeber.MoveTo((Vector2)(crewmemeber.GetComponent<Transform>().position) + input.Crew.Move.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        input.Crew.Enable();
    }

    private void OnDisable()
    {
        input.Crew.Disable();   
    }
}
