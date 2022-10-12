using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweakExample : MonoBehaviour
{
    [SerializeField] GameObject laserPrefab;

    [SerializeField] Vector2 position;
    [SerializeField] float speed = 2f;
    [SerializeField] float size = 1f;
    [SerializeField] float rotation;
    [SerializeField] float rotationMultiplier = 25f;
    [SerializeField] float fireRate = .3f;

    float timer;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && timer > fireRate)
        {
            Instantiate(laserPrefab, transform.position, transform.rotation);
            timer = 0;
        }
        if (Input.GetKey(KeyCode.W))
        {
            position.y += Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            position.y -= Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            position.x -= Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            position.x += Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.R))
        {
            size -= Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.T))
        {
            size += Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            rotation += Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.E))
        {
            rotation -= Time.deltaTime * speed;
        }
        transform.position = new Vector3(position.x, position.y);
        transform.localScale = Vector3.one * size;
        transform.localRotation = Quaternion.Euler(0, 0, rotation * rotationMultiplier);
        timer += Time.deltaTime;
    }
}
