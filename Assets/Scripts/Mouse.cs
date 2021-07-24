using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{

    public GameManager manager;
   
    public LineRenderer line;
    public int x;
    public int y;

    Vector2 mousePos;

    private void Awake()
    {
        
    }

    private void Start()
    {
        line.enabled = true;
        x = manager.xval;
        y = manager.yval;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Vector2Int.RoundToInt(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        aim();

    }

    void aim()
    {
        if (mousePos.x > x)
        {
            line.enabled = true;
            line.SetPosition(0, new Vector2(x, mousePos.y));
            RaycastHit2D ray = Physics2D.Raycast(new Vector2(x, mousePos.y), Vector2.left);

            if (ray)
            {
                line.SetPosition(1, ray.point);
            }
        }
        else if (mousePos.y > y)
        {
            line.enabled = true;
            line.SetPosition(0, new Vector2(mousePos.x, y));
            RaycastHit2D ray = Physics2D.Raycast(new Vector2(mousePos.x, y), Vector2.down);

            if (ray)
            {
                line.SetPosition(1, ray.point);
            }
        }
        else if (mousePos.y < -y)
        {
            line.enabled = true;
            line.SetPosition(0, new Vector2(mousePos.x, -y));
            RaycastHit2D ray = Physics2D.Raycast(new Vector2(mousePos.x, -y), Vector2.up);

            if (ray)
            {
                line.SetPosition(1, ray.point);
            }
        }
        else if (mousePos.x < -x)
        {
            line.enabled = true;
            line.SetPosition(0, new Vector2(-x, mousePos.y));
            RaycastHit2D ray = Physics2D.Raycast(new Vector2(-x, mousePos.y), Vector2.right);

            if (ray)
            {
                line.SetPosition(1, ray.point);
            }
        }
        else
        {
            line.enabled = false;
        }


    }
}
