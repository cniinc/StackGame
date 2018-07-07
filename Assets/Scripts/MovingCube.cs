using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCube : MonoBehaviour {
    public static MovingCube CurrentCube { get; private set; }
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
        isMoving = false;
    }
    
	void Update () {
        if(isMoving)
        transform.position += transform.forward * Time.deltaTime * moveSpeed;

	}
}
