using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Spawner : MonoBehaviour {
    [SerializeField]
    private MovingCube movingCube;


    public void Spawn()
    {
        print("Spawn");
        Instantiate(movingCube, transform.position, Quaternion.identity);
    }
}
