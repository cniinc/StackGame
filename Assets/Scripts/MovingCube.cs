using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCube : MonoBehaviour {
    private float moveSpeed = 1;
    
	void Update () {
        transform.position += transform.forward * Time.deltaTime * moveSpeed;

	}
}
