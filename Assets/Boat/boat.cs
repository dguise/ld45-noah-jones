using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boat : MonoBehaviour
{

    private void OnTriggerEnter(Collider collider)
    {
        collider.TryGetComponent<Animal>(out var animal);
        if (animal != null)
        {
            animal.Board(transform.position);
        }
    }
}
