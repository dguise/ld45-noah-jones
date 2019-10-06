using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expand : MonoBehaviour
{
    public float scaleSpeed = 0.001f;
    void FixedUpdate()
    {
        var scale = new Vector3(scaleSpeed, 0, scaleSpeed);
        transform.localScale = transform.localScale + scale * Time.deltaTime;
    }
}
