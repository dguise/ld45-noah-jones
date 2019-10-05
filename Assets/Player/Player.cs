using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 _movement = new Vector3();
    private Rigidbody _rb;

    [SerializeField] GameObject WhipActiveEffect;

    [SerializeField] private float Speed = 50;
    [SerializeField] private float TurnSpeed = 100;
    [SerializeField] private float WhipRange = 1000;

    private Quaternion _targetRotation;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _movement.x = Input.GetAxis("Horizontal");
        _movement.z = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // TODO: Play whip sound
            GameObject go = Instantiate<GameObject>(WhipActiveEffect, transform.position, Quaternion.identity);
            Destroy(go, 0.5f);
            var hits = Physics.SphereCastAll(transform.position, WhipRange, Vector3.up);
            foreach(var hit in hits)
            {
                hit.collider.TryGetComponent<Animal>(out var animal);
                if (animal != null)
                    animal.Scare(transform.position);
            }
        }
    }

    private void FixedUpdate()
    {
        if (_movement.magnitude > 0.1)
        {
            var newVel = _movement * Speed;
            newVel.y = _rb.velocity.y;
            _rb.velocity = newVel;
            transform.LookAt(transform.position + _movement);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, WhipRange);
    }
}
