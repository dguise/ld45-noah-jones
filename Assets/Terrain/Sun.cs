using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    Vector3 startingPosition = new Vector3(345.8f, 338.9f, -1300);
    Vector3 endPosition = new Vector3(345.8f, 338.9f, 1327);

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, endPosition, 1);

        if (Vector3.Distance(this.transform.position, endPosition) < 10)
        {
            transform.position = startingPosition;
        }
    }
}
