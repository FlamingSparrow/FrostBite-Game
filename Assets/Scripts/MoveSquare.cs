using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSquare : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    bool beforeHit = true;
    string spawn = "";
    Rigidbody2D rb2d;
    BoxCollider2D bx;

    GameObject Manager;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        bx = gameObject.GetComponent<BoxCollider2D>();

        Manager = GameObject.FindGameObjectWithTag("GameController");
    }



    // Update is called once per frame
    void Update()
    {
        SquareSpawned();
    }

    void SquareSpawned()
    {
        if (transform.position.y == 10)
        {
            spawn = "up";
        }
        else if (transform.position.y == -10)
        {
            spawn = "down";
        }
        else if (transform.position.x == 10)
        {
            spawn = "right";
        }
        else if (transform.position.x == -10)
        {
            spawn = "left";
        }

        Debug.Log(spawn);

        if (spawn.Equals("up") && beforeHit)
        {
            transform.position += Vector3.down * 0.1f;
        }
        else if (spawn.Equals("down") && beforeHit)
        {
            transform.position += Vector3.up * 0.1f;
        }
        else if (spawn.Equals("right") && beforeHit)
        {
            transform.position += Vector3.left * 0.1f;
        }
        else if (spawn.Equals("left") && beforeHit)
        {
            transform.position += Vector3.right * 0.1f;
        }





    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        beforeHit = false;

        foreach (GameObject item in Manager.GetComponent<GameManager>().allBoxes)
        {
            if (spawn.Equals("up"))
            {
                item.transform.position += Vector3.down;
            }
            if (spawn.Equals("down"))
            {
                item.transform.position += Vector3.up;
            }

            if (spawn.Equals("right"))
            {
                item.transform.position += Vector3.left;
            }

            if (spawn.Equals("left"))
            {
                item.transform.position += Vector3.right;
            }
            
        }

    }

}

   
