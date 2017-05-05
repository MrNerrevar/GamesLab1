using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : SteeringBehaviour
{
    public GameObject target;
    public override Vector3 Calculate()
    {
        return (-target.transform.position);
    }
}