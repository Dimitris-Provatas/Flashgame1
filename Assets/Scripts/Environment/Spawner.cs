using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    GameManager gm;

    public GameObject[] obstacles;

    void Awake()
    {
        gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }
}
