using UnityEngine;

public class InputDemo : ProcessingLite.GP21
{
    [Header("Attributes")]
    [SerializeField, Range(0, 2)] float radius = 2f;
    
    [SerializeField] float velocity = 10f;
    [SerializeField] float maxVelocity = 20f;
    [SerializeField] float acceleration = 10f;
    [SerializeField] float deaccelerationSpeed = 30f;
    
    [SerializeField] Color32 velColor = Color.yellow;
    [SerializeField] Color32 accColor = Color.red;

    Vector2 velPos;
    Vector2 accPos;
    Vector2 movement;

    float startVelocity;

    void Start()
    {
        velPos.x = Width / 2;
        velPos.y = Height / 2;
        accPos.x = Width / 2;
        accPos.y = Height / 2;
        startVelocity = velocity;
    }

    void Update()
    {
        Background(50, 166, 240);

        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            velocity -= Time.deltaTime * deaccelerationSpeed;
        }
        else
        {
            movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
            velocity += acceleration * Time.deltaTime;
        }

        if (velocity >= maxVelocity)
        {
            velocity = maxVelocity;
        }
        else if (velocity <= 0)
        {
            velocity = 0;
        }

        velPos.x += movement.x * startVelocity * Time.deltaTime;
        velPos.y += movement.y * startVelocity * Time.deltaTime;

        accPos.x += movement.x * velocity * Time.deltaTime;
        accPos.y += movement.y * velocity * Time.deltaTime;

        ScreenFlip();
        Collision();
    }

    private void ScreenFlip()
    {
        for (int x = -1; x < 2; x++)
        {
            Stroke(velColor.r, velColor.g, velColor.b);
            Circle(velPos.x + Width * x, velPos.y, radius * 2);
            Stroke(accColor.r, accColor.g, accColor.b);
            Circle(accPos.x + Width * x, accPos.y, radius * 2);
            for (int y = -1; y < 2; y++)
            {
                Stroke(velColor.r, velColor.g, velColor.b);
                Circle(velPos.x + Width * x, velPos.y + Height * y, radius * 2);
                Stroke(accColor.r, accColor.g, accColor.b);
                Circle(accPos.x + Width * x, accPos.y + Height * y, radius * 2);
            }
        }
    }

    private void Collision()
    {
        // Circle 1 (Velocity)
        if (velPos.x < 0)
        {
            velPos.x += Width;
        }
        if (velPos.x > Width)
        {
            velPos.x -= Width;
        }
        if (velPos.y < 0)
        {
            velPos.y += Height;
        }
        if (velPos.y > Height)
        {
            velPos.y -= Height;
        }

        // Circle 2 (Acceleration)
        if (accPos.x < 0)
        {
            accPos.x += Width;
        }
        if (accPos.x > Width)
        {
            accPos.x -= Width;
        }
        if (accPos.y < 0)
        {
            accPos.y += Height;
        }
        if (accPos.y > Height)
        {
            accPos.y -= Height;
        }
    }
}
