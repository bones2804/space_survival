using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private new Transform transform;

    public Vector2 currentMovement { get; set; }
    public bool NormalMovement { get; set; }

    // Start is called before the first frame update
    void Awake()
    {
        NormalMovement = true;
        transform = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        if(NormalMovement)
            MoveCharacter();
    }

    private void MoveCharacter() => transform.localPosition += ((Vector3)currentMovement * Time.fixedDeltaTime);

    public void MovePosition(Vector2 newPosition)
    {
        transform.localPosition = newPosition;
    }

    public void SetMovement(Vector2 targetVector)
    {
        currentMovement = targetVector;
    }
}


