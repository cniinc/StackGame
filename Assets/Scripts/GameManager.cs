using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private int currentSpawner = 0;
    [SerializeField]
    private List<Spawner> Spawners;
    [SerializeField]
    private Cube startCube;

    
    public static Cube LastCube;

    private void Awake()
    {
        LastCube = startCube;
    }

    void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            MovingCube.CurrentCube.Stop();
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            print("test spawn");
        }
	}





}
