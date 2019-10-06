using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 _movement = new Vector3();
    private Rigidbody _rb;
    private AudioSource _as;
    private Animator _anim;
    [SerializeField] GameObject WhipActiveEffect;

    [SerializeField] private float Speed = 50;
    [SerializeField] private float TurnSpeed = 100;
    [SerializeField] private float WhipRange = 1000;

    [SerializeField] private AudioClip[] Screams;

    private Quaternion _targetRotation;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
        _as = GetComponent<AudioSource>();
    }

    private void Update()
    {
        _movement.x = Input.GetAxis("Horizontal");
        _movement.z = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _as.Stop();
            _as.clip = Screams[Random.Range(0, Screams.Length)];
            _as.Play();
            Whip();
            var hits = Physics.SphereCastAll(transform.position, WhipRange, Vector3.up);
            foreach(var hit in hits)
            {
                hit.collider.TryGetComponent<Animal>(out var animal);
                if (animal != null)
                    animal.Scare(transform.position);
            }
        }
    }

    void Whip()
    {
        GameObject go = Instantiate<GameObject>(WhipActiveEffect, transform.position, Quaternion.identity, transform);
        Destroy(go, 0.5f);
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

        _anim.SetFloat("Speed", _rb.velocity.magnitude);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, WhipRange);
    }
}
