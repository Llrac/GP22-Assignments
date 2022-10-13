using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : UsefulVariableClass
{
    [SerializeField] Vector2 offset = new(0.1f, -.2f);
    Vector3 mousePos;

    GameManager gm;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x + offset.x, mousePos.y + offset.y, 0);

        sr.sortingOrder = gm.universalSortingOrderID + 10;

        Rect screenRect = new(0, 0, Screen.width, Screen.height);
        if (screenRect.Contains(Input.mousePosition))
            Cursor.visible = false;
        else
            Cursor.visible = true;
    }
}
