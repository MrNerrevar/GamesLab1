using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Boid : MonoBehaviour
{
    public Vector3 force = Vector3.zero;
    public Vector3 acceleration = Vector3.zero;
    public Vector3 velocity = Vector3.zero;
    public float mass = 1;
    public float maxSpeed = 5.0f;
    SteeringBehaviour[] behaviours;
    void Start()
    {
        behaviours = this.GetComponents<SteeringBehaviour>();
    }

    void FixedUpdate()
    {
        behaviours = this.GetComponents<SteeringBehaviour>();
        force = CalculateForces();
        acceleration = force / mass;
        velocity = acceleration * Time.deltaTime;
        if (velocity.magnitude > 0.0001f)
        {
            transform.LookAt(transform.position + velocity);
            velocity *= 0.99f;
        }
        this.transform.position += velocity;
    }

    public Vector3 Seek(Vector3 target)
    {
        return ((target - this.transform.position).normalized) * maxSpeed - velocity;
    }

    public Vector3 Flee(Vector3 target)
    {
        return ((this.transform.position).normalized) * maxSpeed - velocity;
    }

    public Vector3 Wander(Vector3 target)
    {
        //Blanked on this
        return this.transform.position;
    }

    Vector3 CalculateForces()
    {
        Vector3 newForce = Vector3.zero;

        foreach (SteeringBehaviour behave in behaviours)
        {
            newForce += (behave.Calculate() * behave.weight);
        }
        return newForce;
    }
}
