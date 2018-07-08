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
        dropChunk();

        //set to last cube
        LastCube = this;
    }
    
	void Update () {
        if(isMoving)
        transform.position += transform.forward * Time.deltaTime * moveSpeed;

	}

    void dropChunk()
    {
        
        float hangover = transform.position.z - LastCube.transform.position.z;

        float newZsize = LastCube.transform.localScale.z - Mathf.Abs(hangover);
        float fallingBlockSize = transform.localScale.z - newZsize;

        float newZPosition = LastCube.transform.position.z + (hangover / 2);
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, newZsize);
        transform.position = new Vector3(transform.position.x, transform.position.y, newZPosition); 
    }
}
