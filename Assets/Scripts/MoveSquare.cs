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
        if (beforeHit)
        {
            beforeHit = false;

            if (spawn.Equals("up"))
            {
                Manager.GetComponent<GameManager>().cubesParent.transform.position += new Vector3(0,-1,0);
            }
            if (spawn.Equals("down"))
            {
                Manager.GetComponent<GameManager>().cubesParent.transform.position += new Vector3(0,1,0);
            }

            if (spawn.Equals("right"))
            {
                Manager.GetComponent<GameManager>().cubesParent.transform.position += new Vector3(-1,0,0);
            }

            if (spawn.Equals("left"))
            {
                Manager.GetComponent<GameManager>().cubesParent.transform.position +=new Vector3(1,0,0);
            }
        }

        StartCoroutine(becomeKinematic());
        
        foreach (GameObject item in Manager.GetComponent<GameManager>().allBoxes)
        {
            item.transform.position = new Vector3(Mathf.RoundToInt(item.transform.position.x),Mathf.RoundToInt(item.transform.position.y),Mathf.RoundToInt(item.transform.position.z));
            if (Mathf.Abs(item.transform.position.x) > 9)
            {
                Manager.GetComponent<GameManager>().gameOver = true;
            }
            if (Mathf.Abs(item.transform.position.y) > 9)
            {
                Manager.GetComponent<GameManager>().gameOver = true;
            }
        }

    }

    IEnumerator becomeKinematic()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    }

}

   
