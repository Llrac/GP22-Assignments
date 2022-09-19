using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorAssignment : ProcessingLite.GP21
{
    [Header("Attributes")]
    [SerializeField, Range(0f, 2f)] float radius = 1;
    [SerializeField, Range(0f, 2f)] float speed = 1;

    Vector2 circlePosition;
    Vector2 cursorPosition;

    private void Start()
    {
        circlePosition = new Vector2(Width / 2, Height / 2);
        float diameter = radius * 2;
    }

    // Update is called once per frame
    void Update()
    {
        Background(0);
        // Sets circle's start position
        if (Input.GetMouseButtonDown(0))
        {
            circlePosition = new Vector2(MouseX, MouseY);
        }
        // Creates a line between circle's position and cursor
        if (Input.GetMouseButton(0))
        {
            Line(circlePosition.x, circlePosition.y, MouseX, MouseY);
            cursorPosition = Vector2.zero;
        }
        // Calculates distance between circle's position and cursor
        if (Input.GetMouseButtonUp(0))
        {
            cursorPosition = new Vector2(MouseX, MouseY);
            cursorPosition -= circlePosition;
        }
        // Circle collision
        if ((circlePosition.y + radius >= Height && cursorPosition.y > 0) || (circlePosition.y - radius <= 0 && cursorPosition.y < 0))
        {
            cursorPosition.y *= -1;
        }
        if ((circlePosition.x - radius <= 0 && cursorPosition.x < 0) || (circlePosition.x + radius >= Width && cursorPosition.x > 0))
        {
            cursorPosition.x *= -1;
        }
        // Moves circle's position toward cursor depending on speed and distance from cursor, then creates the circle at circle's position
        circlePosition += speed * Time.deltaTime * cursorPosition;
        Circle(circlePosition.x, circlePosition.y, radius * 2);
    }
}
