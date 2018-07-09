using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCube : Cube {
    public static MovingCube CurrentCube { get; private set; }
    public static Cube LastCube;
    public static int NumCubes = 1;

    private bool isMoving = true;
    [SerializeField]
    float reverseDistance = 1.25f;
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

        float travelDistance = transform.position.z - LastCube.transform.position.z;

        if (travelDistance > reverseDistance || travelDistance < -1f*(reverseDistance))
            moveSpeed *= -1;

	}

    void dropChunk()
    {
        
        float hangover = transform.position.z - LastCube.transform.position.z;
        float direction = hangover > 0 ? 1f : -1f;

        float newZsize = LastCube.transform.localScale.z - Mathf.Abs(hangover);
        float fallingBlockZSize = transform.localScale.z - newZsize;

        float newZPosition = LastCube.transform.position.z + (hangover / 2);
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, newZsize);
        transform.position = new Vector3(transform.position.x, transform.position.y, newZPosition);

        float cubeEdge = (transform.position.z + (newZsize / 2))* direction;
        float fallingBlockZPos = (cubeEdge + fallingBlockZSize / 2f) * direction;
        
        spawnDropCube(fallingBlockZPos, fallingBlockZSize);
    }

    private void spawnDropCube(float fallingBlockZPos, float fallingBlockZSize)
    {
        var dropCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        dropCube.GetComponent<Renderer>().material.color = Color.red;

        dropCube.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, fallingBlockZSize);
        dropCube.transform.position = new Vector3(transform.position.x, transform.position.y, fallingBlockZPos);
    }
}
