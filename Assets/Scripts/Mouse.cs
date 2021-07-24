using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
   
    public LineRenderer line;
    

    Vector2 mousePos;

    private void Awake()
    {
        
    }

    private void Start()
    {
        line.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Vector2Int.RoundToInt(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        aim();

    }

    void aim()
    {
        if (mousePos.x > 18)
        {
            line.enabled = true;
            line.SetPosition(0, new Vector2(18, mousePos.y));
            RaycastHit2D ray = Physics2D.Raycast(new Vector2(18, mousePos.y), Vector2.left);

            if (ray)
            {
                line.SetPosition(1, ray.point);
            }
        }
        else if (mousePos.y > 6)
        {
            line.enabled = true;
            line.SetPosition(0, new Vector2(mousePos.x, 7));
            RaycastHit2D ray = Physics2D.Raycast(new Vector2(mousePos.x, 7), Vector2.down);

            if (ray)
            {
                line.SetPosition(1, ray.point);
            }
        }
        else if (mousePos.y < -6)
        {
            line.enabled = true;
            line.SetPosition(0, new Vector2(mousePos.x, -7));
            RaycastHit2D ray = Physics2D.Raycast(new Vector2(mousePos.x, -7), Vector2.up);

            if (ray)
            {
                line.SetPosition(1, ray.point);
            }
        }
        else if (mousePos.x < -18)
        {
            line.enabled = true;
            line.SetPosition(0, new Vector2(-18, mousePos.y));
            RaycastHit2D ray = Physics2D.Raycast(new Vector2(-18, mousePos.y), Vector2.right);

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
