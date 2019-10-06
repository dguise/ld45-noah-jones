using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Kangaroo;
    public GameObject Mammoo;
    public static GameManager Instance = null;

    public int score = 0;
    private int animals;
    public int mammoths = 3;
    public int kangaroos = 6;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        animals = mammoths + kangaroos;
        AddAnimals();
    }


    void AddAnimals()
    {
        for (int i=0; i < kangaroos; i++)
        {
            var spawn = new Vector3(Random.Range(256, 300), Random.Range(6, 14), Random.Range(203, 223));
            Instantiate(Kangaroo, spawn, Kangaroo.transform.rotation);
        }

        for (int i = 0; i < mammoths; i++)
        {
            var spawn = new Vector3(Random.Range(256, 300), Random.Range(6, 14), Random.Range(203, 223));
            Instantiate(Mammoo, spawn, Mammoo.transform.rotation);
        }


    }

    public void Reset()
    {
        score = 0;
    }

    public void AddScore(int amount)
    {
        score += amount;
        if (score >= animals)
        {
            Debug.Log("Win!");
        }
    }
}
