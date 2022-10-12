using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WIPWallGenerator : MonoBehaviour
{
    [SerializeField] GameObject wall = null;

    Vector2 center;

    float Width;
    float Height;

    void Start()
    {
        Width = Camera.main.orthographicSize  * Camera.main.aspect;
        Height = Camera.main.orthographicSize;
        center = new Vector2(Width, Height);

        wall = (GameObject)Resources.Load("Wall");
        for (int x = -1; x < 2; x+= 2)
        {
            for (int y = -1; y < 2; y+= 2)
            {
                GameObject newWall = Instantiate(wall, new Vector2(transform.position.x + Width * x, transform.position.y + Height * y), transform.rotation);
                if (newWall.transform.position.y < center.y || newWall.transform.position.y > center.y)
                {
                    newWall.transform.rotation = Quaternion.Euler(0, 0, 90);
                }
            }
        }
    }
}
