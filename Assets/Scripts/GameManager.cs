using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject Cube;

    public string set = "";

    /// <summary>
    /// To be implemented later
    /// </summary>
    public Transform Canon;
    public GameObject[] allBoxes;
    public GameObject cubesParent;
    public String spawn;
    public bool gameOver;
    public int blockCount;
    float AheadTime;
    public TextMeshProUGUI blockScore;

    private void Start()
    {
        AheadTime = Time.time;
        gameOver = false;
        blockCount = 1;
        blockScore.text = "1";
    }

    private void Update()
    {
        CheckMovement();
        blockScore.text = "Score: " + blockCount;
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void CheckMovement()
    {
        if (AheadTime < Time.time)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                GameObject square = Instantiate(Cube, new Vector3(0, 10), Quaternion.identity);
                square.transform.parent = cubesParent.transform;
                spawn = "up";
                
                AheadTime = Time.time + 1f;
                allBoxes = GameObject.FindGameObjectsWithTag("Player");
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                GameObject square = Instantiate(Cube, new Vector3(-15, 0), Quaternion.identity);
                square.transform.parent = cubesParent.transform;
                spawn = "left";
                
                AheadTime = Time.time + 1f;
                allBoxes = GameObject.FindGameObjectsWithTag("Player");
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                GameObject square = Instantiate(Cube, new Vector3(0, -10), Quaternion.identity);
                square.transform.parent = cubesParent.transform;
                spawn = "down";
                
                AheadTime = Time.time + 1f;
                allBoxes = GameObject.FindGameObjectsWithTag("Player");
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                GameObject square = Instantiate(Cube, new Vector3(15, 0), Quaternion.identity);
                square.transform.parent = cubesParent.transform;
                spawn = "right";
               
                AheadTime = Time.time + 1f;
                allBoxes = GameObject.FindGameObjectsWithTag("Player");
            }
            
        }
        
        
    }

   
}






