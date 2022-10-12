using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformController : MonoBehaviour
{
	[Header("Attributes")]
	public int hp;
	public float speed = 5;
	public float jumpPower = 10;

	Animator anim;
	Rigidbody2D rb;
	Transform[] children;
	GameObject feet;

	Vector2 movement = new();

	bool grounded;

	void Start()
	{
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		children = GetComponentsInChildren<Transform>();

        foreach (Transform childTransform in children)
        {
			if (childTransform.gameObject.CompareTag("Feet"))
            {
				feet = childTransform.gameObject;
            }
        }
	}

	void Update()
	{
		float x = Input.GetAxis("Horizontal");

		movement.x = x * speed;

		if (x < 0 && transform.localScale.x > 0 || x > 0 && transform.localScale.x < 0)
        {
			gameObject.transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        }
		if (Input.GetButtonDown("Jump") && grounded)
		{
			rb.velocity = new Vector2(rb.velocity.x, jumpPower);
		}
		movement.y = rb.velocity.y;

		rb.velocity = movement;

		if ((x < 0 || x > 0) && !anim.GetCurrentAnimatorStateInfo(0).IsName("run") && !anim.GetCurrentAnimatorStateInfo(0).IsName("jump") &&
			!anim.GetCurrentAnimatorStateInfo(0).IsName("fall"))
        {
			anim.SetTrigger("Run");
        }
        else
        {
			anim.SetTrigger("Idle");
		}
		if (rb.velocity.y > 0 && !anim.GetCurrentAnimatorStateInfo(0).IsName("jump") && !grounded)
        {
			anim.SetTrigger("Jump");
        }
		else if (rb.velocity.y <= 0 && !anim.GetCurrentAnimatorStateInfo(0).IsName("fall") && !grounded)
        {
			anim.SetTrigger("Fall");
        }
        else if (!anim.GetCurrentAnimatorStateInfo(0).IsName("idle") && !anim.GetCurrentAnimatorStateInfo(0).IsName("run") && grounded)
        {
			anim.SetTrigger("Idle");
        }
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (feet != null && feet.CompareTag("Feet") && other.gameObject.layer == 6) // Ground check
			grounded = true;
	}

	void OnTriggerExit2D(Collider2D other)
	{
		grounded = false;
	}

	public void PickUpFruit()
    {
		hp++;
    }
}