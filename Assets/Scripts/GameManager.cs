using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject Cube;

    public int blocksLeft = 8;

    public string set = "";

    public int xval = 13;
    public int yval = 7;
    
    public GameObject[] allBoxes;
    public GameObject cubesParent;
    public String spawn;
    
    
    float AheadTime;
    public TextMeshProUGUI blockScore;


    public Canvas GameOverCanvas;

    private bool gameOver;

    float times;
    bool timesb = true;

    public bool GameOver
    {
        get { return gameOver; }
        set
        {
            if (value == gameOver)
                return;

            gameOver = value;
            if (gameOver)
            {
                Debug.Log("GameOver");
                SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
            }
        }
    }

    private void Start()
    {
        AheadTime = Time.time;
        GameOver = false;
        
        blockScore.text = "Blocks Remaining: " + blocksLeft.ToString();

        
    }

    private void Update()
    {
        CheckMovement();
        blockScore.text = "Blocks Remaining: " + blocksLeft.ToString();
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
        if (blocksLeft == 0)
        {
            if (timesb)
            {
                timesb = false;
                times = Time.time + 1f;
            }
            else if (Time.time > times && !timesb)
            {
                GameOver = true;
            }
            
        }
    }


    private void CheckMovement()
    {
        if (AheadTime < Time.time)
        {
            /* if (Input.GetKeyDown(KeyCode.W))
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
             }*/

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                //Cursor.visible = false;
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2Int roundedMouse = Vector2Int.RoundToInt(mousePos);
                

                if (roundedMouse.x > xval)
                {
                    GameObject square = Instantiate(Cube, new Vector3(xval, roundedMouse.y), Quaternion.identity);
                    square.transform.parent = cubesParent.transform;
                    spawn = "right";
                    AheadTime = Time.time + .2f;
                    allBoxes = GameObject.FindGameObjectsWithTag("Player");
                    
                }
                else if (roundedMouse.y > yval)
                {
                    GameObject square = Instantiate(Cube, new Vector3(roundedMouse.x, yval), Quaternion.identity);
                    square.transform.parent = cubesParent.transform;
                    spawn = "up";
                    AheadTime = Time.time + 1f;
                    allBoxes = GameObject.FindGameObjectsWithTag("Player");
                }
                else if (roundedMouse.x < -xval)
                {
                    GameObject square = Instantiate(Cube, new Vector3(-xval, roundedMouse.y), Quaternion.identity);
                    square.transform.parent = cubesParent.transform;
                    spawn = "left";

                    AheadTime = Time.time + 1f;
                    allBoxes = GameObject.FindGameObjectsWithTag("Player");
                }
                else if (roundedMouse.y < -yval)
                {
                    GameObject square = Instantiate(Cube, new Vector3(roundedMouse.x, -yval), Quaternion.identity);
                    square.transform.parent = cubesParent.transform;
                    spawn = "down";

                    AheadTime = Time.time + 1f;
                    allBoxes = GameObject.FindGameObjectsWithTag("Player");
                }
                
            }
            
            
        }
        
        
    }

    private void CheckDeath()
    {
        if (blocksLeft <= 0)
        {
            float time = Time.time + 1f;
            if (blocksLeft == 0 && Time.time > time)
            {
                GameOver = true;
            }
        }
    }
    
}







