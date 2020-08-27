using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crew_Controller : MonoBehaviour
{
    private new Transform transform;
    private new Rigidbody2D rigidbody;

    private Vector2 target;

    public Crewman crewman;

    private void Awake()
    {
        transform = GetComponent<Transform>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    {
        Vector2 dir = target - (Vector2)transform.position;
        dir.Normalize();

        rigidbody.velocity = dir * crewman.speed * 100 * Time.fixedDeltaTime;
    }


    public void MoveTo(Vector2 target)
    {
        this.target = target;
    }
}

[System.Serializable]
public class Crewman
{
    public string name;
    public float speed;
}
