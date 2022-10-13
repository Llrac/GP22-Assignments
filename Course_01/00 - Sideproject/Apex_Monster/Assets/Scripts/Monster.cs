using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PolygonCollider2D))]

public class Monster : UsefulVariableClass
{
    [SerializeField, Range(1f, 1.5f)] float dragSize = 1.5f;

    [SerializeField, HideInInspector] List<int> initialSortingOrderID;

    Vector3 startSize;
    Vector3 mousePos;
    Vector3 lastDragPos;
    Vector3 dragOffset;

    PolygonCollider2D pc2d;
    PolygonCollider2D[] pc2dInChild;

    Animator anim;
    GameManager gm;
    GameObject glowObject;
    SpriteRenderer[] spriteRenderers;

    bool mayDrag;
    int targetedLimb;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 0;

        pc2d = GetComponent<PolygonCollider2D>();
        pc2dInChild = GetComponentsInChildren<PolygonCollider2D>();

        anim = GetComponent<Animator>();
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();

        startSize = gameObject.transform.localScale;
        Transform[] monsterChildObjects = GetComponentsInChildren<Transform>();
        for (int i = 0; i < monsterChildObjects.Length; i++)
        {
            if (monsterChildObjects[i].name == "Glow" && glowObject != null)
            {
                glowObject = monsterChildObjects[i].gameObject;
            }
        }
        if (glowObject != null)
        glowObject.SetActive(false);
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();

        // Goes through each limb and saves their sorting order ID
        targetedLimb = 0;
        foreach (SpriteRenderer spriteRenderer in spriteRenderers)
        {
            initialSortingOrderID.Add(targetedLimb);
            initialSortingOrderID[targetedLimb] = spriteRenderer.sortingOrder;
            targetedLimb++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (mousePos.x < -Width / 2 || mousePos.x > Width / 2 || mousePos.y < -Height / 2 || mousePos.y > Height / 2)
        {
            mayDrag = false;
        }
        else
        {
            mayDrag = true;
        }
    }

    void OnMouseDown()
    {
        // Visual feedback
        anim.SetBool("isMoving", true);
        if (glowObject != null)
        glowObject.SetActive(true);

        // Collision and Scale
        else if (pc2d != null)
            pc2d.isTrigger = true;
        transform.localScale = new Vector3(transform.localScale.x * dragSize, transform.localScale.y * dragSize, 1);

        // Sorting Order
        gm.universalSortingOrderID++;
        targetedLimb = 0;
        foreach (SpriteRenderer spriteRenderer in spriteRenderers)
        {
            spriteRenderer.sortingOrder = gm.universalSortingOrderID + initialSortingOrderID[targetedLimb];
            targetedLimb++;
        }
        
        if (!mayDrag)
        {
            return;
        }
        dragOffset = new Vector3(mousePos.x, mousePos.y, 0) - transform.position;
    }

    void OnMouseDrag()
    {
        if (!mayDrag)
        {
            return;
        }

        // Drag mechanics
        transform.position = new Vector3(mousePos.x, mousePos.y, 0) - dragOffset;
        if (transform.position.x - lastDragPos.x > 0 && gameObject.transform.localScale.x > 0)
        {
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * -1,
                gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        }
        else if (transform.position.x - lastDragPos.x < 0 && gameObject.transform.localScale.x < 0)
        {
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * -1,
                gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        }
        lastDragPos = transform.position;
    }

    void OnMouseUp()
    {
        // Visual feedback
        anim.SetBool("isMoving", false);
        if (glowObject != null)
        glowObject.SetActive(false);

        // Collision
        else if (pc2d != null)
            pc2d.isTrigger = false;

        // Return scale
        if (gameObject.transform.localScale.x < 0)
        {
            gameObject.transform.localScale = new Vector3(-startSize.x, startSize.y, startSize.z);
        }
        else if (gameObject.transform.localScale.x > 0)
        {
            gameObject.transform.localScale = new Vector3(startSize.x, startSize.y, startSize.z);
        }
    }
}
