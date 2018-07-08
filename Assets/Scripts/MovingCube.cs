using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCube : Cube {
    public static MovingCube CurrentCube { get; private set; }
    public static Cube LastCube;
    public static int NumCubes = 1;

    private bool isMoving = true;

    [SerializeField]
    private float moveSpeed = 1;

    private void Awake()
    {
        //TODO: Move to Spawner
        CurrentCube = this;
    }

    internal void Stop()
    {
        //actual stopping
        isMoving = false;
        name = "Cube" + NumCubes;
        NumCubes++;

        //cutting 

        //set to last cube
        LastCube = this;
    }
    
	void Update () {
        if(isMoving)
        transform.position += transform.forward * Time.deltaTime * moveSpeed;

	}
}
