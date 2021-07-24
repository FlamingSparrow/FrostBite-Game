using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSquare : MonoBehaviour
{
   
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
    void FixedUpdate()
    {
        spawn = Manager.GetComponent<GameManager>().spawn;
        SquareSpawned();
    }

    void SquareSpawned()
    {
        /*
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
        */

        if (spawn.Equals("up") && beforeHit)
        {
            transform.position += Vector3.down * 0.5f;
        }
        else if (spawn.Equals("down") && beforeHit)
        {
            transform.position += Vector3.up * 0.5f;
        }
        else if (spawn.Equals("right") && beforeHit)
        {
            transform.position += Vector3.left * 0.5f;
        }
        else if (spawn.Equals("left") && beforeHit)
        {
            transform.position += Vector3.right * 0.5f;
        }

    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (beforeHit)
        {
            beforeHit = false;

            if (spawn.Equals("up"))
            {
                Manager.GetComponent<GameManager>().cubesParent.transform.position += new Vector3(0,-1,0);
                Manager.GetComponent<GameManager>().blockCount += 1;
            }
            if (spawn.Equals("down"))
            {
                Manager.GetComponent<GameManager>().cubesParent.transform.position += new Vector3(0,1,0);
                Manager.GetComponent<GameManager>().blockCount += 1;
            }

            if (spawn.Equals("right"))
            {
                Manager.GetComponent<GameManager>().cubesParent.transform.position += new Vector3(-1,0,0);
                Manager.GetComponent<GameManager>().blockCount += 1;
            }

            if (spawn.Equals("left"))
            {
                Manager.GetComponent<GameManager>().cubesParent.transform.position +=new Vector3(1,0,0);
                Manager.GetComponent<GameManager>().blockCount += 1;
            }

            Manager.GetComponent<AudioSource>().Play();
        }

        StartCoroutine(becomeKinematic());
        
        foreach (GameObject item in Manager.GetComponent<GameManager>().allBoxes)
        {
            item.transform.position = new Vector3(Mathf.RoundToInt(item.transform.position.x),Mathf.RoundToInt(item.transform.position.y),Mathf.RoundToInt(item.transform.position.z));
            if (Mathf.Abs(item.transform.position.x) > 9)
            {
                Manager.GetComponent<GameManager>().GameOver = true;
            }
            if (Mathf.Abs(item.transform.position.y) > 9)
            {
                Manager.GetComponent<GameManager>().GameOver = true;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "enemy")
        {
            Manager.GetComponent<GameManager>().GameOver = true;
        }
    }

    IEnumerator becomeKinematic()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    }

}

   
