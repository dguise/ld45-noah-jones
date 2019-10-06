using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject Kangaroo;
    public GameObject Mammoo;
    public GameObject Pigo;
    public GameObject Elk;
    public static GameManager Instance = null;

    public int score = 0;
    private int animals;
    public int mammoths = 2;
    public int kangaroos = 5;
    public int pig = 10;
    public int elk = 3;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        animals = (int)((mammoths + kangaroos + pig)*0.5);
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

        for (int i = 0; i < pig; i++)
        {
            var spawn = new Vector3(Random.Range(256, 300), Random.Range(6, 14), Random.Range(203, 223));
            Instantiate(Pigo, spawn, Pigo.transform.rotation);
        }

        for (int i = 0; i < elk; i++)
        {
            var spawn = new Vector3(Random.Range(256, 300), Random.Range(6, 14), Random.Range(203, 223));
            Instantiate(Elk, spawn, Elk.transform.rotation);
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
