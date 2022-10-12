using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TankController : MonoBehaviour
{
    [Header("Tank Attributes")]
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float turningSpeed = 150f;
    float angle;

    [Header("Bullet Attributes")]
    [SerializeField] GameObject bullet = null;
    [SerializeField] float bulletSpeed = 15f;

    Rigidbody2D rb2d;
    SpriteRenderer[] sr;
    GameObject turret = null;

    // Start is called before the first frame update
    void Start()
    {
        angle = 0;
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 0;

        sr = GetComponentsInChildren<SpriteRenderer>();

        foreach (SpriteRenderer spriteRenderer in sr)
        {
            if (spriteRenderer.gameObject.name == "Turret")
            {
                turret = spriteRenderer.gameObject;
            }
        }

        if (bullet == null)
        {
            bullet = (GameObject)Resources.Load("Bullet");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Fire();
    }

    private void Movement()
    {
        angle -= Input.GetAxis("Horizontal") * turningSpeed * Time.deltaTime;
        rb2d.MoveRotation(angle);

        float y = Input.GetAxis("Vertical");
        rb2d.velocity = movementSpeed * y * rb2d.transform.up;

        Vector2 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        turret.transform.up = (Vector3)mousePos - turret.transform.position;
    }

    void Fire()
    {
        if (Input.GetMouseButtonDown(0) && bullet != null)
        {
            GameObject newBullet = Instantiate(bullet, turret.transform.position, turret.transform.rotation);
            Destroy(newBullet, 2f);
            newBullet.AddComponent<Rigidbody2D>();
            newBullet.GetComponent<Rigidbody2D>().gravityScale = 0;
            newBullet.GetComponent<Rigidbody2D>().velocity = bulletSpeed * movementSpeed * turret.transform.up;
        }
    }
}
