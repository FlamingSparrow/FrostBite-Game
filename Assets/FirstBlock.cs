using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstBlock : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Manager;
    bool finished = false;
    bool dead = false;

    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Finish")
        {
            finished = true;
            yield return new WaitForSeconds(0.5f);
            if (finished)
            {
                print("Finsih");
                if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 2)
                {
                    SceneManager.LoadScene(0);
                }
                else
                {
                    SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
                }

            }


        }

        if (collision.tag == "enemy")
        {
            if (gameObject.GetComponent<Rigidbody2D>().bodyType == RigidbodyType2D.Kinematic)
            {
                dead = true;
                yield return new WaitForSeconds(0.5f);
                if (dead)
                {
                    Manager.GetComponent<GameManager>().GameOver = true;
                }

            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Finish")
        {
            finished = false;
        }
        if (collision.tag == "enemy")
        {
            dead = false;
        }
    }
}
