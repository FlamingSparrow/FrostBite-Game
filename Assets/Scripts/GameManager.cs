using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject Cube;

    public string set = "";

    /// <summary>
    /// To be implemented later
    /// </summary>
    public Transform Canon;
    public GameObject[] allBoxes;

    float AheadTime;

    private void Start()
    {
        AheadTime = Time.time;
    }

    private void Update()
    {
        CheckMovement();
        allBoxes = GameObject.FindGameObjectsWithTag("Player");
        
    }

    private void CheckMovement()
    {
        if (AheadTime < Time.time)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                GameObject square = Instantiate(Cube, new Vector3(0, 10), Quaternion.identity);
                
                AheadTime = Time.time + 1f;

            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                GameObject square = Instantiate(Cube, new Vector3(-10, 0), Quaternion.identity);
                
                AheadTime = Time.time + 1f;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                GameObject square = Instantiate(Cube, new Vector3(0, -10), Quaternion.identity);
                
                AheadTime = Time.time + 1f;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                GameObject square = Instantiate(Cube, new Vector3(10, 0), Quaternion.identity);
               
                AheadTime = Time.time + 1f;
            }
            
        }
        
        
    }

   
}






