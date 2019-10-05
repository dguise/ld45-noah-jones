using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAndLookAtPlayer : MonoBehaviour
{
    public Transform Target;
    private Vector3 offset;
    Vector3 velocity;

    private void Start()
    {
        offset = Target.position - transform.position;
    }

    void FixedUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, Target.position - offset, ref velocity, 1f);
        //transform.LookAt(Target);
    }
}
