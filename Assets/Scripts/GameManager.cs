﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private int currentSpawner = 0;
    [SerializeField]
    private List<Spawner> Spawners;
    [SerializeField]
    private Cube startCube;

    
    
    private void Awake()
    {
        MovingCube.LastCube = startCube;
    }

    void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            MovingCube.CurrentCube.Stop();
            spawnNext();
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            spawnNext();
        }
	}

    void spawnNext()
    {
        Spawners[0].Spawn();
    }





}
