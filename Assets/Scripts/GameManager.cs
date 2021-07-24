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
    
    public int blockCount;
    float AheadTime;
    public TextMeshProUGUI blockScore;

    public Canvas GameOverCanvas;

    private bool gameOver;

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
                Cursor.lockState = CursorLockMode.Locked;
                GameOverCanvas.gameObject.SetActive(true);
            }
        }
    }

    private void Start()
    {
        AheadTime = Time.time;
        GameOver = false;
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
       // CheckDeath();
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
                

                if (roundedMouse.x > 18)
                {
                    GameObject square = Instantiate(Cube, new Vector3(18, roundedMouse.y), Quaternion.identity);
                    square.transform.parent = cubesParent.transform;
                    spawn = "right";
                    AheadTime = Time.time + 1f;
                    allBoxes = GameObject.FindGameObjectsWithTag("Player");
                }
                else if (roundedMouse.y > 6)
                {
                    GameObject square = Instantiate(Cube, new Vector3(roundedMouse.x, 7), Quaternion.identity);
                    square.transform.parent = cubesParent.transform;
                    spawn = "up";
                    AheadTime = Time.time + 1f;
                    allBoxes = GameObject.FindGameObjectsWithTag("Player");
                }
                else if (roundedMouse.x < -18)
                {
                    GameObject square = Instantiate(Cube, new Vector3(-18, roundedMouse.y), Quaternion.identity);
                    square.transform.parent = cubesParent.transform;
                    spawn = "left";

                    AheadTime = Time.time + 1f;
                    allBoxes = GameObject.FindGameObjectsWithTag("Player");
                }
                else if (roundedMouse.y < -6)
                {
                    GameObject square = Instantiate(Cube, new Vector3(roundedMouse.x, -7), Quaternion.identity);
                    square.transform.parent = cubesParent.transform;
                    spawn = "down";

                    AheadTime = Time.time + 1f;
                    allBoxes = GameObject.FindGameObjectsWithTag("Player");
                }
                
            }
            
            
        }
        
        
    }


    
}







