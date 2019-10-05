using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

enum State {
    Scared,
    Idle,
}

public class Animal : MonoBehaviour
{
    private Rigidbody _rb;

    private bool _scared;
    private Vector3 direction;
    private State _state = State.Idle;

    [SerializeField] private float Speed = 5;
    [SerializeField] private float[] RandomRange = new float[2] {1, 6};

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        StartCoroutine(NewDirection());
    }

    IEnumerator NewDirection()
    {
        while (true)
        {
            if (_state == State.Idle)
                direction = new Vector3(Random.Range(-1, 1f), 0, Random.Range(-1, 1f));

            var waitTime = Random.Range(RandomRange[0], RandomRange[1]);
            yield return new WaitForSeconds(waitTime);
        }
    }

    private void Update()
    {
        switch (_state)
        {
            case State.Idle:
                Idle();
                break;
            case State.Scared:
                Scared();
                break;
        }
    }

    private void Idle()
    {
        var newVel = direction * Speed;
        newVel.y = _rb.velocity.y;
        _rb.velocity = newVel;
    }

    private void Scared()
    {
        var newVel = direction * Speed * 2;
        newVel.y = _rb.velocity.y;
        _rb.velocity = newVel;
    }

    public void Scare(Vector3 position)
    {
        _state = State.Scared;
        direction = (transform.position - position).normalized;
        StartCoroutine(this.DelayedDo(3, () => _state = State.Idle));
    }
}


/*
    state = idle: Walk around every X seconds
    -> agitated, aggrovated

    state = agitated: flee from position

    state = aggrovated: attack target every, 
    -> calmed

    state = calmed: walk back to original position
    -> idle

*/
