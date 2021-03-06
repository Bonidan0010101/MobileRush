﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUPScript : MonoBehaviour {

    [SerializeField]
    private GameObject[] powerUp;

    float randomy_x;
    float randomy_y;
    Vector2 place;
    public float SpawnRate;
    float NextSpawn;

    void Update()
    {
        if (Time.time > NextSpawn)
        {
            int r = Random.Range(1, 2);

            NextSpawn = Time.time + SpawnRate;
            randomy_x = Random.Range(33.7f, 14.9f);
            randomy_y = Random.Range(-2.6f, 2.2f);
            place = new Vector2(randomy_x, randomy_y);

            Instantiate(powerUp[r - 1], place, Quaternion.identity);
        }
    }
}
