using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Animal;
    public static GameManager Instance = null;

    public int score = 0;
    public int animals = 5;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        AddAnimals(animals);
    }


    void AddAnimals(int amount)
    {
        for (int i=0; i < amount; i++)
        {
            var spawn = new Vector3(Random.Range(138, 145), Random.Range(6, 14), Random.Range(125, 145));
            Instantiate(Animal, spawn, Quaternion.identity);
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
