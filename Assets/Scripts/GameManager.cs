using System;
using System.Collections;
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
            cameraUpdate();
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            spawnNext();
        }
	}

    private void cameraUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
    }

    void spawnNext()
    {
        Spawners[0].Spawn();
    }





}
